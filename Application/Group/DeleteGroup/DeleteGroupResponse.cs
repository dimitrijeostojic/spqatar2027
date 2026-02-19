namespace Application.Group.DeleteGroup;

public sealed class DeleteGroupResponse
{
    public required Guid PublicId { get; set; }
    public required string GroupName { get; set; }
}
