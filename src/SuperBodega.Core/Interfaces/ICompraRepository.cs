using SuperBodega.Core.Entities;

namespace SuperBodega.Core.Interfaces;

public interface ICompraRepository : IRepository<Compra>
{
    Task<IEnumerable<Compra>> GetByProveedorAsync(int proveedorId);
    Task<IEnumerable<Compra>> GetByPeriodoAsync(DateTime inicio, DateTime fin);
}
