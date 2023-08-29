using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using PhoneBookHumanGroupBL.EmailSenderManager;
using PhoneBookHumanGroupBL.ImplementationsOfManagers;
using PhoneBookHumanGroupBL.InterfacesOfManagers;
using PhoneBookHumanGroupDL.ContextInfo;
using PhoneBookHumanGroupDL.ImplementationofRepos;
using PhoneBookHumanGroupDL.InterfacesofRepos;
using PhoneBookHumanGroupEL.Mappings;

var builder = WebApplication.CreateBuilder(args);


//contexti ayarliyoruz.
builder.Services.AddDbContext<PhoneBookHumanGroupContext>(options =>
{
    //klasik mvcde connection string web configte yer alir.
    //core mvcde connection string appsetting.json dosyasindan alinir.
    options.UseSqlServer(builder.Configuration.GetConnectionString("Betul"));
});


builder.Services.AddAutoMapper(x =>
{
    x.AddExpressionMapping();
    x.AddProfile<Maps>();

});

// Add services to the container.
builder.Services.AddControllersWithViews();


//interfaceleri gerceklestirecek classlarin burada yasam donguleri tanimlanir
builder.Services.AddScoped<IMemberRepo,MemberRepo>();
builder.Services.AddScoped<IMemberManager,MemberManager>();



builder.Services.AddScoped<IMemberPhoneRepo, MemberPhoneRepo>();
builder.Services.AddScoped<IMemberPhoneManager, MemberPhoneManager>();


builder.Services.AddScoped<IPhoneGroupRepo, PhoneGroupRepo>();
builder.Services.AddScoped<IPhoneGroupManager, PhoneGroupManager>();

builder.Services.AddScoped<IEmailSender, EmailSender>();


//CookieAuthentication ayari
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles(); // wwwroota erismek icin 

app.UseRouting(); // 

app.UseAuthentication();  //Authorize attributenun calisabilmesi icin bu ayar eklenmelidir
app.UseAuthorization(); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
