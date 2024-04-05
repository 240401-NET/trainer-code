// See https://aka.ms/new-console-template for more information
using System.Numerics;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");

//Casting

//Upcasting - smaller to larger

int simpleNumber = 4;
double newNumber = simpleNumber;

Console.WriteLine(simpleNumber);
Console.WriteLine(newNumber);

//Downcasting - larger to smaller

double num1 = 4.99;

//Explicit casting of a double into an integer
int num2 = (int)num1;

Console.WriteLine(num1);
Console.WriteLine(num2);

//Boxing and unboxing - changing a value type into a reference type, and vice versa

//Value type, an integer
int i = 324;

//Boxing my integer into an object (reference type), that lives on the heap and is garbage collected.
object o = i;

// Java Code
// ArrayList<Integer> intList = new ArrayList<Integer>();
List<double> doubleList = new();

// System.Collections -> Non-generic collections ArrayList, List
// ['string', 1, {name: val}, [], bool] <- js array
// non generics basically do ^ that
ArrayList list = new ArrayList();
list.Add(new object());
list.Add(1);
list.Add(true);
// In non-generic collections Everything is stored as object
// Don't use non-generic collections

// System.Collections.Generic -> Generic collections List<T>
doubleList.Add(1);
doubleList.Add(100000);
doubleList.Add(3.3333);
// doubleList.Add(true); //no can do

//LINQ! Language Integrated Query

//List of cities 
List<string> cities = new(){
    "Boston",
    "Portland",
    "Miami",
    "Twin Cities",
    "Fargo",
    "Seattle",
    "Fort Lauderdale",
    "Atlanta",
    "London",
    "San Francisco",
    "San Jose",
    "San Diego",
    "Athens",
    "San Antonio",
    "Austin",
    "Chicago"
};

//Prompting the user for a search term
Console.WriteLine("Please enter a city to search for:");
string searchTerm = Console.ReadLine();

//Using LINQ to query this list

List<string> searchResults = cities.Where(city => city.Contains(searchTerm)).ToList();

//Display the results
Console.WriteLine("Cities found:");


foreach (string city in searchResults)
{
    Console.WriteLine(city);
}

//Using the vehicle derived classes

Plane myPlane = new();

myPlane.useFuel();
myPlane.Driving();
myPlane.makeNoise();