namespace WeatherApp.Data.WeatherDataTemplate.DailyDetaiedTemplate
{
    /// <summary>
    /// Represents moon information.
    /// </summary>
    /// <param name="Rise">The time of moonrise.</param>
    /// <param name="EpochRise">The epoch time of moonrise.</param>
    /// <param name="Set">The time of moonset.</param>
    /// <param name="EpochSet">The epoch time of moonset.</param>
    /// <param name="Phase">The phase of the moon.</param>
    /// <param name="Age">The age of the moon in days.</param>
    public record Moon
    (
        DateTime? Rise, 
        int? EpochRise, 
        DateTime? Set, 
        int? EpochSet, 
        string? Phase, 
        int? Age
    );
}
