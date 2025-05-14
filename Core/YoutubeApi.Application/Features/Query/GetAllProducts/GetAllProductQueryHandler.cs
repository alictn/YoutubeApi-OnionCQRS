using MediatR;
using YoutubeApi.Application.Interfaces.UnitOfWorks;
using YoutubeApi.Domain.Entities;

namespace YoutubeApi.Application.Features.Query.GetAllProducts
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, IList<GetAllProductQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllProductQueryHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<IList<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.GetReadRepositories<Product>().GetAllAsync();

            List<GetAllProductQueryResponse> response = new();
            foreach (var product in products)
            {
                response.Add(new GetAllProductQueryResponse
                {
                    Title = product.Title,
                    Description = product.Description,
                    Discount = product.Discount,
                    Price = product.Price - (product.Price * product.Discount / 100),
                });
            }
            return response;
        }
    }
}
