using BASE.AppInfrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BASE.AppInfrastructure.Repository
{
	public interface IBaseRepository<TEntity, TId> where TEntity : class, IBaseEntity<TId>, new()
													where TId : struct
	{

	}
}
