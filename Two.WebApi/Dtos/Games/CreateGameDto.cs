namespace Two.WebApi.Dtos.Games
{
    public class CreateGameDto
    {
        public string? Name { get; set; } = string.Empty;

        public string? Genre { get; set; } = null;

        public int? Price { get; set; } = 0;

        public DateOnly? ReleaseDate { get; set; } 
    }
}
