using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projeto_AT_DotNet.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "O nome deve ter no mínimo 5 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido. Ex: nome@dominio.com")]
        [StringLength(100)]
        public string Email { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}