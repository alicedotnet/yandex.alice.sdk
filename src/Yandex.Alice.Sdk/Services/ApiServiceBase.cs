namespace Yandex.Alice.Sdk.Services
{
    using System;
    using System.Net.Http;

    public abstract class ApiServiceBase : IDisposable
    {
        protected HttpClient ApiClient { get; set; }

        private bool disposedValue;

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    ApiClient.Dispose();
                }

                disposedValue = true;
            }
        }
    }
}
