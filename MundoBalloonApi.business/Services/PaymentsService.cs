using Microsoft.Extensions.Configuration;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.infrastructure.Payments;
using Stripe;

namespace MundoBalloonApi.business.Services;

public class PaymentsService : IPaymentsService
{
    private readonly StripePayments _stripePayments;
    
    public PaymentsService(IConfiguration configuration)
    {
        var stripeApiKey = configuration.GetSection("Stripe:ApiKey").Value ?? "";
        _stripePayments = new StripePayments(stripeApiKey);
    }

    public Task<PaymentIntent?> CreatePaymentIntent(long amount, CancellationToken cancellationToken)
    {
        return _stripePayments.CreatePaymentIntent(amount, cancellationToken);
    }
}