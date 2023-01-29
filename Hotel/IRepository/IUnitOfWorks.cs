using Hotel.Data;
using System;
using System.Threading.Tasks;

namespace Hotel.IRepository
{
    public interface IUnitOfWorks: IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<HotelData> HotelDatas { get; }
        Task Save();
    }
}
