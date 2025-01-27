namespace randomdotNET.FactoryPattern;

public class SmsNotifier : INotify
{
    public string Notify(string message)
    {
        return $"Sms sent :  {message}";
    }
}