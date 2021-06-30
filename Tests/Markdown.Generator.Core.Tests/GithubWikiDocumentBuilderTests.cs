using System;
using System.IO;
using System.Reflection;
using Markdown.Generator.Core.Documents;
using Markdown.Generator.Core.Markdown;
using Xunit;
using Moq;

namespace Markdown.Generator.Core.Tests
{
    public class GithubWikiDocumentBuilderTests
    {
        private Mock<IMarkdownGenerator> _mock;
        public GithubWikiDocumentBuilderTests()
        {
            _mock = new Mock<IMarkdownGenerator>();
            
            _mock.Setup(a => a.Load(It.IsAny<Assembly[]>(), It.IsAny<string>())).Returns(Array.Empty<MarkdownableType>());
            _mock.Setup(a => a.Load(It.IsAny<string>(), It.IsAny<string>())).Returns(Array.Empty<MarkdownableType>());
            _mock.Setup(a => a.Load(It.IsAny<Type[]>())).Returns(Array.Empty<MarkdownableType>());
        }
        
        [Fact]
        public void Given_GithubWikiDocumentBuilder_When_TypesParameter_Then_RunOnceTest()
        {
            _mock.Reset();
            var obj = _mock.Object;
            var builder = new GithubWikiDocumentBuilder<IMarkdownGenerator>(obj);
            var types = new Type[] {typeof(Sut)};
            builder.Generate(types, ".");
            _mock.Verify(x=>x.Load(It.IsAny<Type[]>()), Times.Once());
        }
        
        [Fact]
        public void Given_GithubWikiDocumentBuilder_When_StringsAsParameter_Then_RunOnceTest()
        {
            _mock.Reset();
            var obj = _mock.Object;
            var builder = new GithubWikiDocumentBuilder<IMarkdownGenerator>(obj);
            builder.Generate(Path.Combine("Markdown.Generator.Core.dll"), ".", ".");
            _mock.Verify(x=>x.Load(It.IsAny<string>(), It.IsAny<string>()),
                Times.Once());
        }
        
        [Fact]
        public void Given_GithubWikiDocumentBuilder_When_AssembluAndStringStringAsParameter_Then_RunOnceTest()
        {
            _mock.Reset();
            var obj = _mock.Object;
            var builder = new GithubWikiDocumentBuilder<IMarkdownGenerator>(obj);
            var assemblies = new Assembly[]
                {Assembly.LoadFrom(Path.Combine("Markdown.Generator.Core.dll"))};
            builder.Generate(assemblies, "..", ".");
            _mock.Verify(x=>x.Load(It.IsAny<Assembly[]>(), It.IsAny<string>()),
                Times.Once());
        }
    }
}