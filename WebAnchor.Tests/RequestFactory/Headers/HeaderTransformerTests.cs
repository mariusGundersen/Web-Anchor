using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using NUnit.Framework;

using WebAnchor.RequestFactory;
using WebAnchor.RequestFactory.HttpAttributes;
using WebAnchor.RequestFactory.Transformation.Transformers.Headers;
using WebAnchor.Tests.TestUtils;

namespace WebAnchor.Tests.RequestFactory.Headers
{
    public class HeaderTransformerTests : WebAnchorTest
    {
        [BaseLocation("location")]
        public interface IApi
        {
            [Get("resource")]
            Task<HttpResponseMessage> Get();
        }

        [Test]
        public void TestAddHeaderTransformer()
        {
            TestTheRequest<IApi>(
                api => api.Get(),
                settings: new ApiSettings1(), 
                assertHttpRequestMessage: request =>
                    {
                        Assert.That(request.Headers.Contains("Authorization"));
                        Assert.AreEqual("Basic 79iou342qkras9", request.Headers.GetValues("Authorization").Single());
                    });
        }

        [Test]
        public void TestAddAuthorizationTransformer()
        {
            TestTheRequest<IApi>(
                api => api.Get(),
                settings: new ApiSettings2(),
                assertHttpRequestMessage: request =>
                    {
                        Assert.That(request.Headers.Contains("Authorization"));
                        Assert.AreEqual("Basic 79iou342qkras9", request.Headers.GetValues("Authorization").Single());
                    });
        }

        public class ApiSettings1 : ApiSettings
        {
            public ApiSettings1()
            {
                ParameterListTransformers.Add(new AddHeaderTransformer("Authorization", "Basic 79iou342qkras9"));
            }
        }

        public class ApiSettings2 : ApiSettings
        {
            public ApiSettings2()
            {
                ParameterListTransformers.Add(new AddAuthorizationTransformer("Basic 79iou342qkras9"));
            }
        }
    }
}