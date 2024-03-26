using NierReincarnationRecap.Model.Enums;

namespace NierReincarnationRecap.Model.Dto;

public class SubjugationRankingDto
{
    public int Season { get; init; }

    public AttributeType AttributeType { get; init; }

    public long Score { get; init; }
}
