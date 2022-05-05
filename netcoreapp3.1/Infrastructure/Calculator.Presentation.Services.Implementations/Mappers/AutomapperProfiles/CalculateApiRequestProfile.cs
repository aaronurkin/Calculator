using AutoMapper;
using Calculator.Application.Models;
using Calculator.Presentation.Models;

namespace Calculator.Presentation.Services.Implementations.Mappers.AutomapperProfiles
{
    public class CalculateApiRequestProfile : Profile
    {
        public CalculateApiRequestProfile()
        {
            this.CreateMap<CalculateApiRequest, OperationCalculateDto>()
                .ForMember(dto => dto.LeftOperand, opts => opts.MapFrom(request => request.LeftOperand))
                .ForMember(dto => dto.RightOperand, opts => opts.MapFrom(request => request.RightOperand));
        }
    }
}
