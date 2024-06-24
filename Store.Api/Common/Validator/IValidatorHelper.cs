namespace Store.Api.Common.Validator;

public interface IValidatorHelper<TDTO> {
    Task Validate(TDTO tDto);
}