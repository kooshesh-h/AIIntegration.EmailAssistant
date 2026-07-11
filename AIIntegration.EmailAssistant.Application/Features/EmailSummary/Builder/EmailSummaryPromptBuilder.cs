using AIIntegration.EmailAssistant.Application.Features.EmailSummary.Prompts;
using AIIntegration.EmailAssistant.Application.Features.EmailSummary.Requests;
using AIIntegration.EmailAssistant.Application.Features.EmailSummary.Interfaces;

namespace AIIntegration.EmailAssistant.Application.Features.EmailSummary.Builder;

public sealed class EmailSummaryPromptBuilder: IEmailSummaryPromptBuilder
{
    public string Build(EmailSummaryRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (string.IsNullOrWhiteSpace(request.Email))
        {
            throw new ArgumentException(
                "Email content cannot be empty.",
                nameof(request));
        }

        if (string.IsNullOrWhiteSpace(request.Language))
        {
            throw new ArgumentException(
                "Language cannot be empty.",
                nameof(request));
        }

        if (string.IsNullOrWhiteSpace(request.Tone))
        {
            throw new ArgumentException(
                "Tone cannot be empty.",
                nameof(request));
        }

        if (request.MaxSummaryWords <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(request),
                request.MaxSummaryWords,
                "Maximum summary words must be greater than zero.");
        }

        var template = EmailSummaryPromptTemplate.Template;

        var populatedTemplate = template
            .Replace(
                "{language}",
                request.Language.Trim(),
                StringComparison.Ordinal)
            .Replace(
                "{tone}",
                request.Tone.Trim(),
                StringComparison.Ordinal)
            .Replace(
                "{maxSummaryWords}",
                request.MaxSummaryWords.ToString(),
                StringComparison.Ordinal)
            .Replace(
                "{email}",
                request.Email.Trim(),
                StringComparison.Ordinal);

        return $"""
                {EmailSummaryFewShotExamples.Examples}

                ------------------------------------------------
                ACTUAL EMAIL TO ANALYZE
                ------------------------------------------------

                {populatedTemplate}
                """;
    }
}