using System;
using System.Collections.Generic;

namespace MusicDb;

public partial class Artist
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<SongArtist> SongArtists { get; set; } = new List<SongArtist>();

    public override string ToString()
    {
        return $"{Name}";
    }
}
