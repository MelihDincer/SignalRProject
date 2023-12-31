﻿using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        //Context sınıfında GenericRepository sınıfında bir constructor oluşturmuşturduk. O zaman burada GenericRepository'den miras alıyorsak bu sınıfta da bir constructor oluşturup orada context sınıfını base aldığımız gibi burada da bunu uygulamalıyız. 
        //Yukarıdaki sebepten dolayı aşağıdaki constructor sınıfı oluşturulmuştur.
        public EfCategoryDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveCategoryCount()
        {
            using var context = new SignalRContext();
            return context.Categories.Count(x => x.CategoryStatus == true);
        }

        public int CategoryCount()
        {
            using var context = new SignalRContext();
            return context.Categories.Count();
        }

        public int PassiveCategoryCount()
        {
            using var context = new SignalRContext();
            return context.Categories.Count(x => x.CategoryStatus == false);
        }
    }
}
