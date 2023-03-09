using AutoMapper;
using FirebaseAdmin.Auth;
using Microsoft.Extensions.Configuration;
using MundoBalloonApi.business.Contracts;
using MundoBalloonApi.infrastructure.Payments;
using Stripe;
using Customer = MundoBalloonApi.business.DTOs.Customer.Customer;

namespace MundoBalloonApi.business.Services;

public class PaymentsService : IPaymentsService
{
    private readonly StripePayments _stripePayments;
    private readonly IMapper _mapper;

    public PaymentsService(IConfiguration configuration, IMapper mapper)
    {
        var stripeApiKey = configuration.GetSection("Stripe:ApiKey").Value ?? "";
        _stripePayments = new StripePayments(stripeApiKey);
        _mapper = mapper;
    }

    public Task<PaymentIntent?> CreatePaymentIntent(long amount, string customerId, CancellationToken cancellationToken)
    {
        return _stripePayments.CreatePaymentIntent(amount, customerId, cancellationToken);
    }

    public async Task<Customer?> CreateCustomer(UserRecord user, CancellationToken cancellationToken)
    {
        var customer = await _stripePayments.GetCustomerByUserId(user.Uid, cancellationToken);
        if (customer != null) return _mapper.Map<Customer>(customer);

        var customerCreateOptions = _stripePayments.FirebaseUserToCustomer(user);
        var newCustomer = await _stripePayments.CreateCustomer(customerCreateOptions, cancellationToken);
        return newCustomer != null ? _mapper.Map<Customer>(newCustomer) : null;
    }
}