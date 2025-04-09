namespace DomainLayer.TheMilesTours.Entities
{
    public class DestinationGallery
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public Guid DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}