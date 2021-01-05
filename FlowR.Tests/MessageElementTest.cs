using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FlowR.Library.Client.Message;
using FlowR.Library.Client.Tags;
using FlowR.Library.Node;
using Newtonsoft.Json;
using NUnit.Framework;

namespace FlowR.Tests
{
    public class MessageElementTest
    {
        private Div _owner = new();
        
        [SetUp]
        public void Setup()
        {
            _owner.Add(new Div());
        }

        [Test]
        public void TestFunctional()
        {
            Assert.AreEqual(
                "",
                Factory.MessageCreate(_owner).ToJson()
            );
        }
    }
}