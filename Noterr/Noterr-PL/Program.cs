using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Noterr_BLL;
using Noterr_DAL;

class Program
{
    static async Task Main(string[] args)
    {
        // Set up dependency injection
        var serviceProvider = new ServiceCollection()
            .AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=notes.db"))
            .AddScoped<INoteRepository, NoteRepository>()
            .AddScoped<INoteService, NoteService>()
            .BuildServiceProvider();

        var noteService = serviceProvider.GetService<INoteService>();

        while (true)
        {
            Console.WriteLine("1. Add Note");
            Console.WriteLine("2. View Notes");
            Console.WriteLine("3. Exit");

            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Enter title: ");
                    var title = Console.ReadLine();
                    Console.Write("Enter content: ");
                    var content = Console.ReadLine();
                    await noteService.AddNoteAsync(new Note { Title = title, Content = content, CreatedAt = DateTime.Now });
                    Console.WriteLine("Note added!");
                    break;
                case "2":
                    var notes = await noteService.GetAllNotesAsync();
                    foreach (var note in notes)
                    {
                        Console.WriteLine($"ID: {note.Id}, Title: {note.Title}, Content: {note.Content}, Created At: {note.CreatedAt}");
                    }
                    break;
                case "3":
                    return;
            }
        }
    }
}