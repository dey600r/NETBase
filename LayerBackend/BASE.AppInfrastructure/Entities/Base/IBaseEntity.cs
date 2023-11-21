namespace BASE.AppInfrastructure.Entities
{
	public interface IBaseEntity<TId> where TId : struct
	{
		public TId Id { get; set; }
	}
}
