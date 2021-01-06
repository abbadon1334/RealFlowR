using System.Collections.Generic;
using FlowR.Library.Client.Tags;
using FlowR.Library.Node.Collections;
using NUnit.Framework;

namespace FlowR.Tests
{
    public class AttributeCollectionTest
    {
        private DomNodeCollectionAttribute _collectionAttribute;

        [SetUp]
        public void Setup()
        {
            _collectionAttribute = new DomNodeCollectionAttribute(new Div());
        }

        [Test]
        public void TestFunctional()
        {
            _collectionAttribute.SetAttribute("test", "value");
            _collectionAttribute.RemoveAttribute("test");
            _collectionAttribute.SetAttribute("test", "val");
            _collectionAttribute.SetAttribute("test", "value");

            _collectionAttribute.SetAttribute("test2", "value");
            _collectionAttribute.RemoveAttribute("test2");

            Assert.AreEqual(
                new Dictionary<string, string> {{"test", "value"}},
                _collectionAttribute.ToDictionary()
            );
        }
    }
}