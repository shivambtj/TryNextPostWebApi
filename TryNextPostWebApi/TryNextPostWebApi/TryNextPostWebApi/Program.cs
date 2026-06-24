using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using TryNextPostWebApi.DataBase;
using TryNextPostWebApi.IServices;
using TryNextPostWebApi.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TryNextPostWebApi.Notifications;
//====================run api on browser ========================
//=============https://localhost:7091/swagger ===================
//======================end run api on browser ==================

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//======================start Cors Policy ===========================
builder.Services.AddCors();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowCors",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200", "https://localhost:4200/")
            .AllowCredentials()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
//=======================end cors policy ========================================================

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
//=============================================start jwt Authntication===========================
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer=true,
        ValidateAudience=true,
        ValidateLifetime=true,
        ValidateIssuerSigningKey=true,
        ValidIssuer= builder.Configuration.GetValue<string>("Jwt:Issuer"),
        ValidAudience= builder.Configuration.GetValue<string>("jwt:Audience"),
        IssuerSigningKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Jwt:Key")))
    };
});
//============================================end jwt Authntication==============================
//=================added services used in projects================================================
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ExcelLoginLogger>();
builder.Services.AddScoped<INotificationService, MailNotificationService>();
builder.Services.AddScoped<IRoleMasterService, RoleMasterService>();
//====================end services used in projects=============================================================
builder.Services.AddHttpContextAccessor();
var app = builder.Build();
if(app.Environment.IsDevelopment())
{
    // Swagger UI
    app.UseSwagger();

    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
//=======add  middleware afetr jwt auth================
// Use CORS (must be before MapControllers)
app.UseCors("AllowCors");
app.UseAuthorization();
app.MapControllers();

app.Run();