using AutoMapper;
using Calculator.Application.Models;

namespace Calculator.Application.Services.Implementations.Mappers.AutomapperProfiles
{
    public class CalculateResultProfile : Profile
    {
        public CalculateResultProfile()
        {
            this.CreateMap<OperationCalculateResult, CalculateResultDto>()
                .ForMember(result => result.Value, opts => opts.MapFrom(operationResult => operationResult.Value));
        }
    }
}
