using System.ComponentModel;

namespace UniNote.Core.Enums;

public enum NotificationTypes
{
    [Description("issue.added")] IssueAdded = 1,
    [Description("issue.moved_to_on_approval")] IssueMovedToOnApproval = 2,
    [Description("issue.new_message")] IssueNewMessage = 3,
    [Description("issue.approval.success")] IssueApprovalSuccess = 4,
    [Description("issue.approval.fail")] IssueApprovalFail = 5,
    [Description("issue.violation")] IssueViolation = 6,
    [Description("issue.itw")] IssueItsTimeToWork = 7,

    [Description("regulation.added")] RegulationAdded = 10,
    [Description("regulation.changed")] RegulationChanged = 11,

    [Description("regulation.moved_to_on_approval")]
    RegulationMovedToOnApproval = 12,

    [Description("section.added")] SectionAdded = 15,
    [Description("section.updated")] SectionUpdated = 16
}