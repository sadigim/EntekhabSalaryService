using Entekhab.Common.Objects;
using System.ComponentModel.DataAnnotations;

namespace Entekhab.Common.Attributes;

public class EntekhabRangeAttribute : RangeAttribute
{
    public EntekhabRangeAttribute(int minimum, int maximum) : base(minimum, maximum) => ErrorMessage = ValidationMessages.FieldRangeErrorMessage;
}