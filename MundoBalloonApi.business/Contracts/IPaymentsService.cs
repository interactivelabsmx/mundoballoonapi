using FirebaseAdmin.Auth;
using Stripe;
using Address = MundoBalloonApi.business.DTOs.Customer.Address;
using Customer = MundoBalloonApi.business.DTOs.Customer.Customer;

namespace MundoBalloonApi.business.Contracts;

public interface IPaymentsService
{
    Task<PaymentIntent?> CreatePaymentIntent(long amount, string customerId, CancellationToken cancellationToken);

    Task<Customer?> CreateCustomer(UserRecord user, CancellationToken cancellationToken);

    Task<Customer?> UpdateCustomerAddress(string customerId, string name, Address address,
        CancellationToken cancellationToken);
}