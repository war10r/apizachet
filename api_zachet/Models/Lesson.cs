using System;
using System.Collections.Generic;

namespace api_zachet.Models;

public partial class Lesson
{
    public int LessonId { get; set; }

    public int TeacherId { get; set; }

    public int TariffId { get; set; }

    public DateOnly Date { get; set; }

    public string ClassroomNumber { get; set; } = null!;

    public virtual Tariff Tariff { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
