using System.ComponentModel.DataAnnotations;

namespace Projeto_AT_DotNet.Models
{
    //Atv 4
    public delegate void LimiteCapacidadeAtingidoHandler(PacoteTuristico pacote);

    public class PacoteTuristico
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título do pacote é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O título deve ter entre 3 e 100 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A data de início é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; } = DateTime.Now.AddDays(1);

        [Required(ErrorMessage = "A capacidade máxima é obrigatória.")]
        [Range(1, 1000, ErrorMessage = "A capacidade deve ser no mínimo 1.")]
        public int CapacidadeMaxima { get; set; }

        [Required(ErrorMessage = "O preço da diária é obrigatório.")]
        [DataType(DataType.Currency)]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal PrecoDiaria { get; set; }

        public ICollection<DestinoPacote> DestinosIncluidos { get; set; } = new List<DestinoPacote>();
        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();  

        public int ParticipantesAtuais { get; set; }

        public event LimiteCapacidadeAtingidoHandler CapacityReached;

        public bool TentarAdicionarParticipante()
        {
            if (ParticipantesAtuais < CapacidadeMaxima)
            {
                ParticipantesAtuais++;
                return true;
            }
            else
            {
                CapacityReached?.Invoke(this);
                return false;
            }
        }
    }
}
