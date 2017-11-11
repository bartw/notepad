using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes.Domain.Port.In
{
    public interface INoteQueryService
    {
        Task<IEnumerable<Dto.Note>> Get();
        Task<Dto.Note> Get(Guid id);
    }
}
