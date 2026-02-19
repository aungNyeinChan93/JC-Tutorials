namespace One.WebApi.Dtos.Games
{
    public record class GameDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Genre { get; set; }

        public decimal Price { get; set; }

        public DateOnly? ReleaseDate { get; set; }
        //public GameDto(int Id, string Name, string Genre, decimal Price, DateOnly ReleaseDate)
        //{
        //    this.Id = Id;
        //    this.Name = Name;
        //    this.Genre = Genre;
        //    this.Price = Price;
        //    this.ReleaseDate = ReleaseDate;
        //}
    }

    //public record class GameDto(int Id, string Name, string Genre, decimal Price, DateOnly ReleaseDate);
}
