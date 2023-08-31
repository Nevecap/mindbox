/*
Подразумевается, что есть 2 таблицы, продукты и категории, а также таблица для отображения их связей с названием connections
*/
SELECT Product.Name, Category.Name FROM (Product LEFT JOIN Connections ON Products.ID = Connections.ProductID) LEFT JOIN Category ON Connections.CategoryID = Categorys.ID