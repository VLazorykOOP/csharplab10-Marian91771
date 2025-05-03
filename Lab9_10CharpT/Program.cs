using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        // Створюємо учасників факультету
        FacultyMember ivan = new FacultyMember("Іван (викладач)");
        FacultyMember petro = new FacultyMember("Петро (студент)");
        FacultyMember olena = new FacultyMember("Олена (студент)");

        // Підписуємо слухачів на події
        ivan.FacultyEvent += petro.OnFacultyEvent;
        ivan.FacultyEvent += olena.OnFacultyEvent;

        petro.FacultyEvent += ivan.OnFacultyEvent;
        petro.FacultyEvent += olena.OnFacultyEvent;

        // Запускаємо події у багатозадачному режимі
        Task task1 = Task.Run(() => ivan.RaiseEvent("Пари скасовані!"));
        Task task2 = Task.Run(() => petro.RaiseEvent("Хтось забув заліковку!"));

        // Очікуємо завершення обох
        Task.WaitAll(task1, task2);

        Console.WriteLine("\n✅ Завершено. Натисніть клавішу...");
        Console.ReadKey();
    }
}
