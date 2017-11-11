using System;
using System.Threading.Tasks;
using Notes.Contracts;

namespace Notes.Domain
{
    public interface INoteCrudRepository
    {
        Task Create(Contracts.Note note);
        Task Update(Contracts.Note note);
        Task Delete(Guid id);
    }
}