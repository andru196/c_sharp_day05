using System;
using Markdown.Generator.Core.Markdown;
using Xunit;

namespace Markdown.Generator.Core.Tests
{
    public class MarkdownableTypeTests
    {
        [Fact]
        public void Given_MarkdownableType_When_ClassParameter_Then_ReturnOnlyPublicMethodsTest()
        {
            var mdType = new MarkdownableType(typeof(Sut), null);
            var methods = mdType.GetMethods();
            Assert.NotEmpty(methods);
            Assert.All(methods, x=>Assert.True(x.IsPublic));
        }
        
        [Fact]
        public void Given_MarkdownableType_When_ClassParameter_Then_ReturnOnlyPublicPropertiesTest()
        {
            var mdType = new MarkdownableType(typeof(Sut), null);
            var properties = mdType.GetProperties();
            Assert.NotEmpty(properties);
            Assert.All(properties, x=>Assert.True(x.CanRead));
        }
        
        [Fact]
        public void Given_MarkdownableType_When_ClassParameter_Then_ReturnOnlyPublicFieldsTest()
        {
            var mdType = new MarkdownableType(typeof(Sut), null);
            var fields = mdType.GetFields();
            Assert.NotEmpty(fields);
            Assert.All(fields, x=>Assert.True(x.IsPublic));
        }
    }
    
    public class Sut
    {
        public void PublicMethod(){ }
        private void PrivateMethod(){ }
        public int PublicProperty { get; set; }
        public int PrivateProperty { get; set; }
        public int publicField;
        private int privateField;
    }

}