using System;
using System.ComponentModel.DataAnnotations;

namespace Notes.Data.EfCore.DbModel
{
    public class Note
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        internal static Note From(Domain.Dto.Note note)
        {
            return new Note { Id = note.Id, Title = note.Title, Content = note.Content };
        }

        internal static Domain.Dto.Note To(Note note)
        {
            return new Domain.Dto.Note(note.Id, note.Title, note.Content);
        }
    }
}