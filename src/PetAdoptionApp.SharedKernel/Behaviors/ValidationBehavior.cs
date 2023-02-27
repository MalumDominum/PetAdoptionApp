﻿using MediatR;
using ErrorOr;
using FluentValidation;

namespace PetAdoptionApp.SharedKernel.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : IRequest<TResponse>
	where TResponse : IErrorOr
{
	private readonly IValidator<TRequest>? _validator;

	public ValidationBehavior(IValidator<TRequest>? validator = null)
	{
		_validator = validator;
	}

	public async Task<TResponse> Handle(
		TRequest request,
		RequestHandlerDelegate<TResponse> next,
		CancellationToken cancellationToken)
	{
		if (_validator == null) return await next();

		var validationResult = await _validator.ValidateAsync(request, cancellationToken);
		if (validationResult.IsValid)
			return await next();

		var errors = validationResult.Errors
			.ConvertAll(vFailure => Error.Validation(vFailure.PropertyName, vFailure.ErrorMessage));

		return (dynamic)errors;
	}
}
