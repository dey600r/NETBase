namespace BASE.Common.Dtos
{
    public interface IBaseModel<TId> where TId : struct
    {
        public TId Id { get; set; }
    }
}
