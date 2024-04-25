export default interface Pet {
    name : string,
    id? : number,
    // id : number | null,
    color: string,
    doB : Date | string,
    hobbies : Hobby[]
}