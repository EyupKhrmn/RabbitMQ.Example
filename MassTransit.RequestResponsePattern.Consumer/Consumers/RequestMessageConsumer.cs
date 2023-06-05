using MassTransit.Example.Shared.RequestResponsePatternMessage;

namespace MassTransit.RequestResponsePattern.Consumer.Consumers;

public class RequestMessageConsumer : IConsumer<RequestMessage>
{
    public Task Consume(ConsumeContext<RequestMessage> context)
    {
        Console.WriteLine(context.Message.Text);
        context.RespondAsync<ResponseMessage>(new() { Text = $"{context.Message.MessageNo}. Response" });
        return Task.CompletedTask;
    }
}