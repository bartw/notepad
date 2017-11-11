using System;
using Xunit;
using NSubstitute;
using Notes.Contracts;
using Notes.Domain;
using FluentAssertions;
using System.Threading.Tasks;

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
            notes.ShouldBeEquivalentTo(new[] { new Contracts.Note(id, "title", "content") });
        }

        private INoteQueryService GetSut()
        {
            return new NoteQueryService(_noteQueryRepository);
        }
    }
}
