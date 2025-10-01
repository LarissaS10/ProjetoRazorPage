using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projeto_AT_DotNet.Data;
using Projeto_AT_DotNet.Models;

namespace Projeto_AT_DotNet.Pages.PacotesEF
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Projeto_AT_DotNet.Data.AgenciaContext _context;

        public IndexModel(Projeto_AT_DotNet.Data.AgenciaContext context)
        {
            _context = context;
        }

        public IList<PacoteTuristico> PacoteTuristico { get;set; } = default!;

        public async Task OnGetAsync()
        {
            PacoteTuristico = await _context.PacotesTuristico.ToListAsync();
        }
    }
}
