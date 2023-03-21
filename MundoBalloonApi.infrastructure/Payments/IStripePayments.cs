using FirebaseAdmin.Auth;
using Stripe;

namespace MundoBalloonApi.infrastructure.Payments;

public interface IStripePayments
{
    Task<PaymentIntent?> CreatePaymentIntent(long amount, string customerId,
        CancellationToken cancellationToken);

    Task<Customer?> CreateCustomer(CustomerCreateOptions customerCreateOptions,
        CancellationToken cancellationToken);

    Task<Customer?> GetCustomerByUserId(string userId, CancellationToken cancellationToken);

    Task<Customer?> GetCustomerByCustomerId(string customerId, CancellationToken cancellationToken);

    Task<Customer?> UpdateCustomerAddress(string customerId, string name, Address address,
        CancellationToken cancellationToken);

    public CustomerCreateOptions FirebaseUserToCustomer(UserRecord user);
}