using AIIntegration.EmailAssistant.Api.Middlewares;
using AIIntegration.EmailAssistant.Application.Features.EmailSummary.Builder;
using AIIntegration.EmailAssistant.Application.Features.EmailSummary.Interfaces;
using AIIntegration.EmailAssistant.Application.Features.EmailSummary.Services;
using AIIntegration.EmailAssistant.Infrastructure.Clients;
using AIIntegration.EmailAssistant.Application.Common.AI;


namespace AIIntegration.EmailAssistant.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddHttpClient<IAiServiceClient, AiServiceClient>(client =>
            {
                client.BaseAddress = new Uri(
                    builder.Configuration["AiMicroservice:BaseUrl"]!);
            });

            builder.Services.AddControllers();

            builder.Services.AddOpenApi();

            builder.Services.AddScoped<IEmailSummaryPromptBuilder, EmailSummaryPromptBuilder>();
            builder.Services.AddScoped<IEmailSummaryService, EmailSummaryService>();

            //Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // Middleware exception
            app.UseHttpsRedirection();

            app.UseMiddleware<GlobalExceptionMiddleware>();

            app.MapControllers();

            app.MapControllers();

            app.Run();
        }
    }
}
