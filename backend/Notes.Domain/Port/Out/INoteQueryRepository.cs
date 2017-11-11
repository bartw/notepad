using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes.Domain.Port.Out
{
    public interface INoteQueryRepository
    {
        Task<IEnumerable<Dto.Note>> Get();
        Task<Dto.Note> Get(Guid id);
    }
}