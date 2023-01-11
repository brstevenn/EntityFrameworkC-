using Microsoft.EntityFrameworkCore; //Esto nos permite hacer la conexion del context de la DB
using EntityFramework.Models; //Traemos el espacio de trabajo

namespace EntityFramework; //Trabajamos sobre ese espacio de trabajo

public class HomeworkContext: DbContext //Definimos el contexto y le cargamos el contexto de la db
{
	public DbSet<Category> Categories {get;set;} //Traemos el modelo de Categories
	public DbSet<Homework> Homeworks {get;set;} //Traemos el modelo de Homework

	public HomeworkContext(DbContextOptions<HomeworkContext> options) :base(options) {} //Definimos la conexion y le pasamos las opciones y referencia del contexto 

	protected override void OnModelCreating(ModelBuilder modeBuilder) 
	{
		List<Category> categoriesInit = new List<Category>();
		categoriesInit.Add(new Category() {CategoryId = Guid.Parse("75ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"), Name = "Actividades pendientes", Weight = 20});
		categoriesInit.Add(new Category() {CategoryId = Guid.Parse("64ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"), Name = "Actividades personales", Weight = 50});


		modeBuilder.Entity<Category>(category => 
		{
			category.ToTable("Category");
			category.HasKey(p => p.CategoryId);
			category.Property(p => p.Name).IsRequired().HasMaxLength(150);
			category.Property(p => p.Description).IsRequired(false);
			category.Property(p => p.Weight);

			category.HasData(categoriesInit);
		});

		DateTime localDateTime = DateTime.Now;
		DateTime utcDateTime = localDateTime.ToUniversalTime();

		List<Homework> homeworksInit = new List<Homework>();
		homeworksInit.Add(new Homework() {HomeworkId = Guid.Parse("53ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"), CategoryId = Guid.Parse("75ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"), PriorityHomework = Priority.Medium, Title = "Pago de servicios", CreationDate = utcDateTime, Process = "Pending"});
		homeworksInit.Add(new Homework() {HomeworkId = Guid.Parse("42ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"), CategoryId = Guid.Parse("75ec6ad2-eb0b-4aa5-90cf-a6d2d0131536"), PriorityHomework = Priority.Low, Title = "Terminar serie", CreationDate = utcDateTime, Process = "Pending"});
		
		modeBuilder.Entity<Homework>(homework =>
		{
			homework.ToTable("Homework");
			homework.HasKey(p => p.HomeworkId);
			homework.HasOne(p => p.Category).WithMany(p => p.Homework).HasForeignKey(p => p.CategoryId);
			homework.Property(p => p.Title).IsRequired().HasMaxLength(200);
			homework.Property(p => p.Description).IsRequired(false);
			homework.Property(p => p.PriorityHomework);
			homework.Property(p => p.CreationDate);
			homework.Ignore(p => p.Resume);
			homework.Property(p => p.Process);

			homework.HasData(homeworksInit);
		});
	}
}