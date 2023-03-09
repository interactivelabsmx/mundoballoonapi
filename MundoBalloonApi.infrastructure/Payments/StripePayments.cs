using FirebaseAdmin.Auth;
using Stripe;

namespace MundoBalloonApi.infrastructure.Payments;

public class StripePayments
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
        var paymentIntent = await PaymentIntentService.CreateAsync(new PaymentIntentCreateOptions
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

        return paymentIntent;
    }

    public Task<Customer?> CreateCustomer(CustomerCreateOptions customerCreateOptions,
        CancellationToken cancellationToken)
    {
        return CustomerService.CreateAsync(customerCreateOptions, null, cancellationToken);
    }

    public Task<Customer?> GetCustomerById(string id, CancellationToken cancellationToken)
    {
        return CustomerService.GetAsync(id, null, null, cancellationToken);
    }

    public async Task<Customer?> GetCustomerByUserId(string userId, CancellationToken cancellationToken)
    {
        var result = await CustomerService.SearchAsync(
            new CustomerSearchOptions { Query = $"metadata['{MetadataFirebaseUserId}']:'{userId}'" }, null,
            cancellationToken);
        var customer = result.Data.FirstOrDefault(c => c.Metadata.ContainsValue(userId));
        return customer;
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