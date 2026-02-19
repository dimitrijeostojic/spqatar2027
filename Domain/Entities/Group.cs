
namespace Domain.Entities;

public sealed class Group(string groupName) : Entity
{
    public string? GroupName { get; private set; } = groupName;
    public ICollection<Team> Teams { get; set; } = [];


    public static Group Create(string groupName)
    {
        return new Group(groupName)
        {
            GroupName = groupName
        };
    }

    public Group UpdateGroupName(string groupName)
    {
        GroupName = groupName;
        return this;
    }
}
