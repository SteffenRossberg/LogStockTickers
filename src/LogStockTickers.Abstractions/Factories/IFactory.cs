using LogStockTickers.Abstractions.Messaging;

namespace LogStockTickers.Abstractions.Factories;

public interface IFactory
{
    Message<T> CreateMessage<T>();
}