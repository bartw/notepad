using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.Contracts;

namespace Notes.Domain
{
    public interface INoteQueryRepository
    {
        Task<IEnumerable<Contracts.Note>> Get();
        Task<Contracts.Note> Get(Guid id);
    }
}