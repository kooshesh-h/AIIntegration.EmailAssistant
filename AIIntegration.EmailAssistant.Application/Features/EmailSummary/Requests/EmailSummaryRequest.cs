using System;
using System.Collections.Generic;
using System.Text;

namespace AIIntegration.EmailAssistant.Application.Features.EmailSummary.Requests
{
    internal class EmailSummaryRequest
    {
        public string Email { get; init; } = string.Empty;

        public string Language { get; init; } = "English";

        public string Tone { get; init; } = "Professional";

        public int MaxSummaryWords { get; init; } = 100;
    }
}
