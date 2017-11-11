using System;
using Xunit;
using Notes.Domain.Port.Out;
using Notes.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using System.Threading.Tasks;

namespace Notes.Data.EfCore.Test
{
    public class NoteCrudRepositoryTest
    {
        private readonly DbContextOptions<NotesContext> _options;

        public NoteCrudRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<NotesContext>()
                            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                            .Options;
        }

        [Fact]
        public async Task GivenANote_WhenCreate_ThenANoteIsCreated()
        {
            var id = Guid.NewGuid();

            using (var dbContext = GetFreshDbContext())
            {
                var note = new Domain.Dto.Note(id, "title", "content");

                var sut = GetSut(dbContext);
                await sut.Create(note);
            }

            using (var dbContext = GetFreshDbContext())
            {
                var createdNote = await dbContext.Notes.FirstAsync();
                createdNote.ShouldBeEquivalentTo(new DbModel.Note { Id = id, Title = "title", Content = "content" });
            }
        }

        private NotesContext GetFreshDbContext()
        {
            return new NotesContext(_options);
        }

        private INoteCrudRepository GetSut(NotesContext dbContext)
        {
            return new NoteCrudRepository(dbContext);
        }
    }
}
