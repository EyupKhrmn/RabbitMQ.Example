﻿using MassTransit.Example.Shared.MessageTypes;

namespace MassTransit.Example.Consumer.Consumers;

public class ExampleMessageConsumer : IConsumer<IMessage>
{
    public Task Consume(ConsumeContext<IMessage> context)
    {
        Console.WriteLine($"Gelen mesaj: {context.Message.Text}");

        return Task.CompletedTask;
    }
}