using System.ComponentModel.DataAnnotations; //Importacion para unar la notation como Key y Required
using System.ComponentModel.DataAnnotations.Schema; //Nos definie la ForeignKey
using System.Text.Json.Serialization;

namespace EntityFramework.Models; //Relacionamos con el nombre de espacio que usaremos

[Table("Category")] //Especifica el nombre de la tabla en la base de datos
public class Category //Definimos el modelo de la tabla en la DB 
{
	//[Key] //Formsamos que el modelo reconozca el CategoryId como Id 
	public Guid CategoryId {get; set;} //signamos un Guid a la tabla de categoria
	//[Required] //Pedimos que el name sea requerido
	//[MaxLength(150)] //Decimos que tiene maximo 150 caracteres el name
	public string Name {get;set;} //Asiganmos un name
	public string Description {get;set;} // Asignamos una Description
	public int Weight {get;set;}
	[JsonIgnore]
	public virtual ICollection<Homework> Homework {get;set;} //Relacionamos la tabla de Task con la tabla de Category
}