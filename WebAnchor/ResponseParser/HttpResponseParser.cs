﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Castle.DynamicProxy;

namespace WebAnchor.ResponseParser
{
    public class HttpResponseParser : IHttpResponseParser
    {
        private readonly IList<IResponseHandler> _responseHandlers;

        public HttpResponseParser(IList<IResponseHandler> responseHandlers)
        {
            _responseHandlers = responseHandlers;
        }

        public virtual void ValidateApi(Type type)
        {
        }

        public virtual void Parse(Task<HttpResponseMessage> httpResponseMessage, IInvocation invocation)
        {
            var handler = _responseHandlers.First(x => x.CanHandle(httpResponseMessage, invocation));
            if (handler == null)
            {
                throw new WebAnchorException($"Return type of method {invocation.Method.Name} in {invocation.Method.DeclaringType.FullName} cannot be handled by any of the registered response handlers.");
            }
            else
            {
                handler.Handle(httpResponseMessage, invocation);
            }
        }
    }
}