namespace ICMInterop.Shared
{
	/// <summary>
	/// Interface for printing or logging messages from commands or services.
	/// </summary>
	public interface IMessagePrinter
    {
        void Info(string message);
        void Error(string message);
	}
}
