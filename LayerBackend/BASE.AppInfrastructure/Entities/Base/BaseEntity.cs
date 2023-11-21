using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace BASE.AppInfrastructure.Entities
{
	public class BaseEntity<TId> : IBaseEntity<TId> where TId : struct
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public TId Id { get; set; }
	}
}
