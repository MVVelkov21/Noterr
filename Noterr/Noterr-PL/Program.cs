using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Noterr_BLL;
using Noterr_DAL;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=../../../notes.db"))
            .AddScoped<INoteRepository, NoteRepository>()
            .AddScoped<INoteService, NoteService>()
            .BuildServiceProvider();

        var noteService = serviceProvider.GetService<INoteService>();
        
        while (true)
        {
            Console.WriteLine("\n1. View Notes\n2. Add Note\n3. Edit Note\n4. Delete Note\n5. Exit");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var notes = await noteService.GetAllNotesAsync();
                    Console.WriteLine("\nNotes:");
                    foreach (var note in notes)
                        Console.WriteLine($"{note.Id}: {note.Title} ({note.CreatedAt})\n{note.Content}\n");
                    break;

                case "2":
                    Console.Write("\nEnter Title: ");
                    var title = Console.ReadLine();
                    Console.Write("Enter Content: ");
                    var content = Console.ReadLine();
                    await noteService.AddNoteAsync(title, content);
                    Console.WriteLine("Note added.");
                    break;

                case "3":
                    Console.Write("\nEnter Note ID to Edit: ");
                    var editId = int.Parse(Console.ReadLine());
                    Console.Write("Enter New Title: ");
                    var newTitle = Console.ReadLine();
                    Console.Write("Enter New Content: ");
                    var newContent = Console.ReadLine();
                    await noteService.UpdateNoteAsync(editId, newTitle, newContent);
                    Console.WriteLine("Note updated.");
                    break;

                case "4":
                    Console.Write("\nEnter Note ID to Delete: ");
                    var deleteId = int.Parse(Console.ReadLine());
                    await noteService.DeleteNoteAsync(deleteId);
                    Console.WriteLine("Note deleted.");
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
