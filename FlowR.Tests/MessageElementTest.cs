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
        }

        [Test]
        public void TestFunctional()
        {
            var child = new Div();
            child.SetAttribute("nameA", "testA");
            child.SetAttribute("nameB", "testB");
            child.SetText("testText");
            _owner.Add(child);
            
            var MessageJson = Factory.MessageCreate(child).ToJson();
            
            Assert.AreEqual(
                "{\"Action\":0,\"OwnerUuid\":\"00000000-0000-0000-0000-000000000000\",\"TagName\":\"div\",\"Attributes\":{\"nameA\":\"testA\",\"nameB\":\"testB\"},\"Text\":\"testText\"}",
                MessageJson
            );
        }
    }
}