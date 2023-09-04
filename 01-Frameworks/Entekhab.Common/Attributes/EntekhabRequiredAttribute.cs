using Entekhab.Common.Objects;
using System.ComponentModel.DataAnnotations;

namespace Entekhab.Common.Attributes;

public class EntekhabRequiredAttribute : RequiredAttribute
{
    public EntekhabRequiredAttribute() => ErrorMessage = ValidationMessages.FieldRequiredErrorMessage;
}