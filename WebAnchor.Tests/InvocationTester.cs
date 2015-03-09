using System;
using System.Net.Http;

using Castle.DynamicProxy;

using WebAnchor.RequestFactory;

namespace WebAnchor.Tests
{
    public class InvocationTester : IInterceptor
    {
        private readonly Action<HttpRequestMessage> _assert;

        private readonly Action<HttpRequestFactory> _configure;

        public InvocationTester(Action<HttpRequestMessage> assert, Action<HttpRequestFactory> configure = null)
        {
            _assert = assert;
            _configure = configure ?? (a => { });
        }

        public void Intercept(IInvocation invocation)
        {
            var factory = new HttpRequestFactory(null);
            _configure(factory);
            var httpRequest = factory.Create(invocation);
            _assert(httpRequest);
        }
    }
}