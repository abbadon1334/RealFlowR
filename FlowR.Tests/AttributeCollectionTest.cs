using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FlowR.Library.Client.Tags;
using FlowR.Library.Node;
using Newtonsoft.Json;
using NUnit.Framework;

namespace FlowR.Tests
{
    public class AttributeCollectionTest
    {
        private DomNodeAttributes _attributes;
        
        [SetUp]
        public void Setup()
        {
            _attributes = new DomNodeAttributes(new Div());
        }

        [Test]
        public void TestFunctional()
        {
            _attributes.SetAttribute("test","value");
            _attributes.RemoveAttribute("test");
            _attributes.SetAttribute("test", "val");
            _attributes.SetAttribute("test","value");
            
            _attributes.SetAttribute("test2","value");
            _attributes.RemoveAttribute("test2");

            Assert.AreEqual(
                new Dictionary<string, string> {{"test", "value"}},
                _attributes.ToDictionary()
            );
        }
    }
}