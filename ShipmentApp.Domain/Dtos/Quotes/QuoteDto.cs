namespace ShipmentApp.Domain.Dtos.Quotes
{
    public class QuoteDto
    {
        public string _id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public int Length { get; set; }
        public string DateAdded { get; set; }
        public string DateModified { get; set; }
    }
}
