using System;
using System.Collections.Generic;
using System.Text.Json;
using FlowR.Library.Client.Message;
using NUnit.Framework;
using NUnit.Framework.Internal;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace FlowR.Tests
{
    public class MessageEventTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MessageSerializeTest()
        {
            MessageEvent message = new MessageEvent
            {
                Uuid = "testUuid",
                EventName = "eventName"
            };
            
            message.EventArgs.Add("testName", "valueTest");

            string serialized = 
                "{\"Uuid\":\"testUuid\",\"EventName\":\"eventName\",\"EventArgs\":{\"testName\":\"valueTest\"}}";

            Assert.AreEqual(
                serialized,
                message.ToJson()
            );

            MessageEvent deserialized = MessageEvent.FromJson(serialized);
            
            Assert.AreEqual(message.Uuid,deserialized.Uuid);
            Assert.AreEqual(message.EventName,deserialized.EventName);
            Assert.AreEqual(message.EventArgs,deserialized.EventArgs);
        }
    }
}