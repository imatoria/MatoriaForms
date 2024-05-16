var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddSession();
builder.Services.AddCaptcha(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddPolicy("AllowSpecificOrigin",
        builder => {
            builder.WithOrigins(["https://m-form.runasp.net", "http://localhost:5500"]) // Add the allowed origin(s)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseCors("AllowSpecificOrigin");

//app.UseSession();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
