/*Описати клас для для створення відповідної колекції обєктів. Реалізувати методи:
• отримання інформації щодо одного об’єкту (за Кодом),
• отримання вибірки з колекції згідно з вказаними запитами.
• додавання одного об’єкту,
• додавання колекції об’єктів,
• редагування інформації  про вказаний об’єкт.
• видалення інформації про вказаний об’єкт.

14. Об’єкт “Турнір” (Код, ПІБ;
стать; вік; назва країни, за яку він виступає; оцінки по трьох видах
змагань). Запит учасників з країни Х, вік яких не менший за Y.*/

class Tournament {
    constructor() {
      this.collection = [];
    }
  
    getObjectByCode(code) {
      return this.collection.find(obj => obj.code === code);
    }
  
    getSampleByCriteria(country, minAge) {
      return this.collection.filter(obj => obj.country === country && obj.age >= minAge);
    }
  
    addObject(tournamentObj) {
      this.collection.push(tournamentObj);
    }
  
    addCollection(tournamentObjs) {
      this.collection = this.collection.concat(tournamentObjs);
    }
  
    editObject(code, newData) {
      const objIndex = this.collection.findIndex(obj => obj.code === code);
      if (objIndex !== -1) {
        this.collection[objIndex] = { ...this.collection[objIndex], ...newData };
      }
    }
  
    removeObject(code) {
      this.collection = this.collection.filter(obj => obj.code !== code);
    }
  }
  
  const tournamentCollection = new Tournament();
  
  tournamentCollection.addCollection([
    {
      code: 1,
      name: "Player 1",
      gender: "Male",
      age: 25,
      country: "X",
      scores: [8, 9, 7]
    },
    {
      code: 2,
      name: "Player 2",
      gender: "Female",
      age: 30,
      country: "Y",
      scores: [7, 6, 8]
    },
    {
      code: 3,
      name: "Player 3",
      gender: "Male",
      age: 20,
      country: "X",
      scores: [9, 9, 9]
    }
  ]);

  const obj1 = tournamentCollection.getObjectByCode(1);
  console.log(obj1);

  const sample = tournamentCollection.getSampleByCriteria("X", 20);
  console.log(sample);

  tournamentCollection.addObject({
    code: 4,
    name: "Player 4",
    gender: "Female",
    age: 28,
    country: "Y",
    scores: [6, 7, 8]
  });

tournamentCollection.editObject(2, { name: "Updated Player" });

tournamentCollection.removeObject(3);

console.log(tournamentCollection.collection);
