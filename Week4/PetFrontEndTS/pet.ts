export default interface Pet {
    name : string,
    id? : number,
    // id : number | undefined,
    color: string,
    doB : Date | string,
    hobbies : Hobby[]
}