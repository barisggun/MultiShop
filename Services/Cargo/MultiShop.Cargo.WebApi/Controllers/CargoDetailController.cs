using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Business.Abstract;
using MultiShop.Cargo.Dto.Dtos.CargoDetailDto;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _CargoDetailService;

        public CargoDetailController(ICargoDetailService CargoDetailService)
        {
            _CargoDetailService = CargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _CargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail CargoDetail = new CargoDetail()
            {
               Barcode = createCargoDetailDto.Barcode,
               CargoCompanyId = createCargoDetailDto.CargoCompanyId,
               RecieverCustomer = createCargoDetailDto.RecieverCustomer,
               SenderCustomer = createCargoDetailDto.SenderCustomer
            };

            _CargoDetailService.TInsert(CargoDetail);
            return Ok("Kargo detayları oluşturuldu");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail CargoDetail = new CargoDetail()
            {
                Barcode = updateCargoDetailDto.Barcode,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
                RecieverCustomer = updateCargoDetailDto.RecieverCustomer,
                SenderCustomer = updateCargoDetailDto.SenderCustomer,
                CargoDetailId = updateCargoDetailDto.CargoDetailId
            };

            _CargoDetailService.TUpdate(CargoDetail);

            return Ok("Kargo detayları güncellendi");
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _CargoDetailService.TDelete(id);
            return Ok("Kargo detayları silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _CargoDetailService.TGetById(id);
            return Ok(value);
        }

    }
}
