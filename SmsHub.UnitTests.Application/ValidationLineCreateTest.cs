using FluentValidation.TestHelper;
using SmsHub.Application.Features.Line.Validations;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmsHub.UnitTests.Application
{
    public class ValidationLineCreateTest
    {
        private LineValidator validator;

        public void Setup()
        {
            validator = new LineValidator();
        }

        [Fact]
        public void Should_have_error_when_Name_is_null()
        {
            var model = new CreateLineDto { Number = "465121",Credential="sdfj",ProviderId=Domain.Constants.ProviderEnum.Magfa};
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.Credential);
        }
        [Fact]
        public void NotAllowEmptyPostcode()
        {
            validator.= string.empty; // and then invalidate the specific things you want to test
            Validator.Validate(address).IsValid.Should().BeFalse();
        }
        [Fact]
        public void Should_not_have_error_when_name_is_specified()
        {
            var model = new CreateLineDto { Number= "421" };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(person => person.Number);
        }
    }
}
