using FirebaseAdmin.Auth;
using Stripe;

namespace MundoBalloonApi.infrastructure.Payments;

public class StripePayments : IStripePayments
{
    private const string MetadataFirebaseUserId = "firebase_user_id";

    public StripePayments(string stripeApiKey)
    {
        StripeConfiguration.ApiKey = stripeApiKey;
        CustomerService = new CustomerService();
        PaymentIntentService = new PaymentIntentService();
    }

    private CustomerService CustomerService { get; }
    private PaymentIntentService PaymentIntentService { get; }

    public async Task<PaymentIntent?> CreatePaymentIntent(long amount, string customerId,
        CancellationToken cancellationToken)
    {
        return await PaymentIntentService.CreateAsync(new PaymentIntentCreateOptions
        {
            Customer = customerId,
            SetupFutureUsage = "off_session",
            Amount = amount,
            Currency = "usd",
            AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
            {
                Enabled = true
            }
        }, null, cancellationToken);
    }

    public Task<Customer?> CreateCustomer(CustomerCreateOptions customerCreateOptions,
        CancellationToken cancellationToken)
    {
        return CustomerService.CreateAsync(customerCreateOptions, null, cancellationToken);
    }

    public async Task<Customer?> GetCustomerByUserId(string userId, CancellationToken cancellationToken)
    {
        var result = await CustomerService.SearchAsync(
            new CustomerSearchOptions { Query = $"metadata['{MetadataFirebaseUserId}']:'{userId}'" }, null,
                cancellationToken);
        return result.Data.FirstOrDefault(c => c.Metadata.ContainsValue(userId));
    }

    public Task<Customer?> GetCustomerByCustomerId(string customerId, CancellationToken cancellationToken)
    {
        return CustomerService.GetAsync(customerId, null, null,
            cancellationToken);
    }

    public Task<Customer?> UpdateCustomerAddress(string customerId, string name, Address address,
        CancellationToken cancellationToken)
    {
        var options = new CustomerUpdateOptions
        {
            Name = name,
            Address = new AddressOptions
            {
                City = address.City,
                Country = address.Country,
                Line1 = address.Line1,
                Line2 = address.Line2,
                PostalCode = address.PostalCode,
                State = address.State
            }
        };
        return CustomerService.UpdateAsync(customerId, options, null, cancellationToken);
    }

    public CustomerCreateOptions FirebaseUserToCustomer(UserRecord user)
    {
        return new CustomerCreateOptions
        {
            Email = user.Email,
            Phone = user.PhoneNumber,
            Name = user.DisplayName,
            Metadata = new Dictionary<string, string>
            {
                { MetadataFirebaseUserId, user.Uid }
            }
        };
    }
}