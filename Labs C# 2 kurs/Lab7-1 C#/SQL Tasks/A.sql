/*Вибрати всі книги, у яких автор J.D. Salinger*/
SELECT Library.Title, Library.Price, Library.BookstoreFirm
FROM Library
WHERE TRIM(Library.Author) = 'J.D. Salinger';