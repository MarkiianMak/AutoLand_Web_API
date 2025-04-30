using AutoMapper;
using WebApplication1;


namespace AutoLand_API
{
    public class MapperProfile : Profile
    {
        public MapperProfile() {
            CreateMap<CreateUserModel, User>();
            CreateMap<CreateCarModel, Car>();
            CreateMap<CreateInsuranceModel, Insurance>();
            CreateMap<CreatePaymentModel, Payment>();
            CreateMap<CreateRentModel, Rent>();
            CreateMap<CreateCarReviewModel, Review>();
            CreateMap<CreateUserReviewModel, Review>();
            CreateMap<Car, CarDto>();
            CreateMap<Review, ReviewDto>();
            CreateMap<Rent,CRentDto>();
            CreateMap<Rent, URentDto>();
            CreateMap<User, UserDto>();
        }
    }
}
