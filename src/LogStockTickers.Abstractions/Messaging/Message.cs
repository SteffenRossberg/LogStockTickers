namespace LogStockTickers.Abstractions.Messaging;

public class Message<T>
{
    public Guid Id { get; set; } 
    
    public DateTime TimeStamp { get; set; }
    
    public string Topic { get; set; } = default!;

    public T Payload { get; set; } = default!;
}