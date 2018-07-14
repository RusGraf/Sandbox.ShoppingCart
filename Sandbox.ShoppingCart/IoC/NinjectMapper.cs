using AutoMapper;
using Ninject;
using Ninject.Modules;
using Sandbox.ShoppingCart.Clients;
using Sandbox.ShoppingCart.Models;
using Sandbox.ShoppingCart.Repositories;
using Sandbox.ShoppingCart.Wrappers;

namespace Sandbox.ShoppingCart.IoC
{
    public class NinjectMapper : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();

            //TODO: implement ninject conventions
            Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<IMongoDbClient>().To<MongoDbClient>();
            Bind<ICartRepository>().To<CartRepository>();
            Bind<ISessionStateWrapper>().To<SessionStateWrapper>();
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IBsonMapper>().To<BsonMapper>();
        }

        private IMapper AutoMapper(Ninject.Activation.IContext context)
        {
            Mapper.Initialize(config =>
            {
                config.ConstructServicesUsing(type => context.Kernel.Get(type));

                config.CreateMap<Cart, PurchaseOrder>()
                    .ForMember(dest => dest._id, opt => opt.Ignore())
                    .ForMember(dest => dest.PurchaseItems, opt => opt.MapFrom(src => src.Products));

                config.CreateMap<CartProduct, PurchaseItem>()
                    .ForMember(dest => dest.QtyOrdered, opt => opt.MapFrom(src => src.QuantityToOrder))
                    .ForSourceMember(src => src._id, opt => opt.Ignore());
                
                //TODO: finish this
                //config.CreateMap<Product, CartProduct>()
                //.ForMember(dest => dest.QuantityToOrder, opt => opt.UseDestinationValue(1))
            });

            Mapper.AssertConfigurationIsValid(); // optional
            return Mapper.Instance;
        }
    }
}