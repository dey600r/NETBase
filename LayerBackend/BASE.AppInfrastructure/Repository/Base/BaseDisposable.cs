using System.Reflection;

namespace BASE.AppInfrastructure.Repository
{
	public class BaseDisposable : IDisposable
	{
		public BaseDisposable()
		{
		}

		public void Dispose()
		{
			MethodBase method = MethodBase.GetCurrentMethod();
			Console.WriteLine($"{method?.ReflectedType?.Name} / {method?.Name} - Disposed");
		}
	}
}
