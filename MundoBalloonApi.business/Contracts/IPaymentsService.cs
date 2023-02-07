using Stripe;

namespace MundoBalloonApi.business.Contracts;

public interface IPaymentsService
{
    Task<PaymentIntent?> CreatePaymentIntent(long amount, CancellationToken cancellationToken);
}