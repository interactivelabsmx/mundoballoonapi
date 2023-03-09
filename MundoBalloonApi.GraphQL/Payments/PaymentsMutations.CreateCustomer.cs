using FirebaseAdmin.Auth;
using HotChocolate.Authorization;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.business.DTOs.Customer;
using MundoBalloonApi.business.DTOs.Entities;

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