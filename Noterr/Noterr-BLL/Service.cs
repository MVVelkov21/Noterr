using Noterr_DAL;

namespace Noterr_BLL
{
    public class NoteService : INoteService
    {
        private readonly INoteRepository _repository;
        
        public NoteService(INoteRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<List<Note>> GetAllNotesAsync()
        {
            var notes = await _repository.GetAllNotesAsync();
            return notes.Select(n => new Note
            {
                Id = n.Id,
                Title = n.Title,
                Content = n.Content,
                CreatedAt = n.CreatedAt
            }).ToList();
        }
        
        public async Task<Note> GetNoteByIdAsync(int id)
        {
            var note = await _repository.GetNoteByIdAsync(id);
            if (note == null) return null;

            return new Note
            {
                Id = note.Id,
                Title = note.Title,
                Content = note.Content,
                CreatedAt = note.CreatedAt
            };
        }
        
        public async Task AddNoteAsync(string title, string content)
        {
            var dalNote = new Noterr_DAL.Note
            {
                Title = title,
                Content = content,
                CreatedAt = DateTime.Now
            };

            await _repository.AddNoteAsync(dalNote);
        }
        
        public async Task UpdateNoteAsync(int id, string title, string content)
        {
            var note = await _repository.GetNoteByIdAsync(id);
            if (note != null)
            {
                note.Title = title;
                note.Content = content;
                await _repository.UpdateNoteAsync(note);
            }
        }
        
        public Task DeleteNoteAsync(int id)
        {
            return _repository.DeleteNoteAsync(id);
        }
    }
}
