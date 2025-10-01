using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projeto_AT_DotNet.Models;

namespace Projeto_AT_DotNet.Pages.Pacotes
{
    public class CreatePacoteTuristicoModel : PageModel
    {
        [BindProperty]
        public PacoteTuristico PacoteTuristico { get; set; }

        private static List<PacoteTuristico> _pacotesSalvos = new List<PacoteTuristico>();
        private static int _nextId = 1;

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); 
            }

            PacoteTuristico.Id = _nextId++;
            _pacotesSalvos.Add(PacoteTuristico);

            TempData["SuccessMessage"] = $"Pacote '{PacoteTuristico.Titulo}' cadastrado com sucesso! (ID: {PacoteTuristico.Id}).";
            return RedirectToPage("./ListPacoteTuristico"); 
        }

        public IActionResult OnGet()
        {
            PacoteTuristico = new PacoteTuristico();
            return Page();
        }
    }
}