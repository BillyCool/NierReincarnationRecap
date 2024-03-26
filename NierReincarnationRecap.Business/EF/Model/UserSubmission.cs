using Microsoft.EntityFrameworkCore;
using NierReincarnationRecap.Model.Enums;

namespace NierReincarnationRecap.Business.EF.Model;

[PrimaryKey(nameof(Token))]
public class UserSubmission
{
    public required Guid Token { get; set; }

    public required List<UserVote> Votes { get; set; }
}

public class UserVote
{
    public required CommunityAwardCategory CommunityAwardCategory { get; set; }

    public required int Selection { get; set; }
}
