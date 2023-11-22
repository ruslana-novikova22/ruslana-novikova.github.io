/* Вибрати книги, де рік публікації більший за 2000 та фірма Literary Oasis */
SELECT Library.Title, Library.Author, Library.Price
FROM Library
WHERE (PublicationYear > 2000) 
AND BookstoreFirm = 'Literary Oasis';