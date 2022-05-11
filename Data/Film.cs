using System.ComponentModel.DataAnnotations;

namespace swi2gruppe1.Data
{
    public class Film
    {
        public int Id { get; set; }

        public string? Name { get; set; }


        [Range(0, 10, ErrorMessage = "Bewertung geht von 1 bis 10")]
        public int Rating { get; set; }

        public string? Feeling { get; set; }

        public string? Bild { get; set; }
        public string? Vorschau { get; set; }
    }
}