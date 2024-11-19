using StudentRegistrationServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationServer.Services
{
	public interface IStudentRepository
	{
		public List<Student> GetAllStudents(string  serach);
		public Student GetStudentById(int id);
		public Student CreateStudent(Student student);
		public Student UpdateStudent(Student student);
		public void DeleteStudent(int id);
	}
}
