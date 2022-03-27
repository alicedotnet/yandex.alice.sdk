namespace Yandex.Alice.Sdk.Services
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;

    public abstract class ApiServiceBase : IDisposable
    {
        protected HttpClient ApiClient { get; set; }

        private bool _disposedValue;

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [SuppressMessage("ReSharper", "VirtualMemberNeverOverridden.Global", Justification = "Keep virtual to comform with Dispose pattern")]
        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue)
            {
                return;
            }

            if (disposing)
            {
                ApiClient.Dispose();
            }

            _disposedValue = true;
        }
    }
}
