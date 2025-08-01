using System.Linq;

namespace TurnosClinicaAdmin.BlazorServer.Middaware
{
    public class SessionMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Excluir rutas específicas como BlazorHub o archivos estáticos
            if (context.Request.Path.StartsWithSegments("/_blazor") ||
                context.Request.Path.StartsWithSegments("/css") ||
                context.Request.Path.StartsWithSegments("/js"))
            {
                await _next(context);
                return;
            }

            // Define las rutas protegidas
            var protectedRoutes = new[] { "/dashboard", "/profile" };

            // Verifica si el usuario está autenticado y accede a una ruta protegida
            if (protectedRoutes.Contains(context.Request.Path.Value) &&
                string.IsNullOrEmpty(context.Session.GetString("Nombre")))
            {
                if (!context.Response.HasStarted) // Verifica si la respuesta no ha comenzado
                {
                    context.Response.Redirect("/login"); // Redirige al login si no está autenticado
                    return;
                }
            }

            await _next(context);
        }
    }
}
