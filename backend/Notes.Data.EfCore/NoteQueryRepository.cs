using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.Domain.Dto;
using Notes.Domain.Port.Out;

namespace Notes.Data.EfCore
{
    public class NoteQueryRepository : INoteQueryRepository
    {
        public Task<IEnumerable<Note>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Note> Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
