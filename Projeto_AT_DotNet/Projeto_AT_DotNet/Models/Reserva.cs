using System;
using System.ComponentModel.DataAnnotations;

namespace Projeto_AT_DotNet.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A data da reserva é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataReserva { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O Cliente é obrigatório.")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O Pacote Turístico é obrigatório.")]
        public int PacoteTuristicoId { get; set; }

        public Cliente Cliente { get; set; }
        public PacoteTuristico PacoteTuristico { get; set; }
    }
}