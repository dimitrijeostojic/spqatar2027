
namespace Domain.Entities;

public sealed class Group : Entity
{
    public string? GroupName { get; private set; }
    public ICollection<Team> Teams { get; set; } = [];


    public static Group Create(string groupName)
    {
        return new Group()
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
