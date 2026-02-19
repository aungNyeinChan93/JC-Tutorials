namespace One.WebApi.Dtos.Games
{
    public class UpdateGameDto
    {

        public string? Name { get; set; }

        public string? Genre { get; set; }

        public decimal Price { get; set; }

        public DateOnly? ReleaseDate { get; set; }
    }
}
