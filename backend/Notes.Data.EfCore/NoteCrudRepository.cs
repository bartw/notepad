using System;
using System.Threading.Tasks;
using Notes.Domain.Port.Out;

namespace Notes.Data.EfCore
{
    public class NoteCrudRepository : INoteCrudRepository
    {
        private readonly NotesContext _dbContext;

        public NoteCrudRepository(NotesContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Task Create(Domain.Dto.Note note)
        {
            var toAdd = DbModel.Note.From(note);
            _dbContext.Notes.Add(toAdd);
            return _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var toRemove = await FindOrException(id);

            _dbContext.Remove(toRemove);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Domain.Dto.Note note)
        {
            var toUpdate = await FindOrException(note.Id);

            toUpdate.Title = note.Title;
            toUpdate.Content = note.Content;
            await _dbContext.SaveChangesAsync();
        }

        private async Task<DbModel.Note> FindOrException(Guid id)
        {
            var note = await _dbContext.Notes.FindAsync(id);

            if (note == null)
            {
                throw new Exception($"Note with id {id} could not be found.");
            }

            return note;
        }
    }
}
