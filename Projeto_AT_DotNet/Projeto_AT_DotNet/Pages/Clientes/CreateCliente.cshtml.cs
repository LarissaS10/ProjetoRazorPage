using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projeto_AT_DotNet.Models;

namespace Projeto_AT_DotNet.Pages.Clientes
{
    public class CreateClienteModel : PageModel
    {
        [BindProperty]
        public Cliente Cliente { get; set; }

        private static List<Cliente> _clientesSalvos = new List<Cliente>
        {
            new Cliente { Id = 1, Nome = "João Silva", Email = "joao.silva@exemplo.com"},
            new Cliente { Id = 2, Nome = "Maria Souza", Email = "maria.souza@exemplo.com"}
        };
        private static int _nextId = 3; 

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Cliente.Id = _nextId++;
            _clientesSalvos.Add(Cliente);

            TempData["SuccessMessage"] = $"Cliente '{Cliente.Nome}' cadastrado com sucesso! (ID: {Cliente.Id}).";

            return RedirectToPage("./ListCliente");
        }

        public IActionResult OnGet()
        {
            Cliente = new Cliente();
            return Page();
        }
    }
}