namespace MassTransit.Example.Shared.MessageTypes;

public interface IMessage
{
    public string Text { get; set; }
}