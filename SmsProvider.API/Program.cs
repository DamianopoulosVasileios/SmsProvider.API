using Autofac;
using Autofac.Extensions.DependencyInjection;
using SmsProvider.API.Factories;
using SmsProvider.API.Interfaces;
using SmsProvider.API.Repositories;
using SmsProvider.API.Services;
using SmsProvider.API.Static;
using SmsProvider.API.Vendors;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterType<SMSVendorGR>()
                .Keyed<ISmsVendor>(nameof(VendorSysNames.Greece));

    containerBuilder.RegisterType<SMSVendorCY>()
                .Keyed<ISmsVendor>(nameof(VendorSysNames.Cyprus));

    containerBuilder.RegisterType<SMSVendorRest>()
                .Keyed<ISmsVendor>(nameof(VendorSysNames.Rest));

    containerBuilder.RegisterType<SmsService>().As<ISmsService>();
    containerBuilder.RegisterType<SMSVendorFactory>().As<ISMSVendorFactory>();
    containerBuilder.RegisterType<SmsRepository>().As<ISmsRepository>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/SendSMS", async (ISmsService smsService, string phoneNumber, string message) =>
{
    return await smsService.RouteToVendor(phoneNumber, message);
});

app.Run();

public partial class Program { }