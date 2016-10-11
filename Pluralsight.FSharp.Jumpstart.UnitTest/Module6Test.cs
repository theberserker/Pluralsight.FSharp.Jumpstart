using System.Threading.Tasks;
using Xunit;
using static Module6_ObjectOrientedTypes;

namespace Pluralsight.FSharp.Jumpstart.UnitTest
{
    public class Module6Test
    {
        [Fact]
        public void PersonFromInterface_GetsFullNameFromInterface_InterfaceValueCorrect()
        {
            var expected = "John Doe";
            var fSharpPerson = new PersonFromInterface("John", "Doe");
            var fullName = (fSharpPerson as IPerson).FullName; // this is where we have to cast in order to get the implemented interface's property
            Assert.Equal(expected, fullName);
        }


        [Fact]
        public void ContactPerson_ConstructsPhoneDU_IsPhoneAndIsNotEmail()
        {
            var duContactPerson = Contact.NewPhoneNumber("02", "321444555");

            Assert.True(duContactPerson.IsPhoneNumber);
            Assert.False(duContactPerson.IsEmailAddress);
        }

        [Fact]
        public void ContactPerson_ConstructsPrefferedContactDiscriminatedUnion_ReturnsPrefferedContactAsExpected()
        {
            string expectedCode = "02";
            string expectedNo = "321444555";

            var duPreferredContact = Contact.NewPhoneNumber("02", "321444555");
            var sut = new ContactPerson("John", "Doe", duPreferredContact);

            var actualContact = sut.PreferredContact as Contact.PhoneNumber;

            Assert.Equal(expectedCode, actualContact.AreaCode);
            Assert.Equal(expectedNo, actualContact.Number);
        }
    }
}
