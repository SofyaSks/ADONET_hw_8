using System;
using System.Collections.Generic;

namespace MusicDb;

public partial class Song
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? Rating { get; set; }

    public int Weight { get; set; }

    public int Duration { get; set; }

    public DateTime Date { get; set; }

    public virtual ICollection<SongArtist> SongArtists { get; set; } = new List<SongArtist>();

    public override string ToString()
    {
        return $"{Title} ";
    }
}
