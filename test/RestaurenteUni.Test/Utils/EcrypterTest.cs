using RestauranteUni.Application.Utils;
using RestauranteUni.Domain.Utils;

namespace RestaurenteUni.Test.Utils
{
    public sealed class EcrypterTest
    {

        private IEcrypter _crypter;
        [SetUp]
        public void Setup()
        {
            _crypter = new Ecrypter();
        }
        [TestCase("")]
        [TestCase(null)]
        [TestCase(" ")]
        public void ShouldThrowArgumentException_WhenPasswordIsInvalid(string? password)
        {
            Assert.Throws(Is.TypeOf<ArgumentException>().Or.TypeOf<ArgumentNullException>(),
                () => _crypter.HashPassword(password!));
        }
    }
}
