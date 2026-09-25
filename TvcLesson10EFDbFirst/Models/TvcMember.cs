using System;
using System.Collections.Generic;

namespace TvcLesson10EFDbFirst.Models;

public partial class TvcMember
{
    public long Id { get; set; }

    public string? TvcUserName { get; set; }

    public string? TvcPassword { get; set; }

    public string? TvcFullName { get; set; }

    public string? TvcEmail { get; set; }

    public string? TvcPhone { get; set; }

    public bool? TvcStatus { get; set; }
}
