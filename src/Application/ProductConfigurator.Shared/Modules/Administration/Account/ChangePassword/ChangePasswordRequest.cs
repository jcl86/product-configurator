using System;
using System.ComponentModel.DataAnnotations;

namespace ProductConfigurator.Shared.Modules.Administration.Account;

public class ChangePasswordRequest
{
    public string CurrentPassword { get; init; }

    public string NewPassword { get; set; } = default!;
}
