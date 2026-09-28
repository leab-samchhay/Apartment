using APARTMENT_API.DTOs.Requests;
using APARTMENT_API.DTOs.Responses;
using APARTMENT_API.Model;
using AutoMapper;

namespace APARTMENT_API.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<BuildingResDto,Building>().ReverseMap();
            CreateMap<BuildingReqDto,Building>().ReverseMap();

            CreateMap<FloorsResDto,Floors>().ReverseMap();
            CreateMap<FloorsReqDto,Floors>().ReverseMap();

            CreateMap<RoomTypeResDto, RoomType>().ReverseMap();
            CreateMap<RoomTypeReqDto, RoomType>().ReverseMap();

            CreateMap<ItemResDto, Item>().ReverseMap();
            CreateMap<ItemReqDto, Item>().ReverseMap();

            CreateMap<PositionResDto, Position>().ReverseMap();
            CreateMap<PositionReqDto, Position>().ReverseMap();

            CreateMap<ExpensTypeResDto, ExpensType>().ReverseMap();
            CreateMap<ExpensTypeReqDto, ExpensType>().ReverseMap();

            CreateMap<OrtherExpenseResDto, OrtherExpense>().ReverseMap();
            CreateMap<OrtherExpenseReqDto , OrtherExpense>().ReverseMap();

            CreateMap<StaffResDto, Staff>().ReverseMap();
            CreateMap<StaffReqDto, Staff>().ReverseMap();

            CreateMap<SalaryResDto, Salary>().ReverseMap();
            CreateMap<SalaryReqDto, Salary>().ReverseMap();

            CreateMap<GuestResDto, Guest>().ReverseMap();
            CreateMap<GuestReqDto, Guest>().ReverseMap();

            CreateMap<PayslipResDto, Payslip>().ReverseMap();
            CreateMap<PayslipReqDto, Payslip>().ReverseMap();

            CreateMap<ApplicationUser, UserResDto>().ReverseMap();

            CreateMap<ApplicationRole, RoleReqDto>().ReverseMap();
            CreateMap<ApplicationRole, RoleResDto>().ReverseMap();

            CreateMap<ApplicationUserRole, UserRoleReqDto>().ReverseMap();
            CreateMap<ApplicationUserRole, UserRoleResDto>().ReverseMap();
            CreateMap<RegisterReqDto, ApplicationUser>().ReverseMap();


            CreateMap<CustomerResDto, Customer>().ReverseMap();
            CreateMap<CustomerReqDto, Customer>().ReverseMap();

        }
    }
}
