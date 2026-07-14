using System.Text.Json;
using AIIntegration.EmailAssistant.Application.Common.AI;
using AIIntegration.EmailAssistant.Application.Features.EmailSummary.Interfaces;
using AIIntegration.EmailAssistant.Application.Features.EmailSummary.Requests;
using AIIntegration.EmailAssistant.Application.Features.EmailSummary.Responses;
using Microsoft.Extensions.Logging;

namespace AIIntegration.EmailAssistant.Application.Features.EmailSummary.Services;

public sealed class EmailSummaryService : IEmailSummaryService
{
    private readonly IEmailSummaryPromptBuilder _promptBuilder;
    private readonly IAiServiceClient _aiServiceClient;
    private readonly ILogger<EmailSummaryService> _logger;

    public EmailSummaryService(
        IEmailSummaryPromptBuilder promptBuilder,
        IAiServiceClient aiServiceClient,
        ILogger<EmailSummaryService> logger)
    {
        _promptBuilder = promptBuilder;
        _aiServiceClient = aiServiceClient;
        _logger = logger;
    }

    public async Task<EmailSummaryResponse> SummarizeAsync(
        EmailSummaryRequest request,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(request);

        _logger.LogInformation(
            "Starting email summarization. Language: {Language}, Tone: {Tone}, MaxWords: {MaxWords}",
            request.Language,
            request.Tone,
            request.MaxSummaryWords);

        var prompt = _promptBuilder.Build(request);

        _logger.LogInformation("Prompt built successfully.");

        var aiResponse = await _aiServiceClient.GenerateTextAsync(
            new TextGenerationRequest
            {
                Prompt = prompt
            },
            cancellationToken);

        _logger.LogInformation(
            "AI Microservice response received successfully.");

        var result = JsonSerializer.Deserialize<EmailSummaryResponse>(
            aiResponse.Content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        if (result is null)
        {
            throw new InvalidOperationException(
                "The AI Microservice returned an invalid email summary response.");
        }

        _logger.LogInformation(
            "Email summarization completed successfully.");

        return result;
    }
}