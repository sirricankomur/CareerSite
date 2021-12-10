namespace CareerSite.MvcWebUI.Extensions
{
    public class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var applicationContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>())
                {
                    try
                    {
                        applicationContext.Database.Migrate();
                    }
                    catch (System.Exception)
                    {
                        // loglama
                        throw;
                    }
                }

                using (var shopContext = scope.ServiceProvider.GetRequiredService<CareerContext>())
                {
                    try
                    {
                        shopContext.Database.Migrate();
                    }
                    catch (System.Exception)
                    {
                        // loglama
                        throw;
                    }
                }
            }

            return host;
        }

    }
}
