using AdvancedProgramming_Lesson1.Models;
using AdvancedProgramming_Lesson1.Models.Bookstore;
using Microsoft.EntityFrameworkCore;

namespace AdvancedProgramming_Lesson1.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
        : base(options)
        {
        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<ksiazka> Ksiazka { get; set;}
        public DbSet<Genre>genres { get; set; }
        public DbSet<Author> author { get; set; }
    }
}
