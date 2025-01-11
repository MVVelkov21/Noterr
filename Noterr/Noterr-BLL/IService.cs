namespace Noterr_BLL
{
    public interface INoteService
    {
        Task<List<Note>> GetAllNotesAsync();
        Task<Note> GetNoteByIdAsync(int id);
        Task AddNoteAsync(string title, string content);
        Task UpdateNoteAsync(int id, string title, string content);
        Task DeleteNoteAsync(int id);
    }
}