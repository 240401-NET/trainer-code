"use strict";
let foo = 'I am a string';
let isTrue = true;
let num = 1;
num = 1.234847;
let strArr = ['one', 'two', 'three', foo];
let numArr = [num, 1, 4, 6, 29];
let anotherStrArr = ["i", 'am', 'a', 'str', 'arr'];
let bigNumber = 23987492387492837948263798476921873645901276450827340895720783465028976340957820n;
// Union Types
let numOrString = 'aujewlfiuh';
numOrString = 324827398;
let numOrBoolOrStrOrArr;
numOrBoolOrStrOrArr = 2343;
numOrBoolOrStrOrArr = true;
numOrBoolOrStrOrArr = "hello, world!";
numOrBoolOrStrOrArr = anotherStrArr;
// any and unknown
// Use any with extreme caution, not recommended
let iCanBeAnythingIWant = 1;
iCanBeAnythingIWant = true;
iCanBeAnythingIWant = {};
iCanBeAnythingIWant = [123, 'awefu', {}];
// function with return type and input param type 
function iReturnString(input) {
    return `string input: ${input}`;
}
iReturnString('2384729');
let numOrBigInt = 23479283749283;
// type narrowing, casting syntax
let numVar = numOrBigInt;
// This following line is also valid casting syntax but it doesn't work with React due to syntax collision
let anotherNumVar = numOrBigInt;
function petAPet(pet) {
    console.log(`I'm petting ${pet.name}`);
}
// ducktyping of typescript
const obj = {
    name: 'auryn',
    color: 'gray',
    doB: '2012-03-04',
    someotherProp: 'weurhwu',
    prop2: 'aweuifhiwe',
    hobbies: [
        {
            name: 'napping',
            description: 'better outside'
        }
    ]
};
// obj is still valid Pet Obj in this case eventhough it has a few other properties that does not exist in Pet interface
petAPet(obj);
