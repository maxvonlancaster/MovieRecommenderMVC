namespace MovieRecommenderMVC.DAL.Models
{
    public class PagingModel
    {
        public int PageSize { get; set; }

        public int PageNumber { get; set; }

        public int TotalPages { get; set; }

        public int? SortBy { get; set; }

        public bool? IsDescending { get; set; }

        public int? SearchBy { get; set; }

        public string SearchText { get; set; }
    }
}
