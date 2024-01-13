using BlueAPI;
using BlueAPI.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options => { 
        options.SuppressMapClientErrors = true;
        options.InvalidModelStateResponseFactory = context =>
        { 
            return HttpErrors.BadRequest(data: "Invalid data model");
        };
    });

var app = builder.Build();

//SERVICES

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<BlueDB>();

app.UseHttpsRedirection();
app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

app.UseExceptionHandler("/errors/500");
app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.MapControllers();

app.Run();
