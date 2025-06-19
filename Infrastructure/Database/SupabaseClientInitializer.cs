namespace CloneCode.Infrastructure.Database
{
    using Supabase;

    public class SupabaseClientInitializer : IHostedService
    {
        private readonly IConfiguration _config;
        private readonly SupabaseClientProvider _provider;

        public SupabaseClientInitializer(IConfiguration config, SupabaseClientProvider provider)
        {
            _config = config;
            _provider = provider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var client = new Client(this._config["Supabase:Url"]!, this._config["Supabase:Key"]!);
            await client.InitializeAsync();

            this._provider.SetClient(client);
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
