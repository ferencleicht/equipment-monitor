namespace Api.Interfaces;

public interface IMessageHandler<TMessage> where TMessage : class
{
    Task HandleAsync(TMessage message);
}