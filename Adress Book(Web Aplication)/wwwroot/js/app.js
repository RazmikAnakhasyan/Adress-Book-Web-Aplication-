const DeleteContact = document.querySelector(".delete-Contact")
const CreateContact = document.querySelector(".create-Contact")
const EditContact = document.querySelector(".edit-Contact")
const ShowAll = document.querySelector(".all-Contacts")
const SearchContact = document.querySelector(".Search-Contact")
const InformationBlock = document.querySelector('.content');

//Fetching Data From Api And Getting json Data For All Contacts
function ShowAllContacts() {
    fetch('All', {
        method: "GET",
        headers: {
            Accept: 'application/json',
            'Content-Type': 'application/json',
            Pragma: 'no-cache',
        },
    })
        .then(response => {
            return response.json();
        })
        .then(data => {
            InformationBlock.innerHTML =`<h2>All Contacts(Count(${data.length}))</h2>`
            for (const item of data) {
                InformationBlock.innerHTML += `
                 <div>
                    <ul>
                    <li>${item.fullName}</li>
                    <li>${item.emailAdress}</li>
                    <li>${item.phoneNumber}</li>
                    <li>${item.physicalAddres}</li>
                    </ul>
                 </div>`
            }
        });
}


//Function That Show Form For Choosing Contact
function ShowDeleteForm() {
    InformationBlock.innerHTML = null;
    InformationBlock.innerHTML = `
        <form action="/Delete" enctype="multipart/form-data" method="post">
            <input name="FullName" placeholder="Full Name"  required/></br></br>
            <input  type="submit" value="Delete"/>
        </form>`
}

function ShowUpdateForm() {
    InformationBlock.innerHTML = null;
    InformationBlock.innerHTML = `
        <form action="/Update" method="post">
            <input name="FullName" placeholder="Full Name"  required/></br></br>
            <input name="EmailAdress" type="email" placeholder="Email Adress"  required/></br></br>
            <input name="PhoneNumber" placeholder="Phone Number"   required/></br></br>
            <input name="PhysicalAddres" placeholder="Physical Adress"  required/></br></br>
            <input  type="submit" value="Update"/>
       </form>`
}

function ShowAddForm() {
    InformationBlock.innerHTML = null;
    InformationBlock.innerHTML = `
         <form action="/Add" method="post">
            <input name="FullName" placeholder="Full Name"  required/></br></br>
            <input name="EmailAdress" type="email" placeholder="Email Adress"  required/></br></br>
            <input name="PhoneNumber" placeholder="Phone Number"   required/></br></br>
            <input name="PhysicalAddres" placeholder="Physical Adress"  required/></br></br>
            <input  type="submit" value="Add"/>
       </form>`
}

//Adding Click Event For All Contacts button
ShowAll.addEventListener('click', function (event) {
    ShowAllContacts();
})

//Adding Click Event For Delete button
DeleteContact.addEventListener('click', function (event) {
    ShowDeleteForm();
})

EditContact.addEventListener('click', function (event) {
    ShowUpdateForm();
})

CreateContact.addEventListener('click', function (event) {
    ShowAddForm();
})