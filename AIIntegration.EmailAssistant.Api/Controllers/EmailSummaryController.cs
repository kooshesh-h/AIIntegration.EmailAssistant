using AIIntegration.EmailAssistant.Application.Features.EmailSummary.Requests;

using Microsoft.AspNetCore.Mvc;
using AIIntegration.EmailAssistant.Application.Features.EmailSummary.Interfaces;

namespace AIIntegration.EmailAssistant.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class EmailSummaryController : ControllerBase
    {
        private readonly IEmailSummaryService _emailSummaryService;

        public EmailSummaryController(IEmailSummaryService emailSummaryService)
        {
            _emailSummaryService = emailSummaryService;
        }

        [HttpPost]
        public async Task<IActionResult> Summarize(
            [FromBody] EmailSummaryRequest request,
            CancellationToken cancellationToken)
        {
            var response = await _emailSummaryService
                .SummarizeAsync(request, cancellationToken);

            return Ok(response);
        }
    }
}
