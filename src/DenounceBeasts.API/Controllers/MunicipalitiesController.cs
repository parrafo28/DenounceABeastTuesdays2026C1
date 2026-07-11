using DenounceBeasts.Application;
using DenounceBeasts.Application.Dtos.Municipalities;
using DenounceBeasts.Application.Responses;
using DenounceBeasts.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MunicipalitiesController : ControllerBase
    {
        private readonly IDemographyService _demographyService;


        public MunicipalitiesController(IDemographyService demographyService)
        {
            this._demographyService = demographyService;
        }

        [HttpGet("{id}")]
        public ApiResponse<MunicipalityDto> GetById(int id)
        {
            return _demographyService.GetMunicipalityById(id);
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var response = _demographyService.GetAllMunicipalities();
        //    return Ok(response);
        //}

        [HttpGet]
        public ApiResponse<List<MunicipalityDto>> Get() => _demographyService.GetAllMunicipalities();

        [HttpGet("with-sectors")]
        public IActionResult GetAll() => Ok(_demographyService.GetAllMunicipalitiesWithSectors());

        [HttpPost]
        public IActionResult Create(MunicipalityDto municipalityRequest) => Ok(_demographyService.CreateMunicipality(municipalityRequest));

        [HttpPost]
        [Route("create-with-sectors")]
        public IActionResult CreateWithSectors(CreateMunicipalityWithSectors request) => Ok(_demographyService.CreateMunicipalityWithSectors(request));

        [HttpPut("{id}")]
        public IActionResult Update(int id, MunicipalityDto municipalityRequest) => Ok(_demographyService.UpdateMunicipality(id, municipalityRequest));

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) => Ok(_demographyService.DeleteMunicipality(id));

    }
}
