using Microsoft.Extensions.FileProviders;
using StudentRegistrationServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowApp", builder =>
	{
		builder.AllowAnyOrigin()
			.AllowAnyHeader()
			.AllowAnyMethod();
	});
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStudentRepository, StudentService>();

var app = builder.Build();

// Serve static files from F:\UploadedFiles
app.UseStaticFiles(new StaticFileOptions
{
	FileProvider = new PhysicalFileProvider(@"F:\UploadedFiles"),
	RequestPath = "/uploads"
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowApp");

app.UseAuthorization();

app.MapControllers();

app.Run();