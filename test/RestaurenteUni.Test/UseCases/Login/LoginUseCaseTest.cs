using Microsoft.EntityFrameworkCore;
using RestauranteUni.Application.UseCases.Login;
using RestauranteUni.Data;
using RestauranteUni.Domain.Login;
using RestauranteUni.Domain.UseCases;
using System.Net;
using RestauranteUni.Application.UseCases.Login.Validations;

namespace RestaurenteUni.Test.UseCases.Login
{
    public class LoginUseCaseTest
    {
        private ApplicationDbContext _context;
        private IUseCaseHandler<LoginDto, LoginResponseDto> _handler;


        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);
            _context.Database.EnsureCreated();
            _handler = new LoginUseCaseHandler(_context, new LoginUseCaseDtoValidation());

        }


        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        // Account not found by e-mail, should return 401  with error message (Invalid credentials) 


        [Test]
        public async Task ShouldReturnUnauthorized_WhenNotFoundAccountByEmail()
        {
            var loginDto = CreateValidLoginDto();
            var result = await _handler.HandleAsync(loginDto);

            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.Validations.Count, Is.EqualTo(1));
                Assert.That(result.Validations.First().Errors, Contains.Item("Invalid credentials"));
                Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));
            });
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("diego")]
        [TestCase("diego.com")]
        [TestCase("@gmail.com")]
        [TestCase("diego@")]
        [TestCase("diego@gmail")]
        [TestCase("diego@@gmail.com")]

        public async Task ShouldReturnBadRequest_WhenEmailIsInvalid(string email)
        {
            var loginDto = new LoginDto(email, ""); 

            var result = await _handler.HandleAsync(loginDto);

            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.Validations.Count, Is.EqualTo(1));
                Assert.That(result.Validations.First().Errors, Contains.Item($"Invalid {nameof(LoginDto.Email)}"));
                Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            });
        }

        [TestCase("")]
        [TestCase(" ")]
        public async Task ShouldReturnBadRequest_WhenPasswordIsInvalid(string password)
        {
            var loginDto = new LoginDto("diego@gmail.com", password);

            var result = await _handler.HandleAsync(loginDto);

            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.Validations.Count, Is.EqualTo(1));
                Assert.That(result.Validations.First().Errors, Contains.Item($"Invalid {nameof(LoginDto.Password)}"));
                Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            });
        }

        [TestCase("", "")]
        [TestCase(" ", " ")]
        [TestCase("diego", " ")]
        [TestCase("diego.com", " ")]
        [TestCase("@gmail.com", " ")]
        [TestCase("diego@", " ")]
        [TestCase("diego@gmail", " ")]
        [TestCase("diego@@gmail.com", " ")]

        public async Task ShouldReturnBadRequest_WhenEmailAndPasswordIsInvalid(string email, string password)
        {
            var loginDto = new LoginDto(email, password);

            var result = await _handler.HandleAsync(loginDto);

            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.Validations.Count, Is.EqualTo(1));
                Assert.That(result.Validations.First().Errors, Contains.Item($"Invalid {nameof(LoginDto.Email)}"));
                Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            });
        }


        private LoginDto CreateValidLoginDto()
        {
            return new LoginDto("diego@gmail.com", "senha123@");
        }


        //public async Task 

    }



}
