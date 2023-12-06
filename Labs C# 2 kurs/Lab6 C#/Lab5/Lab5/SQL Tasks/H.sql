/*Всі книги з видавництва Literary Oasis замінити на Writers Retreat*/
UPDATE Library
SET BookstoreFirm = 'Writers Retreas'
WHERE BookstoreFirm = 'Literary Oasis';
SELECT * 
FROM Library 