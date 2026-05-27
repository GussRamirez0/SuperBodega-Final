using Microsoft.EntityFrameworkCore;
using SuperBodega.Core.Entities;
using SuperBodega.Core.Interfaces;
using SuperBodega.Infrastructure.Data;

namespace SuperBodega.Infrastructure.Repositories;

public class ProductoRepository : Repository<Producto>, IProductoRepository
{
    public ProductoRepository(ApplicationDbContext context) : base(context) { }

    public async Task<IEnumerable<Producto>> GetByCategoriaAsync(int categoriaId) =>
        await _context.Productos.Where(p => p.CategoriaId == categoriaId).ToListAsync();

    public async Task<Producto?> GetByCodigoAsync(string codigo) =>
        await _context.Productos.FirstOrDefaultAsync(p => p.Codigo == codigo);

    public async Task<bool> ActualizarStockAsync(int productoId, int cantidad)
    {
        var producto = await _context.Productos.FindAsync(productoId);
        if (producto == null) return false;
        producto.Stock += cantidad;
        await _context.SaveChangesAsync();
        return true;
    }
}
