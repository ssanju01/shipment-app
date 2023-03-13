namespace ShipmentApp.Domain.Models
{
    public class FilterModel
    {
        public int Limit { get; set; }
        public string Author { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
    }
}
