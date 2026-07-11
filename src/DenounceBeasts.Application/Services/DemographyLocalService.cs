using AutoMapper;
using DenounceBeasts.Application.Dtos.Municipalities;
using DenounceBeasts.Application.Dtos.Sectors;
using DenounceBeasts.Application.Responses;
using DenounceBeasts.Domain.Entities;
using DenounceBeasts.Infrastructure.Repositories;
using DenounceBeasts.Persistence;

namespace DenounceBeasts.Application.Services
{
    public class DemographyLocalService: IDemographyService
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public DemographyLocalService(DenounceBeastsContext context, IMapper mapper,
            UnitOfWork unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public ApiResponse<MunicipalityDto> GetMunicipalityById(int id)
        {
            var result = new MunicipalityDto();
            return ApiResponse<MunicipalityDto>.SuccessResponse(result);

        }

        public ApiResponse<List<MunicipalityDto>> GetAllMunicipalities()
        {
            var list = _unitOfWork.MunicipalityRepository.GetAll();

            var response = _mapper.Map<List<MunicipalityDto>>(list);

            return ApiResponse<List<MunicipalityDto>>.SuccessResponse(response);
        }

        public ApiResponse<List<MunicipalitiesWithSector>> GetAllMunicipalitiesWithSectors()
        {
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

            return ApiResponse<List<MunicipalitiesWithSector>>.SuccessResponse(municipalitiesWithSectors);
        }

        public ApiResponse<MunicipalityDto> CreateMunicipality(MunicipalityDto municipalityRequest)
        {
            if (string.IsNullOrWhiteSpace(municipalityRequest.Name))
            {
                return ApiResponse<MunicipalityDto>.FailureResponse("Name of municipality is required.");
            }

            var municipality = _mapper.Map<Municipality>(municipalityRequest);
            _unitOfWork.MunicipalityRepository.Add(municipality);
            _unitOfWork.Complete();

            return ApiResponse<MunicipalityDto>.SuccessResponse(municipalityRequest, "Municipality created successfully.");

        }

        public ApiResponse<MunicipalityDto> CreateMunicipalityWithSectors(CreateMunicipalityWithSectors request)
        {

            if (string.IsNullOrWhiteSpace(request.Municipality.Name))
            {
                return ApiResponse<MunicipalityDto>.FailureResponse("Name of municipality is required.");
            }
            var municipality = new Municipality
            {
                Name = request.Municipality.Name,
                PostalCode = request.Municipality.PostalCode,
            };
            _unitOfWork.BeginTransaction();
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
                _unitOfWork.SectorRepository.AddSector(sector);
            }
            _unitOfWork.Complete();
            _unitOfWork.CommitTransaction();

            return ApiResponse<MunicipalityDto>.SuccessResponse(request.Municipality);


        }

        public ApiResponse<MunicipalityDto> UpdateMunicipality(int id, MunicipalityDto municipalityRequest)
        {
            var existing = _unitOfWork.MunicipalityRepository.GetById(id);
            if (existing == null)
            {
                return ApiResponse<MunicipalityDto>.FailureResponse("Municipality not found.");
            }

            existing.Name = municipalityRequest.Name;
            existing.PostalCode = municipalityRequest.PostalCode;

            _unitOfWork.MunicipalityRepository.Update(existing);
            _unitOfWork.Complete();

            return ApiResponse<MunicipalityDto>.SuccessResponse(municipalityRequest);
        }


        public ApiResponse<MunicipalityDto> DeleteMunicipality(int id)
        {
            var existing = _unitOfWork.MunicipalityRepository.GetById(id);
            if (existing == null)
            {
                return ApiResponse<MunicipalityDto>.FailureResponse("Municipality not found.");
            }
            _unitOfWork.MunicipalityRepository.Delete(id);
            _unitOfWork.Complete();

            return ApiResponse<MunicipalityDto>.SuccessResponse();
        }

    }
}
