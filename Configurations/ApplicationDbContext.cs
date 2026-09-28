using APARTMENT_API.Model;
using APARTMENT_API.Models;
using Microsoft.EntityFrameworkCore;

namespace APARTMENT_API.Configurations
{
    // DbContext has auto in asp.net
    public class ApplicationDbContext :DbContext
    {
        // 1==>create constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts)
        {

        }
        public DbSet<Building> TblBuilding { get; set; }
        public DbSet<User> TblUser { get; set; }
        public DbSet<Floors> TblFloors { get; set; }
        public DbSet<RoomType> TblRoomType { get; set; }
        public DbSet<Item> TblItem { get; set; }
        public DbSet<Position> TblPosition { get; set; }
        public DbSet<ExpensType> TblExpensType { get; set; }
        public DbSet<OrtherExpense> TblortherExpens { get; set; }
        public DbSet<Staff> TblStaff { get; set; }
        public DbSet<Salary> TblSalary { get; set; }
        public DbSet<Guest> TblGuest { get; set; }
        public DbSet<Payslip> TblPayslip { get; set; }
        //public DbSet<Rolse> TblRolse { get; set; }

        public DbSet<ApplicationUser> TblApplicationUser { get; set; }
        public DbSet<ApplicationRole> TblApplicationRole { get; set; }
        public DbSet<ApplicationUserRole> TblApplicationUserRole { get; set; }

        public DbSet<Customer> CUSTOMER { get; set; }
    }
}
