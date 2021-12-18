using System;
using System.Threading;
using System.Threading.Tasks;
using AllegroApi.Domain.AllegroProduct;
using AllegroApi.Helpers;
using AllegroApi.Query.AllegroOffer;
using AllegroApi.Service.Interfaces;
using MediatR;

namespace AllegroApi.Handler.AllegroOffer
{
    public class GetProductsByNameHandler : IRequestHandler<GetProductsByNameQuery, (AllegroProduct products, Product
        bestProductByName)>
    {
        private readonly IOfferService _offerService;

        public GetProductsByNameHandler(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public async Task<(AllegroProduct products, Product bestProductByName)> Handle(GetProductsByNameQuery request,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                throw new ArgumentNullException(nameof(request.Name));
            }

            var products = await _offerService.GetProducts(request.Authorization, request.Name);

            var bestProduct = new Product();
            var rate = 0;

            foreach (var product in products.Products)
            {
                var currentRate = request.Name.DamerauLevenshteinDistanceTo(product.Name);

                if (currentRate > rate)
                {
                    rate = currentRate;
                    bestProduct = product;
                }
            }

            return (products, bestProduct);
        }
    }
}