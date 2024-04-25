let foo : string = 'I am a string'
let isTrue : boolean = true
let num : number = 1
num = 1.234847
let strArr : Array<string> = ['one', 'two', 'three', foo]
let numArr : Array<number> = [num, 1, 4, 6, 29]
let anotherStrArr : string[] = ["i", 'am', 'a', 'str', 'arr']
let bigNumber : bigint = 23987492387492837948263798476921873645901276450827340895720783465028976340957820n;
// Union Types
let numOrString : number | string = 'aujewlfiuh'
numOrString = 324827398
let numOrBoolOrStrOrArr : number | boolean | string | Array<string>;
numOrBoolOrStrOrArr = 2343
numOrBoolOrStrOrArr = true
numOrBoolOrStrOrArr = "hello, world!"
numOrBoolOrStrOrArr = anotherStrArr

// any and unknown
// Use any with extreme caution, not recommended
let iCanBeAnythingIWant : any = 1
iCanBeAnythingIWant = true
iCanBeAnythingIWant = {}
iCanBeAnythingIWant = [123, 'awefu', {}]

// function with return type and input param type 
function iReturnString(input: string) : string {
    return `string input: ${input}`
}

iReturnString('2384729')

let numOrBigInt : number | bigint = 23479283749283

// type narrowing, casting syntax
let numVar : number = numOrBigInt as number

// This following line is also valid casting syntax but it doesn't work with React due to syntax collision
let anotherNumVar : number = <number> numOrBigInt

// Interfaces and Types are good when you just want to define the shape of the object
interface Pet {
    name : string,
    id? : number,
    // id : number | null,
    color: string,
    doB : Date | string,
    hobbies : Hobby[]
}

type Hobby = {
    id? : number,
    name : string,
    description : string
}

function petAPet(pet : Pet) {
    console.log(`I'm petting ${pet.name}`)
}

// ducktyping of typescript
const obj =  {
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
}
// obj is still valid Pet Obj in this case eventhough it has a few other properties that does not exist in Pet interface
petAPet(obj)