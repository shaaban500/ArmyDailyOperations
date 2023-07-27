using DailyOperations.Domain.Entities.Operations;
using DailyOperations.Domain.Interfaces;
using DailyOperations.Domain.Interfaces.Services.Operations;

namespace DailyOperations.Infrastructure.Services.Operations
{
    public class ShiftTypeServices : IShiftTypeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShiftTypeServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddOrUpdate(ShiftType model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ShiftType>> GetAll()
        {
            var shiftTypes = await _unitOfWork.ShiftTypes.GetAllAsync();
            return shiftTypes.ToList();
        }
    }
}
