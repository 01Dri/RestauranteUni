using Microsoft.EntityFrameworkCore;
using RestauranteUni.Application.UseCases.Account;
using RestauranteUni.Application.UseCases.Account.Validations;
using RestauranteUni.Data;
using RestauranteUni.Domain.Account.DTO;
using RestauranteUni.Domain.UseCases;

namespace RestaurenteUni.Test.UseCases.Account
{
    public class CreateAccountUseCaseTest
    {

        private IUseCaseHandler<CreateAccountDto, CreateAccountResponseDto> _handler;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _handler = new CreateAccountUseCaseHandler(new ApplicationDbContext(options), new CreateAccountDtoValidation());
        }


        [Test]
        public async Task ShouldThrowValidationExceptionWhenEmailIsInvalid()
        {
            var createDto = new CreateAccountDto()
            {
                Email = "diego.com",
                Password = "",
                BirthDate = DateTime.Now
            };

            var result = await _handler.HandleAsync(createDto);
            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.Validations, Is.Not.Empty);

                var emailValidation = result.Validations
                    .FirstOrDefault(x => x.Property == "Email");

                Assert.That(emailValidation, Is.Not.Null);
                Assert.That(emailValidation!.ErrorMessage, Is.EqualTo("Invalid e-mail"));
            });

        }
    }
}
