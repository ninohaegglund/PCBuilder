namespace PCBuilder.Service.OrderAPI.Utility;

public class SD
{
    public static string? OrderSAPIBase { get; set; }
    public enum ApiType
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}
