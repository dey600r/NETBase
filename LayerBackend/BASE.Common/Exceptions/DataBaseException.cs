namespace BASE.Common.Exceptions
{
	public class DataBaseException: Exception
	{
		public DataBaseException() { }

		public DataBaseException(string message)
			: this(message, new Exception())
		{

		}

		public DataBaseException(string message, Exception ex)
			: base($"DATABASE ERROR: {message}", ex)
		{

		}
	}
}
