namespace BASE.Common.Dtos
{
	public class BaseModel<TId> : IBaseModel<TId> where TId : struct
	{
		public TId Id { get; set; }
	}
}
