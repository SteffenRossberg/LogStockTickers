using System.Collections.Concurrent;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using LogStockTickers.Abstractions.Messaging;

namespace LogStockTickers.Core.Messaging;

public class MessageBus : IMessageBus
{
    public void Publish<T>(Message<T> message)
    {
        if (_subscriptions.TryGetValue(message.Topic, out var subject))
        {
            subject.OnNext(message);
        }
    }

    public IObservable<Message<T>> Subscribe<T>(string topic)
        => _subscriptions
            .GetOrAdd(topic, _ => new Subject<MessageBase>())
            .OfType<Message<T>>();

    private readonly ConcurrentDictionary<string, ISubject<MessageBase>> _subscriptions = new();
}