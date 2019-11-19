using System.Collections.Generic;
using FluentAssertions;
using Slack.Webhooks.Blocks;
using Slack.Webhooks.Elements;
using Xunit;

namespace Slack.Webhooks.Tests
{
    public class SectionBlockFixtures
    {
        [Fact]
        public void ShouldSerializeText()
        {
            // arrange
            var textObject = new TextObject { Text = "This is text" };
            var section = new Section { Text = textObject };

            // act
            var textPayload = SlackClient.SerializeObject(textObject);
            var payload = SlackClient.SerializeObject(section);

            // assert
            payload.Should().Contain($"\"text\":{textPayload}");
        }

        [Fact]
        public void ShouldSerializeFields()
        {
            // arrange
            var fieldsList = new List<TextObject> { new TextObject { Text = "This is text" }};
            var section = new Section { Fields = fieldsList };

            // act
            var fieldsPayload = SlackClient.SerializeObject(fieldsList);
            var payload = SlackClient.SerializeObject(section);

            // assert
            payload.Should().Contain($"\"fields\":{fieldsPayload}");
        }

        [Fact]
        public void ShouldSerializeAccessory()
        {
            // arrange
            var accessoryList = new List<Element> { new Button() };
            var section = new Section { Accessory = accessoryList };

            // act
            var accessoryPayload = SlackClient.SerializeObject(accessoryList);
            var payload = SlackClient.SerializeObject(section);

            // assert
            payload.Should().Contain($"\"accessory\":{accessoryPayload}");
        }
    }
}