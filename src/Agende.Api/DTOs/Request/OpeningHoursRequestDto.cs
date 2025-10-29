namespace Agende.Api.DTOs.Request;

public class ScheduleRequestDto
{
    public DayOfWeek DayOfWeek { get; set; }
    public List<IntervalDto> Intervals { get; set; } = [];
}

public class IntervalDto
{
    public TimeSpan Start { get; set; }
    public TimeSpan End { get; set; }
}