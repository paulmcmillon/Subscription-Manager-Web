namespace Subscriptions.Web.Requests
{
    public record SubscriptionType(
        int Id,
        string Name,
        string Description,
        decimal PriceMonthly,
        decimal PriceYearly
        );
}
