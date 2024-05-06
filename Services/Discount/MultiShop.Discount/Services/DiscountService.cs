using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCouponAsync(CreateCopuonDto createCopuonDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCopuonDto.Code);
            parameters.Add("@rate", createCopuonDto.Rate);
            parameters.Add("@isActive", createCopuonDto.IsActive);
            parameters.Add("@validDate", createCopuonDto.ValidDate);

            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "Delete From Coupons where Coupon Id=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("couponId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async Task<List<ResultCopuonDto>> GetAllCouponsAsync()
        {
            string query = "Select * From Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCopuonDto>(query);
                return values.ToList();
            }
        }

        public async Task GetByIdCouponAsync(int id)
        {
            string query = "Select * From Coupons Where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdCopuonDto>(query);
            }

        }

        public async Task UpdateCouponAsync(UpdateCopuonDto updateCopuonDto)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId ";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCopuonDto.Code);
            parameters.Add("@rate", updateCopuonDto.Rate);
            parameters.Add("@isActive", updateCopuonDto.IsActive);
            parameters.Add("@validDate", updateCopuonDto.ValidDate);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
    }
}
