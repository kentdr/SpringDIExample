namespace SpringDIDemo
{
  public class MyMessageHandler : IHandleMessages<MyMessage>
  {
    private readonly IWriteToConsole consoleWriter;

    /// <summary>
    /// You can see that IWriteToConsole is resolved by Spring using the xml configuration.
    /// </summary>
    public MyMessageHandler(IWriteToConsole consoleWriter)
    {
      this.consoleWriter = consoleWriter;
    }

    public Task Handle(MyMessage message, IMessageHandlerContext context)
    {
      consoleWriter.WriteLine($"Handling message {message.Number}");

      return Task.CompletedTask;
    }
  }
}
