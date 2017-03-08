using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DemonSeed.Tests
{
    public class SeedProcessorRecursionTests
    {
        private SeedProcessor _seedProcessor;

        public SeedProcessorRecursionTests()
        {
            _seedProcessor = new SeedProcessor(new SeedOptions());
        }

        [Fact]
        public void test_basic_recursion()
        {
            var nestedUsers = _seedProcessor.Generate<Models.SimpleRecursionTestModel>();

            Assert.NotNull(nestedUsers.BestFriend);

            Assert.NotNull(nestedUsers.BestFriend.FirstName);

            Assert.NotEqual<string>(string.Empty, nestedUsers.BestFriend.FirstName);
        }

        [Fact]
        public void test_detect_recursive_cycles()
        {
            var exception = Assert.Throws<OverflowException>(() => {
                var widget = _seedProcessor.Generate<Models.CyclicRecursionTestModel>();
            });
        }
    }
}
