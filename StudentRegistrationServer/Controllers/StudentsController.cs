using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistrationServer.Models;
using StudentRegistrationServer.Services;

namespace StudentRegistrationServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private IStudentRepository _studentService;
		private readonly string _uploadsFolder;

		public StudentsController(
			IStudentRepository studentService)
		{
			_studentService = studentService;

			_uploadsFolder = Path.Combine(@"F:\UploadedFiles");

			if (!Directory.Exists(_uploadsFolder))
			{
				Directory.CreateDirectory(_uploadsFolder);
			}
		}

		[HttpGet]
		public IActionResult GetAllStudents(string? search)
		{
			var students = _studentService.GetAllStudents(search);
			return Ok(students);
		}

		[HttpGet("{id}")]
		public IActionResult GetStudentById(int id)
		{
			var student = _studentService.GetStudentById(id);
			if (student == null)
			{
				return NotFound();
			}

			return Ok(student);
		}

		[HttpPost]
		public IActionResult CreateStudent([FromBody] Student student)
		{
			var createdStudent = _studentService.CreateStudent(student);
			return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.Id }, createdStudent);
		}

		[HttpPut]
		public IActionResult UpdateStudent([FromBody] Student student)
		{
			var updatedStudent = _studentService.UpdateStudent(student);
			if (updatedStudent == null)
			{
				return NotFound();
			}

			return Ok(updatedStudent);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteStudent(int id)
		{
			_studentService.DeleteStudent(id);
			return NoContent();
		}

		[HttpPost("upload")]
		public IActionResult UploadProfileImage([FromForm] IFormFile file)
		{
			if (file == null || file.Length == 0)
				return BadRequest("No file uploaded.");

			var uploadsFolder = @"F:\UploadedFiles";

			if (!Directory.Exists(uploadsFolder))
				Directory.CreateDirectory(uploadsFolder);

			var filePath = Path.Combine(uploadsFolder, file.FileName);

			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				file.CopyTo(stream);
			}

			var fileUrl = $"{Request.Scheme}://{Request.Host}/uploads/{file.FileName}";
			return Ok(new { fileUrl });
		}
	}
}
