using LogStockTickers.Abstractions.Messaging;

namespace LogStockTickers.Abstractions.Processing;

public interface IProcessor
{
    string Process<T>(Message<T> message);

    void Start(CancellationToken cancellationToken);
}