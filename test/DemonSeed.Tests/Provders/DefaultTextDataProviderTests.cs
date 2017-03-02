using System;
using Xunit;
using DemonSeed.DataProviders.DefaultProviders;

namespace DemonSeed.Tests.Provders
{
    public class DefaultTextDataProviderTests
    {
        private DefaultTextDataProvider _textProvider;

        public DefaultTextDataProviderTests()
        {
            _textProvider = new DefaultTextDataProvider();
        }

        [Fact]
        public void test_get_string()
        {
            string textString = _textProvider.GetWords(12);

            Assert.NotNull(textString);

            Assert.True(textString.Length > 0);
        }

        [Fact]
        public void test_negative_word_count()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(
                () => { _textProvider.GetWords(-1); }
                );
        }

        [Fact]
        public void test_request_for_no_words()
        {
            string result = _textProvider.GetWords(0);

            Assert.Equal<string>(result, string.Empty);
        }

        [Fact]
        public void test_large_word_count_fails()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => 
                {
                    string result = _textProvider.GetWords(int.MaxValue);
                }
            );
        }

        [Fact]
        public void test_get_paragraphs()
        {
            string test = _textProvider.GetParagraphs(3);

            Assert.NotNull(test);

            Assert.True(test.Length > 0);
        }

        [Fact]
        public void test_negative_paragraph_count()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => { _textProvider.GetParagraphs(-1); });
        }

        [Fact]
        public void test_zero_paragraph_count()
        {
            string result = _textProvider.GetParagraphs(0);

            Assert.NotNull(result);

            Assert.Equal<string>(result, string.Empty);
        }

        [Fact]
        public void test_large_paragraph_count_fails()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => { string result = _textProvider.GetParagraphs(int.MaxValue); });
        }
    }
}
