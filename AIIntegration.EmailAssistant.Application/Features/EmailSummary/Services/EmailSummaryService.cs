using AIIntegration.EmailAssistant.Application.Features.EmailSummary.Interfaces;
using AIIntegration.EmailAssistant.Application.Features.EmailSummary.Requests;
using AIIntegration.EmailAssistant.Application.Features.EmailSummary.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIIntegration.EmailAssistant.Application.Features.EmailSummary.Services
{
    public sealed class EmailSummaryService : IEmailSummaryService
    {
        private readonly IEmailSummaryPromptBuilder _promptBuilder;

        public EmailSummaryService(
            IEmailSummaryPromptBuilder promptBuilder)
        {
            _promptBuilder = promptBuilder;
        }

        public Task<EmailSummaryResponse> SummarizeAsync(
            EmailSummaryRequest request,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(request);

            var prompt = _promptBuilder.Build(request);

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

            return Task.FromResult(response);
        }
    }
}
