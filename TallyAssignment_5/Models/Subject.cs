using System;
using System.Collections.Generic;

namespace TallyAssignment_5.Models;

public partial class Subject
{
    public int SubId { get; set; }

    public string? SubName { get; set; }

    public int? MaxMarks { get; set; }

    public int? MarksObtained { get; set; }

    public int? StudId { get; set; }

    public virtual Student? Stud { get; set; }
    public int StudentStudId { get; internal set; }
}
