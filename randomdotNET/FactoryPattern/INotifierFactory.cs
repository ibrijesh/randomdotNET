namespace randomdotNET.FactoryPattern;

public interface INotifierFactory
{
    INotify CreateNotifier(string type);
}