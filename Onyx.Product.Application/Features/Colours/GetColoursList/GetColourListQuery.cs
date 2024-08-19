using MediatR;

namespace Onyx.Product.Application.Features.Colours
{
    public class GetColourListQuery : IRequest<List<ColourListVm>>
    {
    }
}
