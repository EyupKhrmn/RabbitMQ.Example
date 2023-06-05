namespace MassTransit.Example.Shared.RequestResponsePatternMessage;

public record RequestMessage
{
    public int MessageNo { get; set; }
    public string Text { get; set; }
}