using System.Collections.Generic;

namespace Dio.Series
{
    public interface IRepositorio<T>
    {
        List<T> Lista();

        T RetornaPorId(int id);

        void Insere(T entidade);
        void Exclui(int id);
        void Actualiza(int id, T entidade);
        int ProximoId();

    }
}