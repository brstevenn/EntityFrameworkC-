using Microsoft.EntityFrameworkCore; //Esto nos permite hacer la conexion del context de la DB
using EntityFramework.Models; //Traemos el espacio de trabajo

namespace EntityFramework; //Trabajamos sobre ese espacio de trabajo

public class TaskContext: DbContext //Definimos el contexto y le cargamos el contexto de la db
{
	public DbSet<Category> Categories {get;set;} //Traemos el modelo de Categories
	public DbSet<Task> Tasks {get;set;} //Traemos el modelo de Task

	public TaskContext(DbContextOptions<TaskContext> options) :base(options) {} //Definimos la conexion y le pasamos las opciones y referencia del contexto 
}