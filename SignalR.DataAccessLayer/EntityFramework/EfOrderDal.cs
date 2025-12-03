using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Where(x => x.Description == "Müşteri Masada").Count();
        }

        public decimal LastOrderTotalPrice()
        {
            using var context = new SignalRContext();
            return context.Orders.Take(1).OrderByDescending(x => x.OrderID).Select(y => y.TotalPrice).FirstOrDefault();
        }

        public decimal TodayTotalPrice()
        {
            using var context = new SignalRContext();
            //return context.Orders.Where(x => x.Description == "Hesap Kapatıldı" && x.Date.Day == DateTime.Now.Day && x.Date.Month == DateTime.Now.Month && x.Date.Year == DateTime.Now.Year).Sum(y => y.TotalPrice);
            return context.Orders.Where(x => x.Date.Date == DateTime.Today).Sum(y => y.TotalPrice);
        }

        public int TotalOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Count();
        }
    }
}
