using System.Numerics;
using System.Security.Claims;
using System.Text.RegularExpressions;
using AutoMapper;
using FitnessCheck.Data;
using FitnessCheck.Data.DTO.Request;
using FitnessCheck.Data.DTO.Response;
using FitnessCheck.Data.Entities;
using FitnessCheck.Services;
using FitnessCheckModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FitnessCheck.Controllers.v1;

[ApiController]
[Route("v1/[controller]")]
public class AttemptController(
    FitnessCheckDbContext _dbContext, IMapper _mapper, IPointsCalculator _pointsCalculator,
    IGenderService _genderService, ICohortService _cohortService, IOptions<MaxAllowedAttemptsOptions> maxAllowedAttempts) : Controller
{

    private readonly MaxAllowedAttemptsOptions _maxAllowedAttemptsOptions = maxAllowedAttempts.Value;

    [HttpGet("coreStrength")]
    [Authorize]
    public async Task<ActionResult<AttemptsResponseDTO<CoreStrengthAttemptResponseDTO>>> GetCoreStrengthAttempts()
    {
        return await GetAttemptResponse<CoreStrengthAttempt, uint, CoreStrengthAttemptResponseDTO>();
    }

    [HttpPost("coreStrength")]
    [Authorize]
    public async Task<ActionResult<CoreStrengthAttemptResponseDTO>> AddCoreStrength([FromBody] CoreStrengthAttemptCreationRequestDTO creationRequestDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        (Guid userId, string username, char gender, Cohort cohort) userData = await GetUserDataAsync();
        bool filter(ResultsCalculation x) => GetPropertyValue<int>(x, nameof(ResultsCalculation.CoreStrength)) <= creationRequestDTO.ResultInSeconds && x.Gender == userData.gender;
        var response = await PersistAttemptAsync<uint, CoreStrengthAttempt, CoreStrengthAttemptResponseDTO>(creationRequestDTO.ResultInSeconds, userData, filter);

        return response;
    }

    [HttpDelete("coreStrength/{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteCoreStrengthAttempts(Guid id)
    {
        return await DeleteAttemptAsync<CoreStrengthAttempt, uint>(id);
    }

    [HttpGet("medicineBallPush")]
    [Authorize]
    public async Task<ActionResult<AttemptsResponseDTO<MedicineBallPushAttemptResponseDTO>>> GetMedicineBallPushAttempts()
    {
        return await GetAttemptResponse<MedicineBallPushAttempt, uint, MedicineBallPushAttemptResponseDTO>();
    }

    [HttpPost("medicineBallPush")]
    [Authorize]
    public async Task<ActionResult<MedicineBallPushAttemptResponseDTO>> AddMedicineBallThrow([FromBody] MedicineBallPushAttemptCreationRequestDTO creationRequestDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        (Guid userId, string username, char gender, Cohort cohort) userData = await GetUserDataAsync();
        bool filter(ResultsCalculation x) => GetPropertyValue<int>(x, nameof(ResultsCalculation.MedicineBallPush)) <= creationRequestDTO.ResultInCentimeters && x.Gender == userData.gender;
        var response = await PersistAttemptAsync<uint, MedicineBallPushAttempt, MedicineBallPushAttemptResponseDTO>(creationRequestDTO.ResultInCentimeters, userData, filter);

        return response;
    }

    [HttpDelete("medicineBallPush/{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteMedicineBallPushAttempts(Guid id)
    {
        return await DeleteAttemptAsync<MedicineBallPushAttempt, uint>(id);
    }

    [HttpGet("oneLegStand")]
    [Authorize]
    public async Task<ActionResult<AttemptsResponseDTO<OneLegStandAttemptResponseDTO>>> GetOneLegStandAttempts()
    {
        return await GetAttemptResponse<OneLegStandAttempt, uint, OneLegStandAttemptResponseDTO>();
    }

    [HttpPost("oneLegStand")]
    [Authorize]
    public async Task<ActionResult<OneLegStandAttemptResponseDTO>> AddOneLegStand([FromBody] OneLegStandAttemptCreationRequestDTO creationRequestDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        (Guid userId, string username, char gender, Cohort cohort) userData = await GetUserDataAsync();
        bool filter(ResultsCalculation x) => GetPropertyValue<int>(x, nameof(ResultsCalculation.OneLegStand)) <= creationRequestDTO.ResultInSeconds && x.Gender == userData.gender;
        var response = await PersistAttemptAsync<uint, OneLegStandAttempt, OneLegStandAttemptResponseDTO>(creationRequestDTO.ResultInSeconds, userData, filter, creationRequestDTO.Foot);

        return response;
    }

    [HttpDelete("oneLegStand/{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteOneLegStandAttempts(Guid id)
    {
        return await DeleteAttemptAsync<OneLegStandAttempt, uint>(id);
    }

    [HttpGet("shuttleRun")]
    [Authorize]
    public async Task<ActionResult<AttemptsResponseDTO<ShuttleRunAttemptResponseDTO>>> GetShuttleRunAttempts()
    {
        return await GetAttemptResponse<ShuttleRunAttempt, uint, ShuttleRunAttemptResponseDTO>();
    }

    [HttpPost("shuttleRun")]
    [Authorize]
    public async Task<ActionResult<ShuttleRunAttemptResponseDTO>> AddShuttleRun([FromBody] ShuttleRunAttemptCreationRequestDTO creationRequestDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        (Guid userId, string username, char gender, Cohort cohort) userData = await GetUserDataAsync();
        bool filter(ResultsCalculation x) => GetPropertyValue<int>(x, nameof(ResultsCalculation.ShuttleRun)) >= creationRequestDTO.ResultInMilliseconds && x.Gender == userData.gender;
        var response = await PersistAttemptAsync<uint, ShuttleRunAttempt, ShuttleRunAttemptResponseDTO>(creationRequestDTO.ResultInMilliseconds, userData, filter);

        return response;
    }

    [HttpDelete("shuttleRun/{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteShuttleRunAttempts(Guid id)
    {
        return await DeleteAttemptAsync<ShuttleRunAttempt, uint>(id);
    }

    [HttpGet("standingLongJump")]
    [Authorize]
    public async Task<ActionResult<AttemptsResponseDTO<StandingLongJumpAttemptResponseDTO>>> GetStandingLongJumpAttempts()
    {
        return await GetAttemptResponse<StandingLongJumpAttempt, uint, StandingLongJumpAttemptResponseDTO>();
    }

    [HttpPost("standingLongJump")]
    [Authorize]
    public async Task<ActionResult<StandingLongJumpAttemptResponseDTO>> AddStandingLongJump([FromBody] StandingLongJumpAttemptCreationRequestDTO creationRequestDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        (Guid userId, string username, char gender, Cohort cohort) userData = await GetUserDataAsync();
        bool filter(ResultsCalculation x) => GetPropertyValue<int>(x, nameof(ResultsCalculation.StandingLongJump)) <= creationRequestDTO.ResultInCentimeters && x.Gender == userData.gender;
        var response = await PersistAttemptAsync<uint, StandingLongJumpAttempt, StandingLongJumpAttemptResponseDTO>(creationRequestDTO.ResultInCentimeters, userData, filter);

        return response;
    }



    [HttpDelete("standingLongJump/{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteStandingLongJumpAttempts(Guid id)
    {
        return await DeleteAttemptAsync<StandingLongJumpAttempt, uint>(id);
    }

    [HttpGet("twelveMinutesRun")]
    [Authorize]
    public async Task<ActionResult<AttemptsResponseDTO<TwelveMinutesRunAttemptResponseDTO>>> GetTwelveMinutesRunAttempts()
    {
        return await GetAttemptResponse<TwelveMinutesRunAttempt, float, TwelveMinutesRunAttemptResponseDTO>();
    }

    [HttpPost("twelveMinutesRun")]
    [Authorize]
    public async Task<ActionResult<TwelveMinutesRunAttemptResponseDTO>> AddTwelveMinutesRun([FromBody] TwelveMinutesRunAttemptCreationRequestDTO creationRequestDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        (Guid userId, string username, char gender, Cohort cohort) userData = await GetUserDataAsync();
        bool filter(ResultsCalculation x) => GetPropertyValue<float>(x, nameof(ResultsCalculation.TwelveMinutesRun)) <= creationRequestDTO.ResultInRounds && x.Gender == userData.gender;
        var response = await PersistAttemptAsync<float, TwelveMinutesRunAttempt, TwelveMinutesRunAttemptResponseDTO>(creationRequestDTO.ResultInRounds, userData, filter);

        return response;
    }

    [HttpDelete("twelveMinutesRun/{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteTwelveMinutesRunAttempts(Guid id)
    {
        return await DeleteAttemptAsync<TwelveMinutesRunAttempt, float>(id);
    }

    private Guid GetUserId()
    {
        string? userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userIdString))
        {
            throw new ArgumentException($"No claim of type '{ClaimTypes.NameIdentifier}' was found.", ClaimTypes.NameIdentifier);
        }
        if (!Guid.TryParse(userIdString, out Guid userId))
        {
            throw new ArgumentException($"Value for claim '{ClaimTypes.NameIdentifier}' ({userIdString}) cannot be parsed as Guid.", ClaimTypes.NameIdentifier);
        }

        return userId;
    }

    private string GetUsername()
    {
        string? usernameString = User.FindFirstValue(ClaimTypes.Upn);
        if (string.IsNullOrEmpty(usernameString))
        {
            throw new ArgumentException($"No claim of type '{ClaimTypes.Upn}' was found.", ClaimTypes.Upn);
        }

        var upnPattern = @"^([A-z]{2,}\d{0,2})(?=@?)";
        var upnRegex = new Regex(upnPattern);
        var matches = upnRegex.Matches(usernameString);

        if (matches.Count == 0)
        {
            throw new ArgumentException($"Invalid value for claim of type '{ClaimTypes.Upn}': '{usernameString}'.", ClaimTypes.Upn);
        }

        var username = matches[0].Value;
        return username;
    }

    private T GetPropertyValue<T>(ResultsCalculation obj, string propertyName) where T : INumber<T>
    {
        var property = typeof(ResultsCalculation).GetProperty(propertyName)
                       ?? throw new ArgumentException($"There is no property named '{propertyName}' in class '{nameof(ResultsCalculation)}'.", nameof(propertyName));
        var propertyValue = property.GetValue(obj)
                            ?? throw new ArgumentException($"The value for property '{propertyName}' is null.", propertyName);

        return (T)Convert.ChangeType(propertyValue, typeof(T));
    }

    private async Task<(Guid, string, char, Cohort)> GetUserDataAsync()
    {
        var userId = GetUserId();
        var username = GetUsername();
        var userData = (
            userId,
            username,
            await _genderService.GetGenderAsync(username),
            (await _cohortService.GetCohortAsync(username))!
        );

        return userData;
    }

    private byte GetAttemptNumber<TEntity, TResultValue>(Guid userId, Guid cohortId, EFoot? foot = null)
        where TEntity : DisciplineAttempt<TResultValue>
        where TResultValue : INumber<TResultValue>
    {
        var maxAllowedAttempts = _maxAllowedAttemptsOptions.GetForDisciplineAttempt<TEntity, TResultValue>();

        Func<TEntity, bool> where = foot is not null && typeof(TEntity) == typeof(OneLegStandAttempt)
            ? (TEntity attempt) => attempt.UserId == userId && attempt.CohortId == cohortId && (attempt as OneLegStandAttempt)!.Foot == foot
            : (TEntity attempt) => attempt.UserId == userId && attempt.CohortId == cohortId;

        var lastAttemptNumber = _dbContext.Set<TEntity>()
                               .Where(where)
                               .OrderByDescending(attempt => attempt.AttemptNumber)
                               .Select(attempt => attempt.AttemptNumber)
                               .FirstOrDefault();

        var attemptNumber = (byte)(lastAttemptNumber + 1);

        if (attemptNumber > maxAllowedAttempts)
        {
            var allowedAttempts = maxAllowedAttempts == 1 ? "1 Versuch" : $"{maxAllowedAttempts} Versuche";
            throw new ArgumentOutOfRangeException(null, $"Die maximale Anzahl Versuche für diese Disziplin ({allowedAttempts}) ist erreicht.");
        }

        return attemptNumber;
    }

    private async Task<ActionResult<TResponse>> PersistAttemptAsync<TResultValue, TEntity, TResponse>(
        TResultValue value,
        (Guid userId, string username, char gender, Cohort cohort) userData,
        Func<ResultsCalculation, bool> pointsCalculationComparisonFilter,
        EFoot? foot = null
    )
        where TResultValue : INumber<TResultValue>
        where TEntity : DisciplineAttempt<TResultValue>, new()
        where TResponse : DisciplineAttemptResponseDTO
    {
        try
        {
            var points = _pointsCalculator.CalculatePoints(pointsCalculationComparisonFilter);
            var attemptNumber = GetAttemptNumber<TEntity, TResultValue>(userData.userId, userData.cohort.Id, foot);

            var attempt = new TEntity
            {
                AttemptNumber = attemptNumber,
                MomentUtc = DateTime.UtcNow,
                Points = points,
                UserId = userData.userId,
                Cohort = userData.cohort,
                Gender = userData.gender
            };

            if (attempt is OneLegStandAttempt oneLegStandAttempt && foot is not null)
            {
                oneLegStandAttempt.Foot = (EFoot)foot;
            }

            attempt.SetResultValue(value);

            _dbContext.Set<TEntity>().Add(attempt);
            await _dbContext.SaveChangesAsync();

            return Ok(_mapper.Map<TResponse>(attempt));
        }
        catch (ArgumentException exception)
        {
            return BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            // Replace with Logger in the future (for example AWS Cloudwatch)
            Console.WriteLine(exception.Message);
            return StatusCode(500, exception.Message);
        }
    }

    private async Task<IActionResult> DeleteAttemptAsync<TEntity, TResultValue>(Guid attemptId)
        where TEntity : DisciplineAttempt<TResultValue>
        where TResultValue : INumber<TResultValue>
    {
        Guid userId = GetUserId();

        var attemptToDelete = await _dbContext.Set<TEntity>().FindAsync(attemptId);

        if (attemptToDelete is null)
        {
            return NotFound($"No attempt with id '{attemptId}' does exist.");
        }

        var attemptsToUpdate = await _dbContext.Set<TEntity>().Where(attempt => attempt.UserId == userId
                                                                                && attempt.CohortId == attemptToDelete.CohortId
                                                                                && attempt.AttemptNumber > attemptToDelete.AttemptNumber).ToListAsync();
        foreach (var attempt in attemptsToUpdate)
        {
            attempt.AttemptNumber--;
        }

        if (!attemptToDelete.UserId.Equals(userId))
        {
            return Forbid();
        }

        _dbContext.Remove(attemptToDelete);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }

    private async Task<ActionResult<AttemptsResponseDTO<TResponseDTO>>> GetAttemptResponse<TDiscipline, TResultValue, TResponseDTO>()
        where TResultValue : INumber<TResultValue>
        where TDiscipline : DisciplineAttempt<TResultValue>
        where TResponseDTO : DisciplineAttemptResponseDTO
    {
        var userId = GetUserId();
        var attempts = await _dbContext.Set<TDiscipline>()
                                       .Where(attempt => attempt.UserId == userId)
                                       .OrderBy(attempt => attempt.AttemptNumber)
                                       .ToListAsync();

        var bestAttempts = GetBestAttempts<TDiscipline, TResultValue>(attempts);
        var points = bestAttempts.Count() == 1 ? bestAttempts.FirstOrDefault()?.Points ?? 0 : (uint)bestAttempts.Sum(attempt => attempt?.Points ?? 0);

        var maxAllowedAttempts = _maxAllowedAttemptsOptions.GetForDisciplineAttempt<TDiscipline, TResultValue>();
        if (typeof(TDiscipline) == typeof(OneLegStandAttempt))
        {
            // For the one leg stand, the maximum allowed attempts are defined PER LEG
            maxAllowedAttempts *= 2;
        }

        var attemptDTOs = _mapper.Map<IEnumerable<TDiscipline>, List<TResponseDTO>>(attempts);
        var response = new AttemptsResponseDTO<TResponseDTO>()
        {
            Points = points,
            BestAttemptIds = bestAttempts.Select(attempt => attempt?.Id).ToArray(),
            Attempts = attemptDTOs,
            RemainingAttempts = (uint)(maxAllowedAttempts - attemptDTOs.Count),
        };

        return Ok(response);
    }

    private static IEnumerable<DisciplineAttempt<TResultValue>?> GetBestAttempts<TDiscipline, TResultValue>(IEnumerable<DisciplineAttempt<TResultValue>> attempts)
        where TDiscipline : DisciplineAttempt<TResultValue>
        where TResultValue : INumber<TResultValue>
    {
        if (typeof(TDiscipline) == typeof(OneLegStandAttempt))
        {
            // For the one leg stand the points are determined based on the sum of the best attempts with each leg.
            var leftLegAttempts = attempts.Where(attempt => (attempt as OneLegStandAttempt)!.Foot == EFoot.Left).OrderByDescending(attempt => (attempt as OneLegStandAttempt)!.ResultInSeconds);
            var rightLegAttempts = attempts.Where(attempt => (attempt as OneLegStandAttempt)!.Foot == EFoot.Right).OrderByDescending(attempt => (attempt as OneLegStandAttempt)!.ResultInSeconds);
            return [leftLegAttempts?.FirstOrDefault(), rightLegAttempts?.FirstOrDefault()];
        }

        // For any discipline other than the one leg stand, there's a single best attempt
        return [attempts.MaxBy(attempt => attempt.Points)];
    }

}