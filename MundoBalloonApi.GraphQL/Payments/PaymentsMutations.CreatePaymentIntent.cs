using HotChocolate.AspNetCore.Authorization;
using MundoBalloonApi.business.Contracts;
using Stripe;

namespace MundoBalloonApi.graphql.Payments;

public partial class PaymentsMutations
{
    [Authorize]
    public async Task<string> CreatePaymentIntent(long amount,
        [Service] IPaymentsService paymentsService,
        CancellationToken cancellationToken)
    {
        var paymentIntent = await paymentsService.CreatePaymentIntent(amount, cancellationToken);
        return paymentIntent?.ClientSecret ?? "";
    }
}