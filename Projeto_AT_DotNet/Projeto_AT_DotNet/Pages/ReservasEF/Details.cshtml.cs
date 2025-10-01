using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projeto_AT_DotNet.Data;
using Projeto_AT_DotNet.Models;

namespace Projeto_AT_DotNet.Pages.ReservasEF
{
    public class DetailsModel : PageModel
    {
        private readonly Projeto_AT_DotNet.Data.AgenciaContext _context;

        public DetailsModel(Projeto_AT_DotNet.Data.AgenciaContext context)
        {
            _context = context;
        }

        public Reserva Reserva { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reserva = await _context.Reservas.FirstOrDefaultAsync(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }
            else
            {
                Reserva = reserva;
            }
            return Page();
        }
    }
}
