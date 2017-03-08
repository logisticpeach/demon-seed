using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DemonSeed.Tests
{
    public class SeedProcessorNameTests
    {
        private DemonSeed.SeedProcessor _processor;

        public SeedProcessorNameTests()
        {
            _processor = new SeedProcessor(new SeedOptions());
        }

        [Fact]
        public void test_first_name_generation()
        {
            var simpleUser = _processor.Generate<Models.FlatTestModel>();

            Assert.NotNull(simpleUser);

            Assert.NotNull(simpleUser.FirstName);

            Assert.NotEqual<string>(string.Empty, simpleUser.FirstName);
        }

        [Fact]
        public void test_last_name_generation()
        {
            var simpleUser = _processor.Generate<Models.FlatTestModel>();

            Assert.NotNull(simpleUser);

            Assert.NotNull(simpleUser.LastName);

            Assert.NotEqual<string>(string.Empty, simpleUser.LastName);
        }

        [Fact]
        public void test_full_name_generation()
        {
            var simpleUser = _processor.Generate<Models.FlatTestModel>();

            Assert.NotNull(simpleUser);

            Assert.NotNull(simpleUser.FullName);

            Assert.NotEqual<string>(string.Empty, simpleUser.FullName);
        }
    }
}
