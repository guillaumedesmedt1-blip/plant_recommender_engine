namespace PlantRecommender.Models
{
    public class Plant
    {
        public int Id{get; set; }
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public string Light { get; set; } = "";
        public string Watering { get; set; } = "";
        public string Difficulty { get; set; } = "";
    }
}