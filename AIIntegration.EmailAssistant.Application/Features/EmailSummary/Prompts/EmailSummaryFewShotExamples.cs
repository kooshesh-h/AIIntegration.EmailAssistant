using System;
using System.Collections.Generic;
using System.Text;

namespace AIIntegration.EmailAssistant.Application.Features.EmailSummary.Prompts
{
    internal class EmailSummaryFewShotExamples
    {
        public const string Examples = """
        Example 1

        Email:
        Hi John,

        Please review the attached document before Friday and let me know your feedback.

        Expected Output:

        {
          "summary":"The sender asks John to review the attached document before Friday and provide feedback.",
          "actionItems":[
              "Review the attached document",
              "Provide feedback"
          ],
          "deadline":"Friday",
          "suggestedReply":"Hi, I will review the document before Friday and send you my feedback. Thank you."
        }

        ------------------------------------------------

        Example 2

        Email:

        Our meeting has been moved to Monday at 10 AM.

        Expected Output:

        {
          "summary":"The meeting has been rescheduled to Monday at 10 AM.",
          "actionItems":[],
          "deadline":"Monday 10 AM",
          "suggestedReply":"Thank you for the update. I will be available on Monday at 10 AM."
        }

        ------------------------------------------------
        """;
    }
}
