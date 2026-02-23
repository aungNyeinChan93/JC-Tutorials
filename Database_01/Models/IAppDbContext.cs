using Microsoft.EntityFrameworkCore;

namespace Database_01.Models
{
    public interface IAppDbContext
    {
        DbSet<Game> Games { get; set; }
    }
}