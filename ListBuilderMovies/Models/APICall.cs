namespace ListBuilderMovies.Models
{
    public class APICall
    {
        public int page { get; set; }
        public Result[] results { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }

    }
    public class Result
    {
        public string poster_path { get; set; }
        public bool adult { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public int[] genre_ids { get; set; }
        public int id { get; set; }
        public string original_title { get; set; }
        public string original_language { get; set; }
        public string title { get; set; }
        public string backdrop_path { get; set; }
        //public string popularity { get; set; }
        public int vote_count { get; set; }
        public bool video { get; set; }
        //public string vote_average { get; set; }
    }
}
