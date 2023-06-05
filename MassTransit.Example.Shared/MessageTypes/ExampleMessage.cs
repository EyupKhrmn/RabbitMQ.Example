namespace MassTransit.Example.Shared.MessageTypes;

public class ExampleMessage : IMessage
{
    public string Text { get; set; }
}