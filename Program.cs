var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.MapGet("/api/status", () =>
    TypedResults.Ok(new { status = "ok" }));

app.MapPost("/api/echo", (EchoRequest request) =>
    TypedResults.Ok(new { message = request.Message }));

app.Run();

record EchoRequest(string Message);