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

        [Fact]
        public async Task GivenANoteWithAnIdThatAlreadyExists_WhenCreate_ThenAnExceptionIsThrown()
        {
            var id = await CreateNote();

            using (var dbContext = GetFreshDbContext())
            {
                var note = new Domain.Dto.Note(id, "title", "content");

                var sut = GetSut(dbContext);
                Func<Task> create = async () => await sut.Create(note);
                create.ShouldThrow<ArgumentException>().WithMessage($"An item with the same key has already been added. Key: {id}");
            }
        }

        [Fact]
        public void GivenANonExistingNote_WhenUpdate_ThenAnExceptionIsThrown()
        {
            var id = Guid.NewGuid();

            using (var dbContext = GetFreshDbContext())
            {
                var note = new Domain.Dto.Note(id, "title", "content");

                var sut = GetSut(dbContext);
                Func<Task> update = async () => await sut.Update(note);

                update.ShouldThrow<Exception>().WithMessage($"Note with id {id} could not be found.");
            }
        }

        [Fact]
        public async Task GivenANote_WhenUpdate_ThenTheNoteIsUpdated()
        {
            var id = await CreateNote();

            using (var dbContext = GetFreshDbContext())
            {
                var note = new Domain.Dto.Note(id, "newTitle", "newContent");
                var sut = GetSut(dbContext);
                await sut.Update(note);
            }

            using (var dbContext = GetFreshDbContext())
            {
                var updatedNote = await dbContext.Notes.FirstAsync();
                updatedNote.ShouldBeEquivalentTo(new DbModel.Note { Id = id, Title = "newTitle", Content = "newContent" });
            }
        }

        [Fact]
        public void GivenANonExistingId_WhenDelete_ThenAnExceptionIsThrown()
        {
            var id = Guid.NewGuid();

            using (var dbContext = GetFreshDbContext())
            {
                var sut = GetSut(dbContext);
                Func<Task> delete = async () => await sut.Delete(id);

                delete.ShouldThrow<Exception>().WithMessage($"Note with id {id} could not be found.");
            }
        }

        [Fact]
        public async Task GivenAnExistingId_WhenDelete_ThenTheNoteIsDeleted()
        {
            var id = await CreateNote();

            using (var dbContext = GetFreshDbContext())
            {
                var sut = GetSut(dbContext);
                await sut.Delete(id);
            }

            using (var dbContext = GetFreshDbContext())
            {
                dbContext.Notes.Should().BeEmpty();
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

        private INoteCrudRepository GetSut(NotesContext dbContext)
        {
            return new NoteCrudRepository(dbContext);
        }
    }
}
