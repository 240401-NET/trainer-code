namespace EFCharacter;

public partial class Character
{
    public override string ToString() {
        return $"Id: {this.Id} \nName: {this.Name} \nHP:{this.Hitpoints} \nAge: {this.Age} \nGender: {this.Gender}";
    }
}