
using Hangfire;
using Hangfire.SqlServer;

namespace JapPlatformBackend.Api.Extensions
{
    public static class HangfireExtension
    {
        public static void RegisterHangfire(this IServiceCollection service)
        {
            var provider = service.BuildServiceProvider();
            var configuration = provider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetValue<string>("ConnectionStrings:HangfireConnection")
                ?? throw new Exception("DB connection string is not valid");

            service.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(connectionString, new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));

        }
    }
}
