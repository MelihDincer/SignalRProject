using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        //Context sınıfında GenericRepository sınıfında bir constructor oluşturmuşturduk. O zaman burada GenericRepository'den miras alıyorsak bu sınıfta da bir constructor oluşturup orada context sınıfını base aldığımız gibi burada da bunu uygulamalıyız. 
        //Yukarıdaki sebepten dolayı aşağıdaki constructor sınıfı oluşturulmuştur.
        public EfProductDal(SignalRContext context) : base(context)
        {
        }
    }
}
