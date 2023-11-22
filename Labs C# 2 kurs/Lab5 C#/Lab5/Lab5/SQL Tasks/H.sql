/*Всі книги з видавництва Literary Oasis замінити на Writers Retreat*/
SELECT * 
FROM Library 
UPDATE Library
SET BookstoreFirm = 'Writers Retreat'
WHERE BookstoreFirm = 'Literary Oasis';