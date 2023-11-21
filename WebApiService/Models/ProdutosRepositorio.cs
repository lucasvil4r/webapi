using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiService.Models
{
    
    public class ProdutosRepositorio : IProdutosRepositorio
    {
        DBProdutosEntities ctx = new DBProdutosEntities();

        public Produtos Adicionar(Produtos item)
        {
            ctx.Produtos.Add(item);
            ctx.SaveChanges();
            return item;

        }

        public Produtos Buscar(int id)
        {
            return ctx.Produtos.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Produtos> BuscarTodos()
        {
            return ctx.Produtos;
        }

        public void Remover(Produtos item)
        {
            ctx.Produtos.Remove(item);
            ctx.SaveChanges();
        }
    }
}