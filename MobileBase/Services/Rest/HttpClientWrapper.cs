using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;


namespace MobileBase.Services.Rest
{
    /// <summary>
    ///     A wrapper around the standard HttpWrapper for the purposes of easier Auth support, and easier unit testing.
    ///     (Though I'm not sure this is necessary for unit testing like I remember it being back when... It seems Moq
    ///     could totally extend HttpClient...)
    /// </summary>
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly HttpClient _client = new HttpClient();

        public Uri BaseAddress {
            get { return _client.BaseAddress; }
            set { _client.BaseAddress = value; }
        }

        public HttpRequestHeaders DefaultRequestHeaders {
            get { return _client.DefaultRequestHeaders; }
        }

        public long MaxResponseContentBufferSize {
            get { return _client.MaxResponseContentBufferSize; }
            set { _client.MaxResponseContentBufferSize = value; }
        }

        public TimeSpan Timeout {
            get { return _client.Timeout; }
            set { _client.Timeout = value; }
        }


        public void CancelPendingRequests() => _client.CancelPendingRequests();


        public Task<HttpResponseMessage> DeleteAsync(string requestUri) => _client.DeleteAsync(requestUri);


        public Task<HttpResponseMessage> DeleteAsync(
            string requestUri,
            CancellationToken cancellationToken
        ) => _client.DeleteAsync(requestUri, cancellationToken);


        public Task<HttpResponseMessage> DeleteAsync(Uri requestUri) => _client.DeleteAsync(requestUri);


        public Task<HttpResponseMessage> DeleteAsync(
            Uri requestUri,
            CancellationToken cancellationToken
        ) => _client.DeleteAsync(requestUri, cancellationToken);


        public Task<HttpResponseMessage> GetAsync(string requestUri) => _client.GetAsync(requestUri);


        public Task<HttpResponseMessage> GetAsync(
            string requestUri,
            HttpCompletionOption completionOption
        ) => _client.GetAsync(requestUri, completionOption);


        public Task<HttpResponseMessage> GetAsync(
            string requestUri,
            HttpCompletionOption completionOption,
            CancellationToken cancellationToken
        ) => _client.GetAsync(requestUri, completionOption, cancellationToken);


        public Task<HttpResponseMessage> GetAsync(
            string requestUri,
            CancellationToken cancellationToken
        ) => _client.GetAsync(requestUri, cancellationToken);


        public Task<HttpResponseMessage> GetAsync(Uri requestUri) => _client.GetAsync(requestUri);


        public Task<HttpResponseMessage> GetAsync(
            Uri requestUri,
            HttpCompletionOption completionOption
        ) => _client.GetAsync(requestUri, completionOption);


        public Task<HttpResponseMessage> GetAsync(
            Uri requestUri,
            HttpCompletionOption completionOption,
            CancellationToken cancellationToken
        ) => _client.GetAsync(requestUri, completionOption, cancellationToken);


        public Task<HttpResponseMessage> GetAsync(
            Uri requestUri,
            CancellationToken cancellationToken
        ) => _client.GetAsync(requestUri, cancellationToken);


        public Task<byte[]> GetByteArrayAsync(string requestUri) => _client.GetByteArrayAsync(requestUri);


        public Task<byte[]> GetByteArrayAsync(Uri requestUri) => _client.GetByteArrayAsync(requestUri);


        public Task<Stream> GetStreamAsync(string requestUri) => _client.GetStreamAsync(requestUri);


        public Task<Stream> GetStreamAsync(Uri requestUri) => _client.GetStreamAsync(requestUri);


        public Task<string> GetStringAsync(string requestUri) => _client.GetStringAsync(requestUri);


        public Task<string> GetStringAsync(Uri requestUri) => _client.GetStringAsync(requestUri);


        public Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content) => _client.PostAsync(
            requestUri,
            content
        );


        public Task<HttpResponseMessage> PostAsync(
            string requestUri,
            HttpContent content,
            CancellationToken cancellationToken
        ) => _client.PostAsync(requestUri, content, cancellationToken);


        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content) => _client.PostAsync(
            requestUri,
            content
        );


        public Task<HttpResponseMessage> PostAsync(
            Uri requestUri,
            HttpContent content,
            CancellationToken cancellationToken
        ) => _client.PostAsync(requestUri, content, cancellationToken);


        public Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content) => _client.PutAsync(
            requestUri,
            content
        );


        public Task<HttpResponseMessage> PutAsync(
            string requestUri,
            HttpContent content,
            CancellationToken cancellationToken
        ) => _client.PutAsync(requestUri, content, cancellationToken);


        public Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content) => _client.PutAsync(
            requestUri,
            content
        );


        public Task<HttpResponseMessage> PutAsync(
            Uri requestUri,
            HttpContent content,
            CancellationToken cancellationToken
        ) => _client.PutAsync(requestUri, content, cancellationToken);


        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request) => _client.SendAsync(request);


        public Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            HttpCompletionOption completionOption
        ) => _client.SendAsync(request, completionOption);


        public Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            HttpCompletionOption completionOption,
            CancellationToken cancellationToken
        ) => _client.SendAsync(request, completionOption, cancellationToken);


        public Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        ) => _client.SendAsync(request, cancellationToken);


        public void Dispose() => _client.Dispose();
    }
}