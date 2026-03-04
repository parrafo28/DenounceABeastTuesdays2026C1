using AutoMapper;
using DenounceBeasts.API.Models;
using DenounceBeasts.API.Models.Dtos;
using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Infrastructure.Repositories;
using DenounceBeasts.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DenounceBeasts.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MunicipalitiesController : ControllerBase
    {
        //private readonly DenounceBeastsContext _context;
        private readonly IMapper _mapper;
        //private readonly MunicipalityRepository _municipalityRepository;
        //private readonly SectorRepository _sectorRepository;
        private readonly UnitOfWork _unitOfWork;

        public MunicipalitiesController(DenounceBeastsContext context, IMapper mapper,
            //MunicipalityRepository municipalityRepository,
            //SectorRepository sectorRepository, 
            UnitOfWork unitOfWork)
        {
            //this._context = context;
            this._mapper = mapper;
            //this._municipalityRepository = municipalityRepository;
            //this._sectorRepository = sectorRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public ApiResponse<MunicipalityDto> GetById(int id)
        {
            //var municipality = _municipalityRepository.GetById(id);
            var municipality = _unitOfWork.MunicipalityRepository.GetById(id);
            if (municipality == null)
            {
                return ApiResponse<MunicipalityDto>.FailureResponse("Municipality not found.", 404);
            }

            var result = _mapper.Map<MunicipalityDto>(municipality);
            return ApiResponse<MunicipalityDto>.SuccessResponse(result, "Municipality retrieved successfully.");

        }

        [HttpGet]
        public IActionResult Get()
        {
            //var list = _municipalityRepository.GetAll();
            var list = _unitOfWork.MunicipalityRepository.GetAll();

            var response = _mapper.Map<List<MunicipalityDto>>(list);

            return Ok(response);
        }

        [HttpGet("with-sectors")]
        public IActionResult GetAll()
        {
            //var municipalitiesWithSectors = _municipalityRepository.GetMunicipalitiesWithSectors()
            var municipalitiesWithSectors = _unitOfWork.MunicipalityRepository.GetMunicipalitiesWithSectors()
                .Select(m => new MunicipalitiesWithSector()
                {
                    Id = m.Id,
                    Name = m.Name,
                    PostalCode = m.PostalCode,
                    Sectors = m.Sectors
                        .Where(s => s.IsActive)
                        .Select(s => new SectorDto
                        {
                            Id = s.Id,
                            Name = s.Name
                        }).ToList()
                }).ToList();

            return Ok(municipalitiesWithSectors);
        }

        [HttpPost]
        public IActionResult Create(MunicipalityDto municipalityRequest)
        {
            if (string.IsNullOrWhiteSpace(municipalityRequest.Name))
            {
                return BadRequest("Name of municipality is required.");
            }

            var municipality = _mapper.Map<Municipality>(municipalityRequest);
            _unitOfWork.MunicipalityRepository.Add(municipality);
            _unitOfWork.Complete();

            return Ok(new { Id = municipality.Id });

        }

        [HttpPost]
        [Route("create-with-sectors")]
        public IActionResult CreateWithSectors(CreateMunicipalityWithSectors request)
        {

            if (string.IsNullOrWhiteSpace(request.Municipality.Name))
            {
                return BadRequest("Name of municipality is required.");
            }
            var municipality = new Municipality
            {
                Name = request.Municipality.Name,
                PostalCode = request.Municipality.PostalCode,
                //Sectors = request.Sectors.Select(s => new Sector
                //{
                //    Name = s.Name,
                //    PostalCode = s.PostalCode,
                //    IsActive = true
                //}).ToList()
            };
            _unitOfWork.BeginTransaction();
            //_municipalityRepository.Add(municipality);
            _unitOfWork.MunicipalityRepository.Add(municipality);
            foreach (var sectorDto in request.Sectors)
            {
                var sector = new Sector
                {
                    Name = sectorDto.Name,
                    PostalCode = sectorDto.PostalCode,
                    IsActive = true,
                    MunicipalityId = municipality.Id
                };
                //_sectorRepository.AddSector(sector);
                _unitOfWork.SectorRepository.AddSector(sector);
            }
            _unitOfWork.Complete();
            _unitOfWork.CommitTransaction();    
             
            return Ok(new { Id = municipality.Id });


        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, MunicipalityDto municipalityRequest)
        {
            //var existing = _municipalityRepository.GetById(id);
            var existing = _unitOfWork.MunicipalityRepository.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = municipalityRequest.Name;
            existing.PostalCode = municipalityRequest.PostalCode;

            //_municipalityRepository.Update(existing);
            _unitOfWork.MunicipalityRepository.Update(existing);
            _unitOfWork.Complete();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //var existing = _municipalityRepository.GetById(id);
            var existing = _unitOfWork.MunicipalityRepository.GetById(id);
            if (existing == null)
            {
                return NotFound();
            }
            //_municipalityRepository.Delete(id);
            _unitOfWork.MunicipalityRepository.Delete(id);
            _unitOfWork.Complete();

            return NoContent();
        }

    }
}
