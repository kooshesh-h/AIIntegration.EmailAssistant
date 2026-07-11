using System;
using System.Collections.Generic;
using System.Text;

namespace AIIntegration.EmailAssistant.Application.Features.EmailSummary.Responses
{
    public sealed class EmailSummaryResponse
    {
        public string Summary { get; init; } = string.Empty;

        public IReadOnlyList<string> ActionItems { get; init; } = [];

        public string? Deadline { get; init; }

        public string SuggestedReply { get; init; } = string.Empty;
    }
}
