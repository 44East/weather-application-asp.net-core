namespace WeatherApp.Data.WeatherDataTemplate.DailyDetaiedTemplate
{
    /// <summary>
    /// Represents a weather headline.
    /// </summary>
    /// <param name="EffectiveDate">The effective date of the headline.</param>
    /// <param name="EffectiveEpochDate">The epoch date of the effective date.</param>
    /// <param name="Severity">The severity of the headline.</param>
    /// <param name="Text">The text of the headline.</param>
    /// <param name="Category">The category of the headline.</param>
    /// <param name="EndDate">The end date of the headline.</param>
    /// <param name="EndEpochDate">The epoch date of the end date.</param>
    /// <param name="MobileLink">The mobile link for more details.</param>
    /// <param name="Link">The link for more details.</param>
    public record Headline
    (
        DateTime EffectiveDate, 
        int EffectiveEpochDate, 
        int Severity, 
        string Text, 
        string Category, 
        DateTime? EndDate, 
        int? EndEpochDate, 
        string MobileLink, 
        string Link
    );
}
