using SQLite; 

namespace ExamenProg3JuanMino.Models
{
    [Table("imagen")]
    public class Imagen
    {
        [PrimaryKey, AutoIncrement]
        public int IdJM { get; set; }

        [MaxLength(30)]
        public string TituloJM { get; set; }

        [MaxLength(30)]
        public string TecnicaJM { get; set; }

        [MaxLength(60)]
        public string DescripcionJM { get; set; }

        public string ImgJM { get; set; }

        public DateTime FechaJM { get; set; } 
    }
}
