namespace WebApplication1.Middleware
{
    public class TokenCheckerMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenCheckerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Path.StartsWithSegments("/exceptionController"))
            {
                if (context.Request.Headers.ContainsKey("Authorization"))
                {
                    var token = context.Request.Headers["Authorization"].ToString();
                    if (token == "test_valid_token")
                    {
                        await _next(context);
                    }
                    else
                    {
                        context.Response.StatusCode = 401;
                        await context.Response.WriteAsync("Token geçersiz");
                    }
                }
                else
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Token bulunamadı");
                }

                await _next(context);
            }

            else
            {
                await _next(context);
                return;
            }
        }
    }
}