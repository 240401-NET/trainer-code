

namespace dndConsoleApp.Tests;

public class CharacterTests
{

    //We want to in fact, return an integer
    //Lets test for that!
    //Standard format for unit test method name
    //ClassName_MethodName_ExpectedBehavior
    [Fact]
    public void Character_SimpleBattle_ReturnsInt()
    {
        //Arrange - Create any variables or objects you'll need for your test


        //Act - Call the code that you are trying to test
        var result = Character.SimpleBattle(1, 2);

        //Assert - Conditions under which the test will pass/fail

        //We ASSERT that the return type is going to be of type integer
        Assert.Equal(typeof(int), result.GetType());

    }


    //This is a theory test, with InlineData
    //Argument 1 is the first character's HP
    //Argument 2 is the second character's HP
    //Arugment 3 is the expected winner, either 1st or 2nd
    [Theory]
    [InlineData(10, 11, 2)]
    [InlineData(13, 4, 1)]
    //[InlineData(10, 10, 1)]
    public void Character_SimpleBattle_ReturnsHigherHPCharacter(int characterOneHP, int characterTwoHP, int winner)
    {


        //Arrange
        

        //Act
        int result = Character.SimpleBattle(characterOneHP, characterTwoHP);

        //Assert
        Assert.Equal(winner, result);

    }
}