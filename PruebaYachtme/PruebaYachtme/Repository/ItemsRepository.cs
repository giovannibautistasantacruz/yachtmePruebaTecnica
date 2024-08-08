using PruebaAxen_CasaBolsa.Data;
using PruebaYachtme.Models;
using PruebaYachtme.Repository.IRepository;

namespace PruebaYachtme.Repository
{
    public class ItemsRepository : Repository<Items>,IItemsRepository
    {
        private readonly ApplicationDbContext _db;

        public ItemsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
