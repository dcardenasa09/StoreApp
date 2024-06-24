using FluentValidation;
using Store.Entities.DTOs;

namespace Store.Api.Validators;

public class PurchaseValidator : AbstractValidator<PurchaseDTO> {
    public PurchaseValidator() {
    }
}