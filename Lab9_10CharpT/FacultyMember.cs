using System;

public class FacultyMember
{
    public string Name { get; }

    // Подія
    public event EventHandler<string> FacultyEvent;

    public FacultyMember(string name)
    {
        Name = name;
    }

    // Метод для створення події
    public void RaiseEvent(string message)
    {
        Console.WriteLine($"🔔 {Name} оголошує подію: {message}");
        FacultyEvent?.Invoke(this, message);
    }

    // Метод для обробки події
    public void OnFacultyEvent(object sender, string message)
    {
        var initiator = (sender as FacultyMember)?.Name ?? "Хтось";
        Console.WriteLine($"👀 {Name} почув подію від {initiator}: {message}");
    }
}
