using CapitalShip.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureCors();
builder.Services.ConfigureServiceManager();

// regsiter validators
builder.Services.ConfigureValidators();

builder.Services.ConfigureDatabaseContext(builder.Configuration);

var app = builder.Build();

app.ConfigureExceptionHandler();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
