﻿using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using Xunit;


namespace IdentityServer.UnitTests.Stores
{
    public class InMemoryResourcesStoreTests
    {
        [Fact]
        public void InMemoryResourcesStore_should_throw_if_contains_duplicate_names()
        {
            List<IdentityResource> identityResources = new List<IdentityResource>
            {
                new IdentityResource { Name = "A" },
                new IdentityResource { Name = "A" },
                new IdentityResource { Name = "C" }
            };

            List<ApiResource> apiResources = new List<ApiResource>
            {
                new ApiResource { Name = "B" },
                new ApiResource { Name = "B" },
                new ApiResource { Name = "C" }
            };

            Assert.Throws(typeof(ArgumentException), () => new InMemoryResourcesStore(identityResources, null));
            Assert.Throws(typeof(ArgumentException), () => new InMemoryResourcesStore(null, apiResources));
        }

        [Fact]
        public void InMemoryResourcesStore_should_not_throw_if_does_not_contains_duplicate_names()
        {
            List<IdentityResource> identityResources = new List<IdentityResource>
            {
                new IdentityResource { Name = "A" },
                new IdentityResource { Name = "B" },
                new IdentityResource { Name = "C" }
            };

            List<ApiResource> apiResources = new List<ApiResource>
            {
                new ApiResource { Name = "A" },
                new ApiResource { Name = "B" },
                new ApiResource { Name = "C" }
            };

            new InMemoryResourcesStore(identityResources, null);
            new InMemoryResourcesStore(null, apiResources);
        }
    }
}
