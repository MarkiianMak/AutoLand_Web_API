using AutoMapper;


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
            CreateMap<CreateReviewModel, Review>();

        }
    }
}
