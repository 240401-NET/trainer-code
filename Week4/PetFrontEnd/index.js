function getAllPets() {
    fetch('http://localhost:5242/api/Pet')
        .then(res => res.json())
        .then(resBody => {
            console.log(resBody)
            displayPets(resBody)
        })
}

function displayPets(pets) {
    // {id: 1, name: 'Auryn', doB: '0000-00-00',}
    const petTable = document.querySelector('#pets-table')
    const tBody = petTable.tBodies[0]
    tBody.innerHTML = ''
    // 3 different types of for loops in js
    // regular for loop 
    // for ... in iterates over keys
    // for ... of iterates over values
    // for(const pet of pets){
    //     // 1. Create tr element
    //     // 2. Inside the tr element, I want to create 4 td's
    //     // 3. fill those td's with data and append them to tr
    //     // 4. append tr element to tBody
    //     const tableRow = document.createElement('tr')
    //     const idCell = document.createElement('td')
    //     idCell.innerHTML = pet.id
    //     tableRow.appendChild(idCell)
    
    //     const nameCell = document.createElement('td')
    //     nameCell.innerHTML = pet.name
    //     tableRow.appendChild(nameCell)
    
    //     const colorCell = document.createElement('td')
    //     colorCell.innerHTML = pet.color
    //     tableRow.appendChild(colorCell)
    
    //     const dobCell = document.createElement('td')
    //     dobCell.innerHTML = pet.doB
    //     tableRow.appendChild(dobCell)
    
    //     tBody.appendChild(tableRow)
    // }

    for(const pet of pets) {
        const tableRow = tBody.insertRow(-1)
        const idCell = tableRow.insertCell(0);
        idCell.innerText = pet.id
        idCell.className = "thick-border"
        idCell.style = "color: blue"
        tableRow.insertCell(1).innerText = pet.name
        tableRow.insertCell(2).innerText = pet.color
        tableRow.insertCell(3).innerText = pet.doB
    }
}
async function addPets(pet) {
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
const pet = {
    name: 'Clifford',
    color: 'Red',
    hobbies: [
        {
            name: 'Being Big',
            description: 'Clifford The Big Red Dog'
        }
    ]
}

async function handleSubmit(e) {
    // Prevent page refreshing, which is the default behavior of form submit event
    e.preventDefault()

    const formData = new FormData(e.target);
    const formProps = Object.fromEntries(formData);
    
    let reqBody = {
        name: formProps.name,
        color: formProps.color,
        hobbies: []
    }
    await addPets(reqBody)
    getAllPets()
}
async function setUp() {
    await addPets(pet)
    getAllPets()
}
getAllPets()
