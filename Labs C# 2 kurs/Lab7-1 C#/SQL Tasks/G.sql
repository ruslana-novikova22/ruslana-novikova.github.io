/*Вивести список книг за порядком зростання року видання*/
SELECT Library.Title, Library.Author, Library.PublicationYear
FROM Library
ORDER BY Library.PublicationYear;