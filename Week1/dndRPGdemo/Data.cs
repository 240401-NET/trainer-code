using System.IO;
using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace dndRPGdemo;

class Data 
{

    //
    //Read the file
    public static void LoadCharacters(ref List<Character> characters){

        try{
            string filePath = "characterList.json";
            string jsonCharacters = File.ReadAllText(filePath);

            // characters is assigned the deserialized list of characters from the jsonCharacters string. ~ Ricardo PenaMcKnight
            characters = JsonSerializer.Deserialize<List<Character>>(jsonCharacters);
            
            foreach(Character character in characters){
                character.ToString();
            }

        }catch(Exception e){
            Console.WriteLine("File not generated, first time execution!");
        }

    }



    //Write to the file
    public static void PersistCharacters(List<Character> characters){

        //Serializing the list of Character objects to a JSON string
        string jsonCharacters = JsonSerializer.Serialize(characters);

        //Verified that we created a JSON representation of our list
        //Console.WriteLine(jsonCharacters);

        string filePath = "characterList.json";

        File.WriteAllText(filePath, jsonCharacters);

    }




}