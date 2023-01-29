using Hotel.Data;
using Hotel.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Hotel.Repository
{
    public class UniteOfWorks : IUnitOfWorks
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<Country> _countries;
        private IGenericRepository<HotelData> _hotelData;

        public UniteOfWorks(DatabaseContext context)
        {
            _context = context;
        }

        public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_context);

        public IGenericRepository<HotelData> HotelDatas => _hotelData ??= new GenericRepository<HotelData>(_context);

        public void Dispose()
        {
           _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
