namespace randomdotNET.FactoryPattern;

public class NotifierFactory(IServiceProvider serviceProvider) : INotifierFactory
{
    public INotify CreateNotifier(string type)
    {
        return type.ToLower() switch
        {
            "email" => serviceProvider.GetRequiredService<EmailNotifier>(),
            "sms" => serviceProvider.GetRequiredService<SmsNotifier>(),
            _ => throw new ArgumentException("Invalid NotifierType")
        };
    }
}