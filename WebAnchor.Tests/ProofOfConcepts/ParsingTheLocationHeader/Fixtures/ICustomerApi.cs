﻿using System.Threading.Tasks;

using WebAnchor.RequestFactory;
using WebAnchor.RequestFactory.HttpAttributes;
using WebAnchor.RequestFactory.Transformation.Transformers;
using WebAnchor.Tests.ACollectionOfRandomTests.Fixtures;

namespace WebAnchor.Tests.ProofOfConcepts.ParsingTheLocationHeader.Fixtures
{
    [BaseLocation("api/customer")]
    public interface ICustomerApi
    {
        [Post("/extension")]
        Task<CustomerWithLocation> CreateCustomer([Content]Customer customer);
    }
}
