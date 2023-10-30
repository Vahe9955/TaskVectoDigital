namespace TaskVectoDigital.Models
{
    public class Image
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Effect> Effects { get; set; }
    }
}
