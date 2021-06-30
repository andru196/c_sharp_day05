using System;
using Xunit;
using Markdown.Generator.Core.Markdown.Elements;

namespace Markdown.Generator.Core.Tests
{
    
    public class ElementsTests
    {
        [Fact]
        public void Given_Code_When_LanguageAndCodeAsParameter_Then_ReturnMarkdownCodeMarkup()
        {
            var expected = "```csharp\nsome code\n```\n";
            var mdResult = new Code("csharp", "some code").Create();
            Assert.Equal(mdResult, expected);
        }
        
        [Fact]
        public void Given_CodeQuote_When_CodeAsParameter_Then_ReturnMarkdownSingleLineCodeMarkup()
        {
            var expected = "```some code```";
            var mdResult = new CodeQuote("some code").Create();
            Assert.Equal(expected, mdResult);
        }
        
        [Fact]
        public void Given_Header_When_LevelAndHheaderAsParameter_Then_ReturnMarkdownHeaderMarkup()
        {
            var expected = "## header\n";
            var mdResult = new Header(3, "header").Create();
            Assert.Equal(expected, mdResult);
        }
        
        [Fact]
        public void Given_List_When_ItemAsParameter_Then_ReturnMarkdownListMarkup()
        {
            var expected = "- list\n";
            var mdResult = new List("list").Create();
            Assert.Equal(expected, mdResult);
        }
        
        [Fact]
        public void Given_Link_When_TitleAndUrlAsParameter_Then_ReturnMarkdownUrlMarkup()
        {
            var expected = "[title](url)";
            var mdResult = new Link("title","url").Create();
            Assert.Equal(expected, mdResult);
        }
        
        [Fact]
        public void Given_Image_When_TitleAndUrlAsParameter_Then_ReturnMarkdownImageMarkup()
        {
            var expected = "![title](url)";
            var mdResult = new Image("title","url").Create();
            Assert.Equal(expected, mdResult);
        }
    }
}