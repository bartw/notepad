using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notes.Domain
{
    public interface INoteQueryRepository
    {
        Task<IEnumerable<Note>> Get();
    }
}