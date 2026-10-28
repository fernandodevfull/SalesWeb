
using Microsoft.EntityFrameworkCore;
using SalesWebMVC.Models;


namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext? _context;

        public SellerService(SalesWebMVCContext? context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context!.Sellers.ToList();

        }

        public void Insert(Seller obj)
        {
            _context!.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Sellers          
                .FirstOrDefault(obj => obj.Id == id)!;
        }

        public void Remove(int id)
        {
            var obj = _context!.Sellers.Find(id);
            _context.Sellers.Remove(obj!);
            _context.SaveChanges();
        }

    }
}
