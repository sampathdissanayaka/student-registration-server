using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationServer.Models
{
	public class Student
	{
		public int Id { get; set; }
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string Mobile { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string NIC { get; set; } = string.Empty;
		public DateTime? DateOfBirth { get; set; }
		public string? Address { get; set; } = string.Empty;
		public string? ProfileImagePath { get; set; }
	}
}
