namespace PetShop.Core.Filtering
{
    public class Filter
    {
        public int Limit { get; set; }
        public int Page { get; set; }
        public string OrderDir { get; set; }
        public string OrderBy { get; set; }
    }
}