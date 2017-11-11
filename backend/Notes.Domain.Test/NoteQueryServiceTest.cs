using System;
using Xunit;
using NSubstitute;
using Notes.Domain;
using Notes.Domain.Dto;
using FluentAssertions;
using System.Threading.Tasks;
using Notes.Domain.Port.In;
using Notes.Domain.Port.Out;
using Notes.Domain.Adapter;

namespace Notes.Domain.Test
{
    public class NoteQueryServiceTest
    {
        private readonly INoteQueryRepository _noteQueryRepository;

        public NoteQueryServiceTest()
        {
            _noteQueryRepository = Substitute.For<INoteQueryRepository>();
        }

        [Fact]
        public async Task CanGet()
        {
            var id = Guid.NewGuid();
            _noteQueryRepository.Get().Returns(new[] { new Note(id, "title", "content") });

            var sut = GetSut();
            var notes = await sut.Get();

            await _noteQueryRepository.Received(1).Get();
            notes.ShouldBeEquivalentTo(new[] { new Note(id, "title", "content") });
        }

        [Fact]
        public async Task GivenAnIdThatDoesNotExist_WhenGet_ThenNullIsReturned()
        {
            var idThatDoesNotExist = Guid.Empty;
            _noteQueryRepository.Get(idThatDoesNotExist).Returns(Task.FromResult<Note>(null));

            var sut = GetSut();
            var note = await sut.Get(idThatDoesNotExist);
            
            await _noteQueryRepository.Received(1).Get(idThatDoesNotExist);
            note.Should().BeNull();
        }

        [Fact]
        public async Task GivenAnExistingId_WhenGet_ThenTheNoteIsReturned()
        {
            var existingId = Guid.NewGuid();
            _noteQueryRepository.Get(existingId).Returns(new Note(existingId, "title", "content"));

            var sut = GetSut();
            var note = await sut.Get(existingId);
            
            await _noteQueryRepository.Received(1).Get(existingId);
            note.ShouldBeEquivalentTo(new Note(existingId, "title", "content"));
        }

        private INoteQueryService GetSut()
        {
            return new NoteQueryService(_noteQueryRepository);
        }
    }
}
