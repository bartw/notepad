using System;
using Xunit;
using Notes.Domain.Port.Out;
using Notes.Data.EfCore;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using System.Threading.Tasks;

namespace Notes.Data.EfCore.Test
{
    public class NoteQueryRepositoryTest
    {
        private readonly DbContextOptions<NotesContext> _options;

        public NoteQueryRepositoryTest()
        {
            _options = new DbContextOptionsBuilder<NotesContext>()
                            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                            .Options;
        }

        [Fact]
        public async Task GivenNoNotes_WhenGet_ThenAnEmptyListIsReturned()
        {
            using (var dbContext = GetFreshDbContext())
            {
                var sut = GetSut(dbContext);
                var notes = await sut.Get();

                notes.Should().BeEmpty();
            }
        }

        [Fact]
        public async Task GivenSomeNotes_WhenGet_ThenTheseNotesAreReturned()
        {
            var id1 = await CreateNote();
            var id2 = await CreateNote();

            using (var dbContext = GetFreshDbContext())
            {
                var sut = GetSut(dbContext);
                var notes = await sut.Get();

                notes.Should().HaveCount(2).And.OnlyContain(n => n.Id == id1 || n.Id == id2);
            }
        }

        [Fact]
        public async Task GivenANonExistingId_WhenGet_ThenNullIsReturned()
        {
            using (var dbContext = GetFreshDbContext())
            {
                var sut = GetSut(dbContext);
                var note = await sut.Get(Guid.NewGuid());

                note.Should().BeNull();
            }
        }

        [Fact]
        public async Task GivenAnExistingId_WhenGet_ThenTheNoteIsReturned()
        {
            var id = await CreateNote();

            using (var dbContext = GetFreshDbContext())
            {
                var sut = GetSut(dbContext);
                var note = await sut.Get(id);

                note.Id.Should().Be(id);
            }
        }

        private async Task<Guid> CreateNote()
        {
            var id = Guid.NewGuid();

            using (var dbContext = GetFreshDbContext())
            {
                dbContext.Notes.Add(new DbModel.Note { Id = id, Title = "title", Content = "content" });
                await dbContext.SaveChangesAsync();
            }

            return id;
        }

        private NotesContext GetFreshDbContext()
        {
            return new NotesContext(_options);
        }

        private INoteQueryRepository GetSut(NotesContext dbContext)
        {
            return new NoteQueryRepository(dbContext);
        }
    }
}
