

namespace DAL.Model
{
    public class Wine
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Date { get; set; }
        public string? Place { get; set; }
        public string? Categorie { get; set; }
        public int DetailId { get; set; }

    }
}
