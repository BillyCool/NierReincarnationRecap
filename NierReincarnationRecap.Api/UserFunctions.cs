using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NierReincarnationRecap.Business.EF;
using NierReincarnationRecap.Business.EF.Model;
using NierReincarnationRecap.Model.Dto;
using System.Net;

namespace NierReincarnationRecap.Api
{
    public class UserFunctions(NierReincarnationRecapDbContext dbContext, ILogger<UserFunctions> logger)
    {
        //[Function("submit-user-data")]
        public async Task<HttpResponseData> SubmitUserData([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            try
            {
                var userDataDto = await req.ReadFromJsonAsync<UserDataDto>();

                if (userDataDto is null) return req.CreateResponse(HttpStatusCode.BadRequest);

                // Create or update user record
                UserData? userData = await dbContext.UserData.FirstOrDefaultAsync(x => x.UserId == userDataDto.UserId && x.Region == userDataDto.Region);

                if (userData is null)
                {
                    userData = new UserData()
                    {
                        Region = userDataDto.Region,
                        UserId = userDataDto.UserId,
                        PlayerId = userDataDto.PlayerId,
                        Slug = Crypto.Encrypt(userDataDto.UserId, userDataDto.Region.ToString()),
                        RegisterDatetime = DateTimeOffset.FromUnixTimeMilliseconds(userDataDto.RegisterDatetime)
                    };
                    dbContext.UserData.Add(userData);
                }

                userData.UpdateFromDto(userDataDto);

                // Save changes
                await dbContext.SaveChangesAsync();

                // Return the recap URL
                var response = req.CreateResponse(HttpStatusCode.OK);
                await response.WriteStringAsync($"{Environment.GetEnvironmentVariable("WebsiteBaseUrl")!}/recap/{userData.Slug}");

                return response;
            }
            catch (Exception ex)
            {
                return await GetErrorResponseAsync(req, ex);
            }
        }

        //[Function("submit-votes")]
        public async Task<HttpResponseData> SubmitUserVotes([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            try
            {
                var userSubmitVotesDto = await req.ReadFromJsonAsync<UserSubmissionDto>();

                if (userSubmitVotesDto is null || userSubmitVotesDto.Votes.Count == 0) return req.CreateResponse(HttpStatusCode.BadRequest);

                // Create or update user submission record
                UserSubmission? userSubmission = await dbContext.UserSubmissions.FirstOrDefaultAsync(x => x.Token == userSubmitVotesDto.Token);

                if (userSubmission is null)
                {
                    userSubmission = new UserSubmission()
                    {
                        Token = userSubmitVotesDto.Token,
                        Votes = userSubmitVotesDto.Votes.ConvertAll(x => new UserVote() { CommunityAwardCategory = x.CommunityAwardCategory, Selection = x.Selection })
                    };
                    dbContext.UserSubmissions.Add(userSubmission);
                }
                else
                {
                    userSubmission.Votes = userSubmitVotesDto.Votes.ConvertAll(x => new UserVote() { CommunityAwardCategory = x.CommunityAwardCategory, Selection = x.Selection });
                }

                // Save changes
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return await GetErrorResponseAsync(req, ex);
            }

            return req.CreateResponse(HttpStatusCode.OK);
        }

        [Function("get-user-data")]
        public async Task<HttpResponseData> GetUserData([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req,
            string userSlug)
        {
            if (string.IsNullOrEmpty(userSlug)) return req.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                long userId = Crypto.Decrypt(userSlug);
                UserData? userData = await dbContext.UserData.FirstOrDefaultAsync(x => x.UserId == userId);

                if (userData is null) return req.CreateResponse(HttpStatusCode.NotFound);

                UserRecapDataDto userRecapDataDto = new()
                {
                    Region = userData.Region,
                    RegisterDatetime = userData.RegisterDatetime,
                    Name = userData.Name,
                    FavoriteCostumeId = userData.FavoriteCostumeId,
                    TotalLoginCount = userData.TotalLoginCount,
                    Level = userData.Level,
                    MaxForce = userData.MaxForce,
                    DistanceWalked = userData.DistanceWalked,
                    CostumeCount = userData.CostumeCount,
                    WeaponCount = userData.WeaponCount,
                    CompanionCount = userData.CompanionCount,
                    MemoirCount = userData.MemoirCount,
                    DebrisCount = userData.DebrisCount,
                    AwakeningCount = userData.AwakeningCount,
                    ArenaRankings = userData.ArenaRankings,
                    SubjugationRankings = userData.SubjugationRankings,
                    ExplorationRankings = userData.ExplorationRankings
                };

                // Return the recap data
                var response = req.CreateResponse(HttpStatusCode.OK);
                await response.WriteAsJsonAsync(userRecapDataDto);

                return response;
            }
            catch (Exception ex)
            {
                return await GetErrorResponseAsync(req, ex);
            }
        }

        private static async Task<HttpResponseData> GetErrorResponseAsync(HttpRequestData req, Exception ex)
        {
            var errorResponse = req.CreateResponse(HttpStatusCode.InternalServerError);
            await errorResponse.WriteStringAsync(ex.Message + Environment.NewLine + ex.StackTrace);
            return errorResponse;
        }
    }
}
