using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projeto_AT_DotNet.Models;

namespace Projeto_AT_DotNet.Pages.Reservas
{
    public class CreateReservaModel : PageModel
    {
        [BindProperty]
        public Reserva Reserva { get; set; }

        public List<Cliente> Clientes { get; set; }
        public List<PacoteTuristico> Pacotes { get; set; }

        private static List<Reserva> _reservasSalvas = new List<Reserva>();
        private static int _nextId = 1;

        public void OnGet()
        {
            Clientes = new List<Cliente>
            {
                new Cliente { Id = 1, Nome = "João Silva"},
                new Cliente { Id = 2, Nome = "Maria Souza"}
            };

            Pacotes = new List<PacoteTuristico>
            {
                new PacoteTuristico { Id = 101, Titulo = "Férias no Nordeste", CapacidadeMaxima = 5 },
                new PacoteTuristico { Id = 102, Titulo = "Amazônia Expedição", CapacidadeMaxima = 5 }
            };

            Reserva = new Reserva();
        }

        public IActionResult OnPost()
        {
            OnGet();

            if (!ModelState.IsValid)
            {
                return Page(); 
            }

            Reserva.Id = _nextId++;
            _reservasSalvas.Add(Reserva);

            TempData["SuccessMessage"] = $"Reserva (ID: {Reserva.Id}) cadastrada com sucesso para o Cliente ID {Reserva.ClienteId}!";

            return RedirectToPage("/Reservas/ListReserva");
        }
    }
}