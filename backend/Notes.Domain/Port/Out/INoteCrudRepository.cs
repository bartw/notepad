using System;
using System.Threading.Tasks;

namespace Notes.Domain.Port.Out
{
    public interface INoteCrudRepository
    {
        Task Create(Dto.Note note);
        Task Update(Dto.Note note);
        Task Delete(Guid id);
    }
}