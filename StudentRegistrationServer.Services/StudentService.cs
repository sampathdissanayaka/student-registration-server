using Microsoft.EntityFrameworkCore;
using StudentRegistrationServer.DataAccess;
using StudentRegistrationServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationServer.Services
{
	public class StudentService : IStudentRepository
	{
		private readonly StudentDbContext _context = new StudentDbContext();

		public Student CreateStudent(Student student)
		{
			_context.Students.Add(student);
			_context.SaveChanges();
			return student;
		}

		public void DeleteStudent(int id)
		{
			var student = _context.Students.Find(id);
			if (student != null)
			{
				_context.Students.Remove(student);
				_context.SaveChanges();
			}
		}

		public List<Student> GetAllStudents(string search)
		{
			if (string.IsNullOrWhiteSpace(search))
			{
				return _context.Students.ToList();
			} else
			{
				var studentCollection = _context.Students as IQueryable<Student>;
				search = search.Trim();
				studentCollection = studentCollection.Where(
					a => a.FirstName.Contains(search) || 
					a.LastName.Contains(search) || 
					a.Email.Contains(search) || 
					a.Mobile.Contains(search) || 
					a.NIC.Contains(search));

				return studentCollection.ToList();

			}


		}

		public Student GetStudentById(int id)
		{
			return _context.Students.Find(id);
		}

		public Student UpdateStudent(Student student)
		{
			var existingStudent = _context.Students.Find(student.Id);
			if (existingStudent == null)
			{
				return null;
			}

			existingStudent.FirstName = student.FirstName;
			existingStudent.LastName = student.LastName;
			existingStudent.Mobile = student.Mobile;
			existingStudent.Email = student.Email;
			existingStudent.NIC = student.NIC;
			existingStudent.DateOfBirth = student.DateOfBirth;
			existingStudent.Address = student.Address;
			existingStudent.ProfileImagePath = student.ProfileImagePath;

		    _context.SaveChanges();
			return existingStudent;
		}
	}
}
