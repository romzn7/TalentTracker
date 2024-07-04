using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TalentTracker.Api.Models;
using TalentTracker.Application.Commands.Candidate;
using TalentTracker.Web.Controllers;
using TalentTracker.Web.Routing;

namespace TalentTracker.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = ApiGroupings.TalentTrackerApiGroupingsName)]
    public class CandidateController : TalentTrackerControllerBase
    {
        public ILogger<CandidateController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private const string _swaggerOperationTag = "Candidate";

        public CandidateController(ILogger<CandidateController> logger,
            IMapper mapper,
            IMediator mediator)
        {
            _logger=logger;
            _mapper = mapper;
            _mediator = mediator;
        }


        [HttpPost("candidates")]
        [SwaggerOperation(
         Summary = "Creates a Candidate",
         Description = "Creates a Candidate",
         OperationId = "candidate.create",
         Tags = new[] { _swaggerOperationTag })]
        [SwaggerResponse(StatusCodes.Status201Created, "Creates a Candidate", type: typeof(CreateCandidateResponseDTO))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Application failed to process the request")]
        public async Task<IActionResult> CreateCandidate([FromBody, SwaggerRequestBody("Create candidate parameters", Required = true)] CreateCandidateDTO createCandidate,
                                                  CancellationToken cancellationToken)
        {
            try
            {
                var command = _mapper.Map<CreateCandidate.Command>(createCandidate);
                var response = await _mediator.Send(command, cancellationToken);
                return Ok(_mapper.Map<CreateCandidateResponseDTO>(response));

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "CreateCandidate {@createCandidate}", createCandidate);
                throw;
            }
        }
    }
}
