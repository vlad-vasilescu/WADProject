using System.ComponentModel.DataAnnotations.Schema;

namespace WADProject.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }
    }
}