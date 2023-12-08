using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
        }

        //Client tarafına geldiğimizde index sayfasında invoke ile bu metodu çağıracağız. Bu metot içerisinde SendAsync metodu ile verilen ismi de çağır.
        public async Task SendStatistic()
        {
            //Kategori Sayısı
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
            //Ürün Sayısı
            var value2 = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value2);
            //Aktif Kategori Sayısı
            var value3 = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);
            //Pasif Kategori Sayısı
            var value4 = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);
            //Hamburger Kategorisindeki Ürün Sayısı
            var value5 = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", value5);
            //İçecek Kategorisindeki Ürün Sayısı
            var value6 = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value6);
            //Ortalama Fiyat
            var value7 = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value7.ToString("0.00") + "₺");
            //En Pahalı Ürün
            var value8 = _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", value8);
            //En Ucuz Ürün
            var value9 = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice", value9);
            //Ortalama Hamburger Fiyatı
            var value10 = _productService.TProductPriceAvgByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductPriceAvgByCategoryNameHamburger", value10);
            //Toplam Sipariş Sayısı
            var value11 = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value11);
            //Aktif Sipariş Sayısı
            var value12 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value12);
            //Son Sipariş Tutarı
            var value13 = _orderService.TLastOrderTotalPrice();
            await Clients.All.SendAsync("ReceiveLastOrderTotalPrice", value13.ToString("0.00") + "₺");
            // Kasadaki Toplam Tutar
            var value14 = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value14.ToString("0.00") + "₺");
            //Bugünkü Kazanç
            var value15 = _orderService.TTodayTotalPrice();
            await Clients.All.SendAsync("ReceiveTodayTotalPrice", value15.ToString("0.00") + "₺");
            //Masa Sayısı
            var value16 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value16);
        }
        public async Task SendProgress()
        {
            var value = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value.ToString("0.00") + "₺");

            var value2 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value2);

            //Aktif Masa Sayısı
            var value3 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value3);
        }
        public async Task GetBookingList()
        {
            var values = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveBookingList", values);
        }
    }
}
