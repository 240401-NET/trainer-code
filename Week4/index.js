// (function fubar() {
//     for(var i = 0; i < 1000; i++) {
//         // do fancy stuff here
//     }
//     console.log(i)
    
// })() //IIFE ("Immediately Invoked Function Expression")

function clickHandler(e, elemName) {
    console.log('you clicked me!', e, elemName)
    e.stopPropagation()
}

function handleMouseOver() {
    console.log('mouse over event happened')
}

function waitDontGo() {
    alert('wait! Don\'t go!')
}

function getNewDivs() {
    let newDiv = document.createElement('div');
    
    newDiv.innerHTML = "I'm a new div!";
    newDiv.style = "color: blue";
    setTimeout(() => {
        document.body.removeChild(newDiv)
    }, 1000)
    newDiv.onmouseover = () => {
        console.log('I was stroked')
    }
    const divContainer = document.getElementById('div-container');
    document.body.appendChild(newDiv)
}

// Callback function example
function iCallOthers(cb) {
    // I do fancy stuff
    console.log("I'm very fancy")
    cb();
}

iCallOthers(() => {console.log('iam a cb fn')})