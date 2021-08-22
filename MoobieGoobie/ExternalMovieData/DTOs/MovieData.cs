namespace ExternalMovieData.DTOs
{
    public class MovieData
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int RuntimeMinutes { get; set; }
        public string Rating { get; set; }
        public string ReleaseDate { get; set; } //TODO: use datetime format?
    }
}
