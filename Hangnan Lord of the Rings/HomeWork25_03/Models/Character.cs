namespace Models
{
    public class Character
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Skills { get; set; } = new();
    }
}