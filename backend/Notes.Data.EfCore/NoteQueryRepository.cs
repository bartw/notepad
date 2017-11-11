using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.Domain.Port.Out;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Notes.Data.EfCore
{
    public class NoteQueryRepository : INoteQueryRepository
    {
        private readonly NotesContext _dbContext;

        public NoteQueryRepository(NotesContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Domain.Dto.Note>> Get()
        {
            var notes = await _dbContext.Notes.ToArrayAsync();
            return notes.Select(n => DbModel.Note.To(n));
        }

        public async Task<Domain.Dto.Note> Get(Guid id)
        {
            var note = await _dbContext.Notes.FindAsync(id);
            return note == null ? null : DbModel.Note.To(note);
        }
    }
}
