namespace BASE.Common.Exceptions
{
	public class ConcurrencyDataBaseException : Exception
	{
		public ConcurrencyDataBaseException() { }

		public ConcurrencyDataBaseException(string message)
			: this(message, new Exception())
		{

		}

		public ConcurrencyDataBaseException(string message, Exception ex)
			: base($"CONCURRENCY DATABASE ERROR: {message}", ex)
		{

		}
	}
}
