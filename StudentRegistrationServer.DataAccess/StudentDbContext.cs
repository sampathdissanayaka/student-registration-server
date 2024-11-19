using Microsoft.EntityFrameworkCore;
using StudentRegistrationServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationServer.DataAccess
{
	public class StudentDbContext : DbContext
	{
		public DbSet<Student> Students { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connectionString = "Server=localhost; Database=StudentRegistrationDb; Trusted_Connection=True; TrustServerCertificate=True";
			optionsBuilder.UseSqlServer(connectionString);
		}
	}
}
