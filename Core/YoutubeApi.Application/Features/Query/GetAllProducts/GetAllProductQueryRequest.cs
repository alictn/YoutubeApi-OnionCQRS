using MediatR;

namespace YoutubeApi.Application.Features.Query.GetAllProducts
{
    public class GetAllProductQueryRequest : IRequest<IList<GetAllProductQueryResponse>>
    {
    }
}
