﻿using System.Collections.Generic;
using Newtonsoft.Json;

using WebAnchor.RequestFactory;
using WebAnchor.RequestFactory.Transformation;
using WebAnchor.RequestFactory.Transformation.Transformers.Default;
using WebAnchor.ResponseParser;

namespace WebAnchor
{
    public class ApiSettings : ISettings
    {
        public ApiSettings()
        {
            ParameterListTransformers = new DefaultParameterListTransformers();
            ResponseHandlers = new DefaultResponseHandlers();
            ContentSerializer = new ContentSerializer(new JsonSerializer());
        }

        public virtual List<IParameterListTransformer> ParameterListTransformers { get; set; }
        public virtual List<IResponseHandler> ResponseHandlers { get; set; }
        public virtual IContentSerializer ContentSerializer { get; set; }

        public IHttpRequestFactory GetRequestFactory()
        {
            return new HttpRequestFactory(ContentSerializer, ParameterListTransformers);
        }

        public IHttpResponseParser GetResponseParser()
        {
            return new HttpResponseParser(ResponseHandlers);
        }
    }
}