using FirebaseAdmin.Auth;
using Stripe;
using Customer = MundoBalloonApi.business.DTOs.Customer.Customer;

namespace MundoBalloonApi.business.Contracts;

public interface IPaymentsService
{
    Task<PaymentIntent?> CreatePaymentIntent(long amount, string customerId, CancellationToken cancellationToken);

    Task<Customer?> CreateCustomer(UserRecord user, CancellationToken cancellationToken);
}