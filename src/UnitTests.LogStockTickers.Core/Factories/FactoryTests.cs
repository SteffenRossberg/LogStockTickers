using System;
using FluentAssertions;
using LogStockTickers.Core.Factories;
using Xunit;

namespace UnitTests.LogStockTickers.Core.Factories;

public class FactoryTests
{
    private readonly Func<Factory> _createFactory;

    public FactoryTests()
    {
        _createFactory = () => new Factory();
    }

    [Fact]
    public void Creates_Message()
    {
        // Given
        var sut = _createFactory();
        var timestamp = DateTime.UtcNow;
        
        // When
        var actual = sut.CreateMessage<string>();
        
        // Then
        actual.Id.Should().NotBeEmpty();
        actual.TimeStamp.Should().BeAfter(timestamp);
        actual.TimeStamp.Should().BeBefore(timestamp.AddMilliseconds(10));
    }
}