using System.ComponentModel.DataAnnotations; //Importacion para unar la notation como Key y Required
using System.ComponentModel.DataAnnotations.Schema; //Nos definie la ForeignKey

namespace EntityFramework.Models; //Traemos el espacio de trabajo

public class Task //Definimos el modelo de Tareas
{
	[Key] //Forsamos que el Id dea TaskId
	public Guid TaskId {get;set;} //Definimos el Id con Guid
	[ForeignKey("CategoryId")] //Es la Key foranea que se va a relacionar con el Id de la tabla Category, le pasamos el nombre "CategoryId"
	public Guid CategoryId {get;set;} //Asignamos tambien el Id de Category
	[Required] //Pide que sea obligatorio agregar un titulo
	[MaxLength(200)] //Esto simplemente limita el tamaño a 200 caracteres
	public string Title {get;set;} //Definimos el Title
	public string Description {get;set;} //Definimos la Description
	public Priority PriorityTask {get;set;} //Definimos la PriorityTask
	public DataTime CreationDate {get;set;} //Definimos una fecha de creacion (DataTime)
	public virtual Category Category {get;set;} //Creamos un dato virtual de Category
	[NotMapped] //Esto hace que el dato Resume no se agregue a la DB
	public string Resume {get;set;} //Solo se llena con el titulo y la descripcion para recortar datos, pero que no se agrega a la db
}

public enum Priority //Definimos el modelo enum
{
	Low, //Enum 1
	Medium, //Enum 2
	High //Enum 3
}