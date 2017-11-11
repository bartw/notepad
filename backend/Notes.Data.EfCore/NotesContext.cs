using System;
using Microsoft.EntityFrameworkCore;

namespace Notes.Data.EfCore
{
    public class NotesContext : DbContext
    {
        public DbSet<DbModel.Note> Notes { get; set; }
        
        public NotesContext(DbContextOptions<NotesContext> options)
            : base(options)
        {
        }
    }
}