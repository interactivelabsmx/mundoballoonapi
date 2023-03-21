using HotChocolate.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Customer;

namespace MundoBalloonApi.graphql.Payments;

public partial class PaymentsMutations
{
    [Authorize]
    public async Task<Customer?> UpdateCustomerAddress(
        string customerId, string name, Address address,
        [Service] IPaymentsService paymentsService,
        CancellationToken cancellationToken)
    {
        return await paymentsService.UpdateCustomerAddress(customerId, name, address, cancellationToken);
    }
}