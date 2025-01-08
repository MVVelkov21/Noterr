using System.Collections.Generic;
using System.Threading.Tasks;
using Noterr_DAL;

namespace Noterr_BLL
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task<Note> GetNoteByIdAsync(int id)
        {
            return await _noteRepository.GetNoteByIdAsync(id);
        }

        public async Task<IEnumerable<Note>> GetAllNotesAsync()
        {
            return await _noteRepository.GetAllNotesAsync();
        }

        public async Task AddNoteAsync(Note note)
        {
            await _noteRepository.AddNoteAsync(note);
        }

        public async Task UpdateNoteAsync(Note note)
        {
            await _noteRepository.UpdateNoteAsync(note);
        }

        public async Task DeleteNoteAsync(int id)
        {
            await _noteRepository.DeleteNoteAsync(id);
        }
    }
}