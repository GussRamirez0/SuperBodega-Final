using Microsoft.EntityFrameworkCore;
using SuperBodega.Core.Entities;
using SuperBodega.Core.Interfaces;
using SuperBodega.Infrastructure.Data;

namespace SuperBodega.Infrastructure.Repositories;

public class VentaRepository : Repository<Venta>, IVentaRepository
{
    public VentaRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Venta>> GetByClienteAsync(int clienteId) =>
        await _context.Ventas.Include(v => v.Detalles).Where(v => v.ClienteId == clienteId).ToListAsync();

    public async Task<IEnumerable<Venta>> GetByPeriodoAsync(DateTime inicio, DateTime fin) =>
        await _context.Ventas.Include(v => v.Cliente).Where(v => v.Fecha >= inicio && v.Fecha <= fin).ToListAsync();

    public async Task<bool> CambiarEstadoAsync(int ventaId, string nuevoEstado)
    {
        var venta = await _context.Ventas.FindAsync(ventaId);
        if (venta == null) return false;
        venta.Estado = nuevoEstado;
        await _context.SaveChangesAsync();
        return true;
    }
}
