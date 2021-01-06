using FlowR.Library.Client.Message;
using FlowR.Library.Client.Tags;
using NUnit.Framework;

namespace FlowR.Tests
{
    public class MessageElementTest
    {
        private readonly Div _owner = new();

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
            child.SetAttribute("nameC", "testC");
            child.RemoveAttribute("nameB");
            child.SetText("testText");
            _owner.Add(child);

            var messageJson = Factory.MessageCreate(child).ToJson();

            Assert.AreEqual(
                "{\"Action\":0,\"OwnerUuid\":\"00000000-0000-0000-0000-000000000000\",\"TagName\":\"div\",\"Attributes\":{\"nameA\":\"testA\",\"nameC\":\"testC\"},\"Text\":\"testText\"}",
                messageJson
            );
        }
    }
}