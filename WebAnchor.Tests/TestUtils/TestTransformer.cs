using System;
using System.Collections.Generic;

using WebAnchor.RequestFactory;
using WebAnchor.RequestFactory.Transformation;

namespace WebAnchor.Tests.TestUtils
{
    public class TestTransformer : ParameterListTransformerBase
    {
        private readonly Action<IEnumerable<Parameter>, ParameterTransformContext> _testAction;

        public TestTransformer(Action<IEnumerable<Parameter>, ParameterTransformContext> testAction)
        {
            _testAction = testAction;
        }

        public override IEnumerable<Parameter> TransformParameters(IEnumerable<Parameter> parameters, ParameterTransformContext parameterTransformContext)
        {
            _testAction(parameters, parameterTransformContext);
            return parameters;
        }
    }
}