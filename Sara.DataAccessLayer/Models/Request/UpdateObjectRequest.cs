namespace saraproject.Models.Request
{
    public class UpdateObjectRequest
    {
        public string Name { get; set; }

        public string City { get; set; }
        
        public string Street { get; set; }

        public string House { get; set; }

        public string MapCoordinates { get; set; }

        public string Info { get; set; }
    }
}