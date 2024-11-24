namespace OrganizaMed.WebApi;

public class Program
{
	public static void Main(string[] args)
	{
		const string politicaCors = "_minhaPoliticaCors";

		var builder = WebApplication.CreateBuilder(args);

		builder.Services.ConfigureDbContext(builder.Configuration, builder.Environment);

		builder.Services.AddControllers();

		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		var app = builder.Build();

		app.UseSwagger();
		app.UseSwaggerUI();

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}