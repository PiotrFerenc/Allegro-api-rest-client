using AllegroApi.Domain.Pos;
using AllegroApi.Service.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AllegroApi.Query.Sale
{
    public class GetPosHandler : IRequestHandler<GetPosQuery,Pos>
    {
        private readonly ISaleService _sellerService;

        public GetPosHandler(ISaleService sellerService)
        {
            _sellerService = sellerService;
        }

        public async Task<Pos> Handle(GetPosQuery request, CancellationToken cancellationToken)
        {
            var result = await _sellerService.GetPosListAsync(request.Authorization, request.sellerId);

            return result;
        }
    }
}
