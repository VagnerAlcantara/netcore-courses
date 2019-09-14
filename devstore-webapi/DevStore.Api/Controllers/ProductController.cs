using System.Web.Http;
using DevStore.Infra.DataContexts;
using System.Net.Http;
using System.Linq;
using DevStore.Domain;
using System.Web.Http.Cors;

namespace DevStore.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/v1/public")]
    public class ProductController : ApiController
    {
        private DevStoreDataContext db = new DevStoreDataContext();

        [Route("products")]
        public HttpResponseMessage GetProducts()
        {
            try
            {
                var result = db.Products.Include("Category").ToList();

                if (result.Count > 0)
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
                else
                    return Request.CreateResponse(System.Net.HttpStatusCode.NoContent);


            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("categories")]
        public HttpResponseMessage GetCategories()
        {
            try
            {
                var result = db.Categories.ToList();

                if (result.Count > 0)
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
                else
                    return Request.CreateResponse(System.Net.HttpStatusCode.NoContent);


            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("categories/{categoryId}/products")]
        public HttpResponseMessage GetProductsByCategory(int categoryId)
        {
            try
            {
                var result = db.Products.Include("Category").Where(x => x.CategoryId == categoryId).ToList();

                if (result.Count > 0)
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, result);
                else
                    return Request.CreateResponse(System.Net.HttpStatusCode.NoContent);


            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("products")]
        public HttpResponseMessage PostProduct(Product product)
        {
            if (product == null)
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);

            try
            {
                db.Products.Add(product);
                db.SaveChanges();

                return Request.CreateResponse(System.Net.HttpStatusCode.Created, product);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, "Falha ao incluir producto " + ex.Message);
            }
        }

        [HttpPatch] // atualizar parte da classe
        [Route("products")]
        public HttpResponseMessage PatchProduct(Product product)
        {
            if (product == null)
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Product>(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, product);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, "Falha ao alterar producto " + ex.Message);
            }
        }

        [HttpPut]
        [Route("products")]
        public HttpResponseMessage PutProduct(Product product)
        {
            if (product == null)
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Product>(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, product);
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, "Falha ao alterar producto " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("products")]
        public HttpResponseMessage DeleteProduct(int productId)
        {
            if (productId <= 0)
                return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);

            try
            {
                db.Products.Remove(db.Products.Find(productId));
                db.SaveChanges();

                return Request.CreateResponse(System.Net.HttpStatusCode.OK, "Produto excluído.");
            }
            catch (System.Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, "Falha ao excluir producto " + ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}