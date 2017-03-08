using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DemonSeed.Tests
{
    public class SeedProcessorCollectionTests
    {
        private DemonSeed.SeedProcessor _processor;

        public SeedProcessorCollectionTests()
        {
            _processor = new SeedProcessor(new SeedOptions());
        }

        [Fact]
        public void test_collection_seeding()
        {
            var model = _processor.Generate<Models.CollectionTestModel>();

            Assert.NotNull(model);

            Assert.NotNull(model.Friends);

            Assert.Equal<int>(3, model.Friends.Count);

            Assert.NotNull(model.Friends[0].FirstName);

            Assert.NotEqual<string>(string.Empty, model.Friends[0].FirstName);
        }
    }
}
