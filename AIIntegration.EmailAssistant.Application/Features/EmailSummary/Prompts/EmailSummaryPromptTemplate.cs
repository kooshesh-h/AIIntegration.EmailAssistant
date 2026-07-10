using System;
using System.Collections.Generic;
using System.Text;

namespace AIIntegration.EmailAssistant.Application.Features.EmailSummary.Prompts
{
    internal class EmailSummaryPromptTemplate
    {
        public const string Template = """
        You are a professional AI email assistant.

        Analyze the email and complete the following tasks:

        1. Write a concise summary.
        2. Extract all action items.
        3. Identify any deadline or important date.
        4. Write a professional suggested reply.

        Requirements:
        - Write the response in {language}.
        - Use a {tone} tone.
        - The summary must not exceed {maxSummaryWords} words.
        - Do not invent information.
        - If there are no action items, return an empty array.
        - If there is no deadline, return null.

        Return only valid JSON using exactly this structure:

        {
          "summary": "string",
          "actionItems": ["string"],
          "deadline": "string or null",
          "suggestedReply": "string"
        }

        Email:
        ---
        {email}
        ---
        """;
    }
}
