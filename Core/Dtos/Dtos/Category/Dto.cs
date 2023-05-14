
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using TemplateFw.Resources;
using TemplateFw.Resources.Resources;

namespace TemplateFw.Dtos
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
		public string NameAr { get; set; }
		public string NameEn { get; set; }
		public string DescriptionAr { get; set; }
		public string DescriptionEn { get; set; }
		public bool IsAvailable { get; set; }
		public DateTime CreationDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }

    }

    public class CategoryInfoDto
    {
        public int CategoryId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsAvailable { get; set; }
		public DateTime CreationDate { get; set; }
		public string CreatedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public string ModifiedBy { get; set; }
    }

    public class CategoryFilter
    {
        public string Name { get; set; }
		public int LanguageId { get; set; } = 1;
		public int PageNumber { get; set; } = 1;
		public int PageSize { get; set; } = 20;
    }

    
    public class CategoryDtoInsertValidator : AbstractValidator<CategoryDto>
    {
        public CategoryDtoInsertValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.NameAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(100).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "100"))
			    .WithName("Category_NameAr");

			RuleFor(x => x.NameEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(100).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "100"))
			    .WithName("Category_NameEn");

			RuleFor(x => x.DescriptionAr)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(250).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "250"))
			    .WithName("Category_DescriptionAr");

			RuleFor(x => x.DescriptionEn)
			    .NotEmpty().WithMessage(validationLocalizer["RequiredEnter"])
			    .MaximumLength(250).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "250"))
			    .WithName("Category_DescriptionEn");


        }
    }
    
    public class CategoryDtoUpdateValidator : CategoryDtoInsertValidator
    {
        public CategoryDtoUpdateValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer):base(validationLocalizer, modulesLocalizer)
        {
			RuleFor(x => x.CategoryId)
			    .GreaterThan(0).WithMessage(validationLocalizer["RequiredEnter"])
			    .WithName("Category_CategoryId");


        }
    }
    
    public class CategoryFilterValidator : AbstractValidator<CategoryFilter>
    {
        public CategoryFilterValidator(IStringLocalizer<ValidationResource> validationLocalizer, IStringLocalizer<ModulesResource> modulesLocalizer)
        {
			RuleFor(x => x.Name)
			    .MaximumLength(100).WithMessage(validationLocalizer["MaxLengthCharacters"].Value.Replace("{Length}", "100"))
			    .WithName("Category_NameAr");


        }
    }
}
