using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCopuonDto>> GetAllCouponsAsync();
        Task CreateCouponAsync(CreateCopuonDto createCopuonDto);
        Task UpdateCouponAsync(UpdateCopuonDto updateCopuonDto);
        Task DeleteCouponAsync(int id);
        Task GetByIdCouponAsync(int id);
    }
}
