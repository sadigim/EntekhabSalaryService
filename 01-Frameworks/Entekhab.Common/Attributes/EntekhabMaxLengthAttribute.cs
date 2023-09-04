using Entekhab.Common.Objects;
using System.ComponentModel.DataAnnotations;

namespace Entekhab.Common.Attributes;

public class EntekhabMaxLengthAttribute : MaxLengthAttribute
{
    public EntekhabMaxLengthAttribute(int maxLength) : base(maxLength) => ErrorMessage = ValidationMessages.FieldMaxLengthErrorMessage;
}