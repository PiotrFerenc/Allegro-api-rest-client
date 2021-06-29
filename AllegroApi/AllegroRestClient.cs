using System.Threading.Tasks;
using AllegroApi.Repository;
using AllegroApi.Service.Offer;
using Autofac;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace AllegroApi
{
    public class AllegroRestClient
    {
        private IMediator Mediator { get; set; }

        public AllegroRestClient( )
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(AllegroRestClient).Assembly).As(typeof(IApiRepository));
            builder.RegisterAssemblyTypes(typeof(AllegroRestClient).Assembly).As(typeof(IOfferService));
            builder.RegisterMediatR(typeof(AllegroRestClient).Assembly);
            var container = builder.Build();
            
            
            Mediator = container.Resolve<IMediator>();
        }

        public async Task<TResponse> Query<TResponse>(IRequest<TResponse> command)
        {
            var response = await Mediator.Send(command);
            return   response;
        }
    }

  
}