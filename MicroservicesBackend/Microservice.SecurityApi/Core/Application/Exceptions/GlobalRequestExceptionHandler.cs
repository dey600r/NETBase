
using System.Net;

namespace Microservice.SecurityApi.Core.Application.Exceptions
{
	public class GlobalRequestExceptionHandler 	{
		private readonly RequestDelegate _next;
		private readonly ILogger<GlobalRequestExceptionHandler> _logger;

		public GlobalRequestExceptionHandler(RequestDelegate next, ILogger<GlobalRequestExceptionHandler> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private async Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			_logger.LogError(exception, "An unexpected error occurred.");

			//More log stuff        

			//ExceptionResponse response = exception switch
			//{
			//	ApplicationException _ => new ExceptionResponse(HttpStatusCode.BadRequest, "Application exception occurred."),
			//	KeyNotFoundException _ => new ExceptionResponse(HttpStatusCode.NotFound, "The request key not found."),
			//	UnauthorizedAccessException _ => new ExceptionResponse(HttpStatusCode.Unauthorized, "Unauthorized."),
			//	_ => new ExceptionResponse(HttpStatusCode.InternalServerError, "Internal server error. Please retry later.")
			//};

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
			await context.Response.WriteAsJsonAsync(new { exception.Message });
		}
	}
}
