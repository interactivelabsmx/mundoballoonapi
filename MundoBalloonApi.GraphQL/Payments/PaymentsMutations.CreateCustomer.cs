using FirebaseAdmin.Auth;
using HotChocolate.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Entities;
using Customer = MundoBalloonApi.business.DTOs.Customer.Customer;

namespace MundoBalloonApi.graphql.Payments;

public partial class PaymentsMutations
{
    [Authorize]
    public async Task<Customer?> CreateCustomer(
        [GlobalState("currentUser")] CurrentUser currentUser,
        [Service] IPaymentsService paymentsService,
        CancellationToken cancellationToken)
    {
        var user = await FirebaseAuth.DefaultInstance.GetUserAsync(currentUser.UserId, cancellationToken);
        if (user == null) return null;

        var customer = await paymentsService.CreateCustomer(user, cancellationToken);
        return customer;
    }
}