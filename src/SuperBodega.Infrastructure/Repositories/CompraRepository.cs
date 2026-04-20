using Microsoft.EntityFrameworkCore;
using SuperBodega.Core.Entities;
using SuperBodega.Core.Interfaces;
using SuperBodega.Infrastructure.Data;

namespace SuperBodega.Infrastructure.Repositories;

public class CompraRepository : Repository<Compra>, ICompraRepository
{
    public CompraRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Compra>> GetByProveedorAsync(int proveedorId) =>
        await _context.Compras.Include(c => c.Detalles).Where(c => c.ProveedorId == proveedorId).ToListAsync();

    public async Task<IEnumerable<Compra>> GetByPeriodoAsync(DateTime inicio, DateTime fin) =>
        await _context.Compras.Include(c => c.Proveedor).Where(c => c.Fecha >= inicio && c.Fecha <= fin).ToListAsync();
}
