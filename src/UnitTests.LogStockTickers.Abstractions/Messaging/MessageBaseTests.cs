using System;
using FluentAssertions;
using LogStockTickers.Abstractions.Messaging;
using Xunit;

namespace UnitTests.LogStockTickers.Abstractions.Messaging;

public class MessageBaseTests
{
    [Fact]
    public void Create_MessageBase()
    {
        // Given
        var id = new Guid("03665614-B087-4738-8507-5EAB4E3DDE57");
        var topic = "AMD";
        var timestamp = new DateTime(2023, 6, 7, 23, 59, 59);

        // When
        var sut = new TestMessage()
        {
            Id = id,
            Topic = topic,
            TimeStamp = timestamp,
        };

        // Then
        sut.Id.Should().Be(id);
        sut.Topic.Should().Be(topic);
        sut.TimeStamp.Should().Be(timestamp);
    }

    private class TestMessage : MessageBase { }
}