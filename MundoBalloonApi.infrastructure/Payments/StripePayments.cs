using Stripe;

namespace MundoBalloonApi.infrastructure.Payments;

public class StripePayments
{

    public StripePayments(string stripeApiKey)
    {
        StripeConfiguration.ApiKey = stripeApiKey;
    }

    public Task<PaymentIntent?> CreatePaymentIntent(long amount, CancellationToken cancellationToken)
    {
        var paymentIntentService = new PaymentIntentService();
        var paymentIntent = paymentIntentService.CreateAsync(new PaymentIntentCreateOptions
        {
            Amount = amount,
            Currency = "usd",
            AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
            {
                Enabled = true,
            },
        }, null, cancellationToken);

        return paymentIntent;
    }
}