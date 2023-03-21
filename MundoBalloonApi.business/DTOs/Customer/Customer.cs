namespace MundoBalloonApi.business.DTOs.Customer;

public record Customer
{
    public string Id { get; set; } = "";
    public string? Name { get; set; }
    public Address? Address { get; set; }
}