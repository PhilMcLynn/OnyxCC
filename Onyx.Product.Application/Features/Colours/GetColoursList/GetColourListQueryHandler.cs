using AutoMapper;
using MediatR;
using Onyx.Product.Application.Contracts.Persistence;
using Onyx.Product.Domain.Entities;

namespace Onyx.Product.Application.Features.Colours
{
    public class GetColourListQueryHandler : IRequestHandler<GetColourListQuery, List<ColourListVm>>
    {
        private readonly IAsyncRepository<Colour> _colourRepository;
        private readonly IMapper _mapper;

        public GetColourListQueryHandler(IMapper mapper, IAsyncRepository<Colour> colourRepository)
        {
            _mapper = mapper;
            _colourRepository = colourRepository;
        }
        public async Task<List<ColourListVm>> Handle(GetColourListQuery request, CancellationToken cancellationToken)
        {
            var allColours = (await _colourRepository.GetAllAsync());
            return _mapper.Map<List<ColourListVm>>(allColours);
        }
    }
}
