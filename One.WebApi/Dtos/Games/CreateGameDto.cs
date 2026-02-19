using System.ComponentModel.DataAnnotations;

namespace One.WebApi.Dtos.Games
{
    public record class CreateGameDto
    {
        
        [Required] 
        public string Name { get; set; }

        public string? Genre { get; set; }

        [Required]
        [Range(1,1000)]
        public decimal Price { get; set; }

        public DateOnly? ReleaseDate { get; set; }
       
    }
}
