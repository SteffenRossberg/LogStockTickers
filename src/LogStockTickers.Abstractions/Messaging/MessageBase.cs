namespace LogStockTickers.Abstractions.Messaging;

public class MessageBase
{
    protected MessageBase()
    {
    }
    
    public Guid Id { get; set; } 
    
    public DateTime TimeStamp { get; set; }
    
    public string Topic { get; set; } = default!;
    
}