using SuperBodega.Core.Entities;

namespace SuperBodega.Core.Interfaces;

public interface IVentaRepository : IRepository<Venta>
{
    Task<IEnumerable<Venta>> GetByClienteAsync(int clienteId);
    Task<IEnumerable<Venta>> GetByPeriodoAsync(DateTime inicio, DateTime fin);
    Task<bool> CambiarEstadoAsync(int ventaId, string nuevoEstado);
}
