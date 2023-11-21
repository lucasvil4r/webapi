using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiService.Models;

namespace WebApiService.Controllers
{
    public class ProdutosController : ApiController
    {
        static readonly IProdutosRepositorio repositorio = new ProdutosRepositorio();

        public IEnumerable<Produtos> GetAllProducts()
        {
            return repositorio.BuscarTodos();
        }
        public Produtos GetProduct(int id)
        {
            Produtos item = repositorio.Buscar(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
        public HttpResponseMessage PostProduct(Produtos item)
        {
            item = repositorio.Adicionar(item);
            var response = Request.CreateResponse<Produtos>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void DeleteProduct(int id)
        {
            Produtos item = repositorio.Buscar(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repositorio.Remover(item);
        }

    }
}
