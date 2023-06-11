using LogStockTickers.Abstractions.Factories;
using LogStockTickers.Abstractions.Messaging;

namespace LogStockTickers.Core.Factories;

public class Factory : IFactory
{
    public Message<T> CreateMessage<T>()
    {
        return new()
        {
            Id = Guid.NewGuid(),
            TimeStamp = DateTime.UtcNow,
        };
    }
}