using System;
using System.Collections.Generic;

namespace Database_01.Models;

public partial class Game
{
    public int GameId { get; set; }

    public string? Name { get; set; }

    public string? Genre { get; set; }

    public int? Price { get; set; }

    public DateOnly? ReleaseDate { get; set; }
}
