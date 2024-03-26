using NierReincarnationRecap.Model.Enums;

namespace NierReincarnationRecap.Model.Dto;

public class UserSubmissionDto
{
    public Guid Token { get; set; }

    public List<UserVoteDto> Votes { get; set; } = [];
}

public class UserVoteDto
{
    public CommunityAwardCategory CommunityAwardCategory { get; set; }

    public int Selection { get; set; }
}
