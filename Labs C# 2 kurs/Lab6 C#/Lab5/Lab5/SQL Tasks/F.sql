/*Вивести кількість опублікованих книг видавництвом, якщо їхня кількість більша 2*/
SELECT COUNT(*) AS PublishingCount, BookstoreFirm
FROM Library
GROUP BY BookstoreFirm
HAVING COUNT(*)>2;