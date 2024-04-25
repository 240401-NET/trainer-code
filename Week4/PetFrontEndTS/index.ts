import { Hobby } from "./hobby"
import Pet from "./pet"

function getAllPets() : void {
    fetch('http://localhost:5242/api/Pet')
        .then(res => res.json())
        .then(resBody => {
            console.log(resBody)
            displayPets(resBody)
        })
}

function displayPets(pets : Array<Pet>) {
    // {id: 1, name: 'Auryn', doB: '0000-00-00',}
    const petTable : HTMLTableElement | null = document.querySelector('#pets-table')
    if(petTable) {
        const tBody : HTMLTableSectionElement = petTable.tBodies[0] 
        tBody.innerHTML = ''
    
        for(const pet of pets) {

            const tableRow : HTMLTableRowElement = tBody.insertRow(-1)
            const idCell : HTMLTableCellElement = tableRow.insertCell(0);
            idCell.innerText = pet.id?.toString() ?? 'n/a' 
            idCell.className = "thick-border"
            idCell.style.color = "blue"

            tableRow.insertCell(1).innerText = pet.name
            tableRow.insertCell(2).innerText = pet.color
            // tableRow.insertCell(3).innerText = pet.doB.toString()
            tableRow.insertCell(3).innerText = pet.doB instanceof Date ? pet.doB.toString() : pet.doB;


        }
    }
}
async function addPets(pet: Pet) {
    const res = await fetch('http://localhost:5242/api/Pet', {
        method: 'POST',
        body: JSON.stringify(pet),
        headers: {
            'Content-Type': 'application/json'
        }
    })
    const resBody = await res.json()
    console.log(resBody)
} 
const pet : Pet = {
    name: 'Clifford',
    color: 'Red',
    hobbies: [
        {
            name: 'Being Big',
            description: 'Clifford The Big Red Dog'
        }
    ],
    doB: '1972-04-25'
}

async function handleSubmit(e: Event) : Promise<void>{
    // Prevent page refreshing, which is the default behavior of form submit event
    e.preventDefault()

    const formData = new FormData(e.target as HTMLFormElement);
    const formProps = Object.fromEntries(formData);
    
    let reqBody : Pet = {
        name: formProps.name.toString(),
        color: formProps.color.toString(),
        hobbies: [],
        doB: '0001-01-01'
    }
    await addPets(reqBody)
    getAllPets()
}

getAllPets()
