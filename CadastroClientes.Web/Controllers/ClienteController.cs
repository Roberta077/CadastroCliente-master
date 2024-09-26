using CadastroClientes.Domain.Entities;
using CadastroClientes.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
 
namespace CadastroClientes.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly CadastroClientesDbContext _context;
 
        public ClienteController(CadastroClientesDbContext context)
        {
            _context = context;
        }
 
        public async Task<IActionResult> Index()
        {
            var clientes = await _context.Clientes.Include(c => c.Enderecos).ToListAsync();
            return View(clientes);
        }
 
        public IActionResult Create()
        {
            return View();
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }
    }
}
 
 