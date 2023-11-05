public class ConsoleOutputCapture : IDisposable
{
    private readonly StringWriter consoleOutput;

    public ConsoleOutputCapture()
    {
        consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);
    }

    public void Dispose()
    {
        consoleOutput.Dispose();
    }

    public string GetCapturedOutput()
    {
        return consoleOutput.ToString();
    }
}
