using System;
using System.Collections.Generic;
using FluentAssertions;
using LogStockTickers.Abstractions.Messaging;
using LogStockTickers.Core.Messaging;
using Xunit;

namespace UnitTests.LogStockTickers.Core.Messaging;

public class MessageBusTests
{
    private readonly Func<MessageBus> _createMessageBus;

    public MessageBusTests()
    {
        _createMessageBus = () => new MessageBus();
    }

    [Fact]
    public void Dispatches_message_to_subscribers()
    {
        // Given
        var sut = _createMessageBus();
        var amd1 = new List<Message<string>>();
        var amd2 = new List<Message<string>>();
        var nvda1 = new List<Message<int>>();
        var amd1Subscription = sut.Subscribe<string>("AMD").Subscribe(amd1.Add);
        var amd2Subscription = sut.Subscribe<string>("AMD").Subscribe(amd2.Add);
        var nvda1Subscription = sut.Subscribe<int>("NVDA").Subscribe(nvda1.Add);
        var amdMessage01 = new Message<string> { Topic = "AMD", };
        var amdMessage02 = new Message<string> { Topic = "AMD", };
        var amdMessage03 = new Message<string> { Topic = "AMD", };
        var nvdaMessage01 = new Message<int> { Topic = "NVDA", };
        var nvdaMessage02 = new Message<int> { Topic = "NVDA", };
        sut.Publish(amdMessage01);
        amd1Subscription.Dispose();
        sut.Publish(amdMessage02);
        amd2Subscription.Dispose();
        sut.Publish(nvdaMessage01);
        nvda1Subscription.Dispose();
        sut.Publish(nvdaMessage02);
        
        // When
        sut.Publish(amdMessage03);

        // Then
        amd1.Should().HaveCount(1);
        amd1.Should().Contain(amdMessage01);
        amd1.Should().NotContain(amdMessage02);
        amd1.Should().NotContain(amdMessage03);
        amd2.Should().HaveCount(2);
        amd2.Should().Contain(amdMessage01);
        amd2.Should().Contain(amdMessage02);
        amd1.Should().NotContain(amdMessage03);
        nvda1.Should().HaveCount(1);
        nvda1.Should().Contain(nvdaMessage01);
    }
}