namespace randomdotNET.FactoryPattern;

public class EmailNotifier : INotify
{
    public string Notify(string message)
    {
        return $"Email sent :  {message}";
    }
}