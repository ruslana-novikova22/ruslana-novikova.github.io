class TournamentUser{
    constructor(code, name, gender, age, country, mark){
      this.code = code;
      this.name = name;
      this.gender = gender;
      this.age = age;
      this.country = country;
      this.mark = mark;
    }
  }

  class TournamentUsers{
    constructor(){
      this.item = [];
    }
  
    add(user){
      if(!(user instanceof TournamentUser))
        throw '${user} is not instance of TournamentUser';
      this.item.push(user);
    }
  
    getById(id){
      return this.item.find(user => user.code == id)
    }
  
    update(id, newUser){
      let user = this.getById(id);
      if(!user)
        throw "Not found";
      for(let k of ["name", "gender", "age", "country", "mark"]){
        if (newUser[k])
          user[k] = newUser[k];
      }
    }
    
    delete(id){
      let userIndex = this.item.findIndex(user => user.code == id);
      if(userIndex == -1)
        throw "Not found";
      this.item.splice(userIndex, 1);
    }
}
const usersTable = document.getElementById('usersTable');
const addUserForm = document.forms.addUserForm;

let tournamentUsers = new TournamentUsers();

function refreshUsersTable(usersList) {
  const tbody = usersTable.getElementsByTagName('tbody')[0];
  tbody.innerHTML = '';

  for (let user of usersList.item) {
    const row = document.createElement('tr');
    const codeCell = document.createElement('td');
    codeCell.textContent = user.code;
    row.appendChild(codeCell);

    const fullNameCell = document.createElement('td');
    fullNameCell.textContent = user.name;
    row.appendChild(fullNameCell);

    const genderCell = document.createElement('td');
    genderCell.textContent = user.gender;
    row.appendChild(genderCell);

    const ageCell = document.createElement('td');
    ageCell.textContent = user.age;
    row.appendChild(ageCell);

    const countryCell = document.createElement('td');
    countryCell.textContent = user.country;
    row.appendChild(countryCell);

    const markCell = document.createElement('td');
    markCell.textContent = user.mark;
    row.appendChild(markCell);

    const actionCell = document.createElement('td');
    const deleteButton = document.createElement('button');
    deleteButton.className = 'delete-button';
    deleteButton.textContent = 'Delete';
    deleteButton.addEventListener('click', () => {
      tournamentUsers.delete(tournamentUser.code);
      row.remove();
    });
    actionCell.appendChild(deleteButton);
    row.appendChild(actionCell);

    tbody.appendChild(row);
  }
}

addUserForm.addEventListener('submit', (e) => {
    console.log("AddEventListenerWork");
  e.preventDefault();

  const code = addUserForm.code.value;
  const fullName = addUserForm.fullName.value;
  const gender = addUserForm.gender.value;
  const age = parseFloat(addUserForm.age.value);
  const country = addUserForm.country.value;
  const mark = parseInt(addUserForm.mark.value);

  const newUser = new TournamentUser(code, fullName, gender, age, country, mark);

  tournamentUsers.add(newUser);

  refreshUsersTable(tournamentUsers);
  addUserForm.reset();
});

let firstUser = new TournamentUser(5621, "Новікова Руслана", "Жінка", 22, "Україна", 33);
let secondUser = new TournamentUser(7305, "Шимон Артем", "Чоловік", 25, "Словаччина", 26);
tournamentUsers.add(firstUser);
tournamentUsers.add(secondUser);
refreshUsersTable(tournamentUsers);