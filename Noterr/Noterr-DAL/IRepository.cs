using System.Collections.Generic;
using System.Threading.Tasks;

namespace Noterr_DAL
{
    public interface INoteRepository
    {
        Task<Note> GetNoteByIdAsync(int id);
        Task<IEnumerable<Note>> GetAllNotesAsync();
        Task AddNoteAsync(Note note);
        Task UpdateNoteAsync(Note note);
        Task DeleteNoteAsync(int id);
    }
}