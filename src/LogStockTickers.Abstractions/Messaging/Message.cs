namespace LogStockTickers.Abstractions.Messaging;

public class Message<T> : MessageBase
{
    public T Payload { get; set; } = default!;
}