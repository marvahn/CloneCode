using Supabase;

namespace CloneCode.Infrastructure.Database
{
    public class SupabaseClientProvider
    {
        private Client? _client;

        public Client Client()
        {
            if (_client == null)
            {
                throw new InvalidOperationException("SupabaseClient not initialized");
            }

            return this._client;
        }

        public void SetClient(Client client)
        {
            this._client = client;
        }
    }
}
