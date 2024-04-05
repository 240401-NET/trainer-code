# Design Principles

## OOP 4 Pillars (A PIE)
- Abstraction
  - Hiding unnecessary details and showing only what's necessary
  - C# implementaion example: Abstract classes and interfaces
  - For example: Animal abstract class, some class that is used as a template, template that can be extended by other classes, if wanna implement certain behaviors, we can use interfaces

- Encapsulation
  - Bundling of data and functionality into a single unit
  - Data Wrapping
    - Classes/concepts has related members 
  - Data Hiding
    - Protection levels
    - Access modifier (public, private, protected, *not default*... but internal)

- Polymorphism
  - One thing behaves like another thing
  - Overriding
  - Overloading
  - overriding vs overloading? 
    - overloading - happens in the same class. same name, different parameter(!!)
    - overriding - parent method -> update it in its child method
      - same name, same parameter, same return type -> same method signature
      - parent has to be either virtual/abstract, child has to use the modifier "override"
  
- Inheritance *use with caution*
  - Child classes inherit parent's properties and methods
  - code reuse

## [SOLID Principles](https://www.freecodecamp.org/news/solid-principles-explained-in-plain-english/)
- How to write better code -> meeting expectation of other developers and your team, getting uniformity in your code.
- Set of principles to build maintainable, scalable software

### Single Responsibility Principle
- Your code should only do one thing at a time, be responsible for just one thing
- Only put related functionalities together

### Open for extension/closed for modification
- Make sure your classes are "full" so you don't edit them later, and if you do have to edit that later on, use interface
- You should be able to add to the code without modifying existing code

### Liskov Substitution Principle
- Child class and its behavior should be able to substitute the parent class and its behavior
- this principle asks you to focus on your inheritance structure

### Interface Segregation
- Keep interfaces simple
- Your implementing classes shouldn't need to implement functionalities unnecessary to them

### Dependency Inversion
- Concrete classes should depend on abstract definition 

## Separation Of Concerns
- when class has its own functionality of related method and properties. 
- Similar to Encapsulation
- Similar to Single Responsibility

## DRY principle (Don't Repeat Yourself)
- if you see a bunch of repeated code, pull it out somewhere and reuse it

## KISS principle (Keep It Simple Stupid)
- Don't overengineer things
- Keep it as simple as possible

# [Design Patterns](https://refactoring.guru/design-patterns/catalog)
## What is it?
- "Typical solution to common problems"

## Singleton Pattern
- A pattern to have only one instance of a class
- Make constructor private, and just provide the instance when asked for.
- One instance per program
- In video games, main menu- wouldn't need to create multiple instance of that
- Logger - so the logged information goes to one place
- Printer queue

## Factory Method Pattern
- a way to dynamically create similar classes (ie they all implement the same interface or inherit from the same class) based on the user input/program need

## Dependency Injection
- A technique in which object or function objects receive the other required objects instead of creating them you just inject them
- reusability, flexibility
- For the demo, go take a look at Ulada's P0, dep-injection branch


### What's the difference between dependency injection and dependency inversion?