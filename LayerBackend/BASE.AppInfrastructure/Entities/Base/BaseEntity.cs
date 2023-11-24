using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BASE.AppInfrastructure.Entities
{
	public class BaseEntity<TId> : IBaseEntity<TId> where TId : struct
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public TId Id { get; set; }
	}
}
