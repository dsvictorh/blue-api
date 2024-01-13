using BlueAPI;
using BlueAPI.Data;
using BlueAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options => { 
        options.SuppressMapClientErrors = true;
        options.InvalidModelStateResponseFactory = context =>
        { 
            return HttpErrors.BadRequest(data: "Invalid data model");
        };
    });

//SERVICES
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<BlueDB>();

var app = builder.Build();

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
