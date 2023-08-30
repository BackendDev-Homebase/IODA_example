using IODA.Adapters.Providers;

namespace Controllers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            AddServices(builder.Services);
            var app = builder.Build();

            app.MapControllers();

            app.Run();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddSingleton<DataAccess>();
        }
    }
}