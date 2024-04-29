using System;

delegate void AccountHandler(string message);
class FirstClass
{
    public event AccountHandler Event;
    private string name;
    public FirstClass(string name)
    {
        this.name = name;
    }
    public void GenerateEvent()
    {
        Event.Invoke(name);
    }
}
class SecondClass
{
    private string name;
    public SecondClass(string name)
    {
        this.name = name;
    }
    public void HandleEvent(string eventName)
    {
        Console.WriteLine($"Событие {eventName} вызван через событие {name}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        var first1 = new FirstClass("номер один");
        var second = new SecondClass("номер два");
        first1.Event += second.HandleEvent;
        first1.GenerateEvent();
    }
}