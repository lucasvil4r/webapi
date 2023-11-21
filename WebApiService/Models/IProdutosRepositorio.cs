using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiService.Models
{
    public interface IProdutosRepositorio
    {
        IEnumerable<Produtos> BuscarTodos();
        Produtos Buscar(int id);
        Produtos Adicionar(Produtos item);
        void Remover(Produtos item);

    }
}
