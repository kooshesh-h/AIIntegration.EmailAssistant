using AIIntegration.EmailAssistant.Application.Features.EmailSummary.Interfaces;
using AIIntegration.EmailAssistant.Application.Features.EmailSummary.Requests;
using AIIntegration.EmailAssistant.Application.Features.EmailSummary.Responses;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIIntegration.EmailAssistant.Application.Features.EmailSummary.Services
{
    public sealed class EmailSummaryService : IEmailSummaryService
    {
        private readonly IEmailSummaryPromptBuilder _promptBuilder;
        private readonly ILogger<EmailSummaryService> _logger;

        public EmailSummaryService(
            IEmailSummaryPromptBuilder promptBuilder, ILogger<EmailSummaryService> logger)
        {
            _promptBuilder = promptBuilder;
            _logger = logger;
        }

        public Task<EmailSummaryResponse> SummarizeAsync(
            EmailSummaryRequest request,
            CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Starting email summarization.");
            ArgumentNullException.ThrowIfNull(request);

            var prompt = _promptBuilder.Build(request);
            
            _logger.LogInformation("Prompt built successfully.");

            var response = new EmailSummaryResponse
            {
                Summary = "Mock summary generated successfully.",

                ActionItems =
                [
                    "Mock Action Item 1",
                    "Mock Action Item 2"
                ],

                Deadline = "Friday",

                SuggestedReply =
                    "Thank you for your email. I will review it and get back to you soon."
            };

            _logger.LogInformation("Returning mock AI response.");

            return Task.FromResult(response);
        }
    }
}
