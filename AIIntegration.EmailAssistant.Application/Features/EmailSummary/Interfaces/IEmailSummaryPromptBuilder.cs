using AIIntegration.EmailAssistant.Application.Features.EmailSummary.Requests;


namespace AIIntegration.EmailAssistant.Application.Features.EmailSummary.Interfaces
{
    public interface IEmailSummaryPromptBuilder
    {
        string Build(EmailSummaryRequest request);
    }
}
