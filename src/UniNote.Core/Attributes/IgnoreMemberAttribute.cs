namespace UniNote.Core.Attributes;

// source: https://github.com/jhewlett/ValueObject
// excludes property from memberwise comparison in ValueObject 
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class IgnoreMemberAttribute : Attribute
{
}