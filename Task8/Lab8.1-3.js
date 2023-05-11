/*2. Об’єкт “ДАІ” (Код, ПІБ власника машини; марка, номер машини; колір).*/
function Police(code, surname, mark, carNumber, color){
    this.code = code;
    this.surname = surname;
    this.mark = mark;
    this.carNumber = carNumber;
    this.color = color;

    this.CarInfotmation = function(){
        console.log(`Код: ${this.code}\n ПІБ власника машина: ${this.surname}\n Марка: ${this.mark}\n Номер машини: ${this.carNumber}\n Колір: ${this.color}`);
    }
}

const car1 = new Police("3912", "Головач Олена В'ячеславівна", "Audi", "AH6492KT", "Чорний");
const car2 = new Police("7281", "Будика Максим Олександрович>", "Mersedes", "AO1834", "Синій");
const car3 = new Police("0394", "Лапаєв Дмитро Іванович", "Hyndai", "BO7410KA", "Білий");
const car4 = new Police("9561", "Короткова Валерія Михайлівна", "Toyota", "KA8327OI", "Червоний");

car1.CarInfotmation();
car2.CarInfotmation();
car3.CarInfotmation();
car4.CarInfotmation();
