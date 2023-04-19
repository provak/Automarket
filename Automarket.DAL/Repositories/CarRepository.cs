using Automarket.DAL.Interfaces;
using Automarket.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Automarket.DAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _db;

        public CarRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Car entity)
        {
            await _db.Cars.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(Car entity)
        {
            _db.Cars.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<Car> Get(int id)
        {
            return await _db.Cars.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Car> GetByName(string name)
        {
            return await _db.Cars.FirstOrDefaultAsync(c => c.Name == name);
        }

        public Task<List<Car>> Select()
        {
            return _db.Cars.ToListAsync();
        }
    }
}
