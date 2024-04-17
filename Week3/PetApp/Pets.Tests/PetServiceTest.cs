using Moq;
using Pets.Data;
using Pets.Services;
using Pets.Models;


namespace Pets.Tests;

public class PetServiceTest
{
    [Fact]
    public void PetSeriveShouldGetAllPets()
    {
        // Arrange
        Mock<IPetRepository> repoMock = new Mock<IPetRepository>();

        IEnumerable<Pet> fakePets = [
            new Pet{
                Id = 1,
                Name = "Test Pet",
                Color = "Rainbow"
            }
        ];

        repoMock.Setup(repo => repo.GetAllPets()).Returns(fakePets);
        PetService service = new PetService(repoMock.Object);

        //Act
        IEnumerable<Pet> allPets = service.GetAllPets();
        
        //Assert
        // Check to verify we actually got the data we faked
        Assert.Single(allPets);
        // Also check that GetAllPets of PetRepository was called Only Once
        repoMock.Verify(repo => repo.GetAllPets(), Times.Exactly(1));
    }

    [Theory]
    [InlineData("123djkhiu")]
    [InlineData("")]
    [InlineData("1")]
    [InlineData("a")]
    public void GetPetsByNameShouldNotAllowInvalidNames(string name) {
        // Arrange
        Mock<IPetRepository> repoMock = new Mock<IPetRepository>();

        PetService service = new PetService(repoMock.Object);

        Assert.Throws<FormatException>(() => service.GetPetsByName(name));
        repoMock.Verify(repo => repo.GetPetsByName(name), Times.Exactly(0));
    }

    [Theory]
    [InlineData("wheui")]
    [InlineData("Auryn")]
    [InlineData("aurynaur1y")]
    [InlineData("       bebicat")]
    [InlineData("aa")]
    public void GetPetsByNameShouldAllowValidNames(string name) {
        
        // Arrange
        Mock<IPetRepository> repoMock = new Mock<IPetRepository>();

        IEnumerable<Pet> fakePets = [
            new Pet{
                Id = 1,
                Name = name.Trim(),
                Color = "Rainbow"
            }
        ];

        // we set up repo to repond to "        bebicat" input
        // but Service called repo with "bebicat" input
        repoMock.Setup(repo => repo.GetPetsByName(name.Trim())).Returns(fakePets);
        PetService service = new PetService(repoMock.Object);

        //Act
        IEnumerable<Pet> allPets = service.GetPetsByName(name);

        //Assert
        Assert.Single(allPets);
        
    }
}
