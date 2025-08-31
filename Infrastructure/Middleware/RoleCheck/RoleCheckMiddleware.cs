namespace CloneCode.Infrastructure.Middleware.RoleCheck
{
    public class RoleCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public RoleCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var user = context.User;

            if (user.Identity?.IsAuthenticated == true)
            {
                var role = user.FindFirst("role")?.Value;

                if (string.IsNullOrEmpty(role))
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Access denied: No role assigned.");
                    return;
                }

                // 예: 최소한 User 역할은 있어야 통과
                if (role != "User" && role != "Admin")
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Access denied: Invalid role.");
                    return;
                }
            }

            await _next(context);
        }
    }
}
