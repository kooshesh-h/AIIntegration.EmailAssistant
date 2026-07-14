using AIIntegration.EmailAssistant.Application.Common.AI;
using System.Threading;
using System.Threading.Tasks;

namespace AIIntegration.EmailAssistant.Application.Common.AI;

public interface IAiServiceClient
{
    Task<TextGenerationResponse> GenerateTextAsync(
        TextGenerationRequest request,
        CancellationToken cancellationToken = default);
}