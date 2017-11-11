using System;
using System.Threading.Tasks;

namespace Notes.Domain
{
    public interface INoteCrudRepository
    {
        Task Create(Note note);
        Task Update(Note note);
        Task Delete(Guid id);
    }
}