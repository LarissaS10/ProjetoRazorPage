using System.ComponentModel.DataAnnotations;

namespace Projeto_AT_DotNet.Models
{
    public class Destino
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O nome do país é obrigatório.")]
        public string Pais { get; set; }

        public ICollection<DestinoPacote> PacotesAssociados { get; set; } = new List<DestinoPacote>();
    }
}
