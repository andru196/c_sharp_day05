using System;
using System.Linq;
using Markdown.Generator.Core.Markdown;
using Markdown.Generator.Core.Markdown.Elements;
using Xunit;

namespace Markdown.Generator.Core.Tests
{
    public class MarkdownBuilderTests
    {
        [Fact]
        public void Given_Builder_When_CodeAsParameter_Then_ReturnSingleElementTest()
        {
            var builder = new MarkdownBuilder();
            builder.Code("csharp", "some code");
            Assert.Single( builder.Elements);
            Assert.Contains(builder.Elements, x => x.GetType() == typeof(Code));
        }
        
        [Fact]
        public void Given_Builder_When_CodeQuoteAsParameter_Then_ReturnSingleElementTest()
        {
            var builder = new MarkdownBuilder();
            builder.CodeQuote("some code");
            Assert.Single(builder.Elements);
            Assert.Contains(builder.Elements, x => x.GetType() == typeof(CodeQuote));
        }
        
        [Fact]
        public void Given_Builder_When_HeaderAsParameter_Then_ReturnSingleElementTest()
        {
            var builder = new MarkdownBuilder();
            builder.Header(3, "some code");
            Assert.Single( builder.Elements);
            Assert.Contains(builder.Elements, x => x.GetType() == typeof(Header));
        }
        [Fact]
        public void Given_Builder_When_ListAsParameter_Then_ReturnSingleElementTest()
        {
            var builder = new MarkdownBuilder();
            builder.List("some code");
            Assert.Single( builder.Elements);
            Assert.Contains(builder.Elements, x => x.GetType() == typeof(List));
        }
        [Fact]
        public void Given_Builder_When_LinkAsParameter_Then_ReturnSingleElementTest()
        {
            var builder = new MarkdownBuilder();
            builder.Link("csharp", "some code");
            Assert.Single(builder.Elements);
            Assert.Contains(builder.Elements, x => x.GetType() == typeof(Link));
        }
        
        [Fact]
        public void Given_Builder_When_ImageAsParameter_Then_ReturnSingleElementTest()
        {
            var builder = new MarkdownBuilder();
            builder.Image("csharp", "some code");
            Assert.Single( builder.Elements);
            Assert.Contains(builder.Elements, x => x.GetType() == typeof(Image));
        }
    }
}