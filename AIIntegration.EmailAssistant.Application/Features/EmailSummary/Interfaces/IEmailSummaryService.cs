using AIIntegration.EmailAssistant.Application.Features.EmailSummary.Requests;
using AIIntegration.EmailAssistant.Application.Features.EmailSummary.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIIntegration.EmailAssistant.Application.Features.EmailSummary.Interfaces
{
    public interface IEmailSummaryService
    {
        Task<EmailSummaryResponse> SummarizeAsync(
        EmailSummaryRequest request,
        CancellationToken cancellationToken = default);
    }
}
