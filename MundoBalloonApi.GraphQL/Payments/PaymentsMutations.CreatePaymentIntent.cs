using HotChocolate.Authorization;
using MundoBalloonApi.business.Contracts;

namespace MundoBalloonApi.graphql.Payments;

public partial class PaymentsMutations
{
    [Authorize]
    public async Task<string> CreatePaymentIntent(long amount, string customerId,
        [Service] IPaymentsService paymentsService,
        CancellationToken cancellationToken)
    {
        var paymentIntent = await paymentsService.CreatePaymentIntent(amount, customerId, cancellationToken);
        return paymentIntent?.ClientSecret ?? "";
    }
}