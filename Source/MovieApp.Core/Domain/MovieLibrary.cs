using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MovieApp.Core.Domain
{
    /// <summary>
    /// Represents a movie library domain
    /// </summary>
    public partial class MovieLibrary : BaseEntity
    {
        public int Total { get; set; }

        [JsonPropertyName("entries")]
        public List<Movie> Movies { get; set; }
    }

    public class Movie
    {
        public int ItemIndex { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ProgramType { get; set; }

        [JsonPropertyName("images")]
        public Image Image { get; set; }

        public int ReleaseYear { get; set; }
    }

    public partial class Image
    {
        [JsonPropertyName("Poster Art")]
        public PosterArt PosterArt { get; set; }
    }

    public partial class PosterArt
    {
        public string Url { get; set; }
        public int Width { get; set; }

        public int Height { get; set; }
    }
}

