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

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Domain.Dto.Note note)
        {
            throw new NotImplementedException();
        }
    }
}
