using AutoMapper;
using Calculator.Application.Models;

namespace Calculator.Application.Services.Implementations.Mappers.AutomapperProfiles
{
    public class CalculateProfile : Profile
    {
        public CalculateProfile()
        {
            this.CreateMap<CalculateDto, OperationCalculateDto>()
                .ForMember(operation => operation.LeftOperand, opts => opts.MapFrom(data => data.LeftOperand))
                .ForMember(operation => operation.RightOperand, opts => opts.MapFrom(data => data.RightOperand));
        }
    }
}
