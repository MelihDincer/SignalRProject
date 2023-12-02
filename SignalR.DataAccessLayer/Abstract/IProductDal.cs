using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        //Ürünleri kategori bilgisi ile listeleme metodu imzası
        List<Product> GetProductsWithCategories();
    }
}
