public class ConsoleOutputCapture : IDisposable
{
    private readonly TextWriter originalOutput;
    private readonly StringWriter consoleOutput;

    public ConsoleOutputCapture()
    {
        originalOutput = Console.Out;
        consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);
    }

    public void Dispose()
    {
        consoleOutput.Dispose();
        Console.SetOut(originalOutput);
    }

    public string GetCapturedOutput()
    {
        return consoleOutput.ToString();
    }
}
