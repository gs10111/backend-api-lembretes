namespace WebApplication4.Models
{
    public class DatabaseSettings
    {
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
        public string? CategoriesCollectionName{ get; set; }
        public string? ProductsCollectionName { get; set; }
        public string? RemindersCollectionName { get; set; }
    }
}
