using APARTMENT_API.Configurations;
using APARTMENT_API.Middlewares;
using APARTMENT_API.Repositories;
using APARTMENT_API.Repositories.Interfaces;
using APARTMENT_API.Services;
using APARTMENT_API.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System.Net;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// =============================================>>> Add New in file

var conStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseOracle(conStr, b => b.UseOracleSQLCompatibility(OracleSQLCompatibility.DatabaseVersion19));
});

// =============================================>>>


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// ===============================================>>> Add New ( Add Automapper )
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration).Assembly);

// ============================ Add Scoped ===================================
// ============= Add Repository ==================================================== 
builder.Services.AddScoped<IBuildingRepository,BuildingRepository>();

builder.Services.AddScoped<IAuthorizationRepository, AuthorizationRepository>();

builder.Services.AddScoped<IFloorsRepository, FloorRepository>();

builder.Services.AddScoped<IRoomType,RoomTypeRepository>();

builder.Services.AddScoped<IItemRepository, ItemRepository>();

builder.Services.AddScoped<IExpensTypeRepository, ExpensTypeRepository>();

builder.Services.AddScoped<IPositionRepository, PositionRopository>();

builder.Services.AddScoped<IStaffRepository, StaffRepository>();

builder.Services.AddScoped<IOrtherExpnseRepository, OrtherExpenseRopository>();

builder.Services.AddScoped<ISalaryRepository, SalaryRepository>();

builder.Services.AddScoped<IGuestRepository, GuestRepository>();

builder.Services.AddScoped<IPayslipRepository, PayslipRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IRoleRepository, RoleRepository>();

builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();


// ============= Add Repository ==================================================== 
builder.Services.AddScoped<IBuildingService, BuildingService>();

builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();

builder.Services.AddScoped<IFloorsService, FloorsService>();

builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();

builder.Services.AddScoped<IItemService, ItemService>();

builder.Services.AddScoped<IExpensTypeService, ExpensTypeService>();

builder.Services.AddScoped<IStaffService, StaffService>();

builder.Services.AddScoped<IPositionService, PositionService>();

builder.Services.AddScoped<IOrtherExpenseService, OrtherExpenseService>();

builder.Services.AddScoped<ISalaryService, SalaryService>();

builder.Services.AddScoped<IGuestService, GuestService>();

builder.Services.AddScoped<IPayslipService, PayslipService>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IRoleService, RoleService>();

builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddScoped<Microsoft.AspNetCore.Identity.IPasswordHasher<APARTMENT_API.Model.ApplicationUser>, Microsoft.AspNetCore.Identity.PasswordHasher<APARTMENT_API.Model.ApplicationUser>>();

/// Add new  (Swagger UI)
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("V1", new OpenApiInfo
    {
        Version = "V1",
        Title = "My API",
        Description = "Oracle Project with React Type Script"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http

    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<String> ()
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAll",
        policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
    );
});

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    builder.Configuration["JWT:Secret"]!
        ))
    };
});

var app = builder.Build();

// =============================================>>> Add New in file

app.UseMiddleware<ExceptionMiddleware>();

// =============================================>>>


app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
    {
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(JsonConvert.SerializeObject(new
        {
            Success = false,
            StatusCode = 401,
            Message = "Unauthorized",
            Data = new { }
        }));
    }
});

app.UseCors("AllowAll");
app.UseAuthentication();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // app.UseSwaggerUI();

    // add new
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/V1/swagger.json", "oracle Project with React Type Script");
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
