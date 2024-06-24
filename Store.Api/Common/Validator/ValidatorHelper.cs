using FluentValidation;

namespace Store.Api.Common.Validator;

public class ValidatorHelper<TDTO> : IValidatorHelper<TDTO> {

    private readonly IEnumerable<IValidator<TDTO>> _validators;

    public ValidatorHelper(IEnumerable<IValidator<TDTO>> validators) {
        _validators = validators;
    }

    public async Task Validate(TDTO tDto) {
        if (_validators.Any()) {
            var context = new ValidationContext<TDTO>(tDto);

            var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context))
            );

            var failures = validationResults.Where(r => r.Errors.Count != 0)
                                            .SelectMany(r => r.Errors)
                                            .ToList();

            if (failures.Count != 0) {
                throw new ValidationException(failures);
            }
        }
    }
}