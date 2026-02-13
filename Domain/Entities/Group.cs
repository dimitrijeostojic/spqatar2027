namespace Domain.Entities;

public sealed class Group : Entity
{
    public Group(string groupName)
    {
        GroupName = groupName;
    }
    public string GroupName { get; private set; }
    public ICollection<Team> Teams { get; set; } = [];


    public static Group Create(string groupName)
    {
        return new Group(groupName)
        {
            GroupName = groupName
        };
    }
}
