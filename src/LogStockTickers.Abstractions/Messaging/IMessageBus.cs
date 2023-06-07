namespace LogStockTickers.Abstractions.Messaging;

public interface IMessageBus
{
    void Publish<T>(Message<T> message);
    
    IObservable<Message<T>> Subscribe<T>(string topic);
    
    void Unsubscribe(string topic);
}