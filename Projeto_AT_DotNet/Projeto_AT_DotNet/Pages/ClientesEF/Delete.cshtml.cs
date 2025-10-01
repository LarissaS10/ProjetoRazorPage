using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projeto_AT_DotNet.Data;
using Projeto_AT_DotNet.Models;

namespace Projeto_AT_DotNet.Pages.ClientesEF
{
    public class DeleteModel : PageModel
    {
        private readonly Projeto_AT_DotNet.Data.AgenciaContext _context;

        public DeleteModel(Projeto_AT_DotNet.Data.AgenciaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }
            else
            {
                Cliente = cliente;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }
            cliente.IsDeleted = true;

            _context.Clientes.Update(cliente);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
