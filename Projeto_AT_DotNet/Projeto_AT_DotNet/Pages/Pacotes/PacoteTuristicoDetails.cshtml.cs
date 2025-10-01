using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projeto_AT_DotNet.Models;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_AT_DotNet.Pages.Pacotes
{
    public class PacoteTuristicoDetailsModel : PageModel
    {
        public PacoteTuristico Pacote { get; set; }

        private static List<PacoteTuristico> _pacotesDisponiveis = new List<PacoteTuristico>
        {
            new PacoteTuristico { Id = 1, Titulo = "Nordeste", CapacidadeMaxima = 10, DataInicio = System.DateTime.Now.AddDays(5), PrecoDiaria = 500.00m },
            new PacoteTuristico { Id = 2, Titulo = "Bahia", CapacidadeMaxima = 4, DataInicio = System.DateTime.Now.AddDays(10), PrecoDiaria = 350.50m },
            new PacoteTuristico { Id = 3, Titulo = "Europa", CapacidadeMaxima = 20, DataInicio = System.DateTime.Now.AddMonths(2), PrecoDiaria = 750.00m }
        };

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound("ID do Pacote Turístico não fornecido.");
            }

            Pacote = _pacotesDisponiveis.FirstOrDefault(p => p.Id == id);

            if (Pacote == null)
            {
                return NotFound($"Pacote Turístico com ID {id} não encontrado.");
            }

            return Page();
        }
    }
}