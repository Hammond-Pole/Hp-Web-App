namespace Hp_Web_App.Shared.Models;

[AttributeUsage(AttributeTargets.Property)]
public class ExcludeFromTableAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Property)]
public class PassForInfo : Attribute
{
}