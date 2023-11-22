/*Змінити значення ціни, якщо вона зросте на 30%*/
SELECT*
FROM Library
UPDATE Library
SET Price = Library.Price * 1.3;