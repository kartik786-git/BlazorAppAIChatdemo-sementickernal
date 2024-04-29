using BlazorAppAIChatdemo;
using BlazorAppAIChatdemo.Components;
using Microsoft.SemanticKernel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKernel().
    //AddOpenAIChatCompletion("gpt-3.5-turbo", "nokeyrequired",
    //httpClient: new HttpClient(new ProxyOpenAIHandler()));
AddOpenAIChatCompletion(modelId: "gpt-3.5-turbo", apiKey: "nokeyrequired",
    httpClient: new HttpClient(new ProxyOpenAIHandler()));


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

