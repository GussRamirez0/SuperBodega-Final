using SuperBodega.Core.Entities;

namespace SuperBodega.Core.Interfaces;

public interface IProductoRepository : IRepository<Producto>
{
    Task<IEnumerable<Producto>> GetByCategoriaAsync(int categoriaId);
    Task<Producto?> GetByCodigoAsync(string codigo);
    Task<bool> ActualizarStockAsync(int productoId, int cantidad);
}
