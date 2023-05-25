/*Використовуючи JS, HTML та СSS створити:
• Об’єкт для зберігання даних про фільм (Id, назва, режисер, виконавець головної
ролі, URL-трейлеру, рік випуску, касові збори).
• На основі об’єкту фільму створити новий об’єкт, який перевизначає метод
toString().
• Об’єкт для зберігання даних про колекцію фільмів, цей об’єкт повинен містити
конструктор та метод для знаходження фільмів в яких грає вказаний виконавець.
• Відобразити дані про фільми в яких грає вказаний виконавець на сторінці.*/


class Film{
    constructor(id, title, director, mainActor, url, year, boxOffice){
        this.id = id;
        this.title = title;
        this.director = director;
        this.mainActor = mainActor;
        this.url = url;
        this.year = year;
        this.boxOffice = boxOffice;
    }
}

class StrgifyFilm extends Film{
    toString() {
        return `${super.toString()}{
            id:${this.id},
            title:${this.title},
            ...
        }`;
    }
}

class FilmCollection {
    constructor(items = []) {
        this.items = items;
    }

    getById(id) {
        return this.items.find(film => film.id == id);
    }

    findByActor(mainActor){
        return this.items.find(film => film.mainActor == mainActor)
    }
    }


let Savona = new FilmCollection();
let film1 = new Film(6690, "Месники.Фінал","Кевін Файгі", "Роберт Дауні Молодший", "https://www.youtube.com/watch?v=7ZHb4PWOI5M",2019, "3 млдр USD")
let film2 = new Film(6381, "Суддя", " Девід Добкін", "Роберт Дауні Молодший", "https://www.youtube.com/watch?v=GmUh2un6BjY", 2014, "84,4 мільйона USD")
let film3 = new Film(6302, "Воно", " Андрес Мускетті", "Біл Скаршгорд", "https://www.youtube.com/watch?v=p4cIn7RWkdQ", 2017, "$698 060 882")
let film4 = new Film(6277, "Чорна Вдова", "Кейт Шортленд", "Скарлетт Йохансон", "https://www.youtube.com/watch?v=2sJQ1eJ8OFg", 2021, "$379,6 млн")
Savona.items.push(film1);
Savona.items.push(film2);
Savona.items.push(film3);
Savona.items.push(film4);
Savona.findByActor("Роберт Дауні Молодший");

let findFilm = function(){
    let text = document.querySelector("#inp").value;
    let arr = []
    for(film of Savona.items){
        if(film.mainActor == text){
            arr.push(film);
        }
    }
    return arr
}
document.querySelector('#btn').addEventListener("click", ()=>{
    document.querySelector(".render").innerHTML = ""
    for(film of findFilm()){
        document.querySelector(".render").innerHTML += `<div class="card"><h4>${film.title}</h4><h4>${film.director}</h4><h4>${film.mainActor}</h4><h4>${film.year}</h4><h4>${film.boxOffice}</h4></div>`;
    }
})