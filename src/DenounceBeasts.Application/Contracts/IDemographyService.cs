using DenounceBeasts.Application.Dtos.Municipalities;
using DenounceBeasts.Application.Responses;

namespace DenounceBeasts.Application
{
    public interface IDemographyService
    {
        ApiResponse<MunicipalityDto> GetMunicipalityById(int id);
        ApiResponse<List<MunicipalityDto>> GetAllMunicipalities();
        ApiResponse<List<MunicipalitiesWithSector>> GetAllMunicipalitiesWithSectors();
        ApiResponse<MunicipalityDto> CreateMunicipality(MunicipalityDto municipalityRequest);
        ApiResponse<MunicipalityDto> CreateMunicipalityWithSectors(CreateMunicipalityWithSectors request);
        ApiResponse<MunicipalityDto> UpdateMunicipality(int id, MunicipalityDto municipalityRequest);
        ApiResponse<MunicipalityDto> DeleteMunicipality(int id);

    }
}
