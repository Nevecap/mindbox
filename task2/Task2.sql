/*
���������������, ��� ���� 2 �������, �������� � ���������, � ����� ������� ��� ����������� �� ������ � ��������� connections
*/
SELECT Product.Name, Category.Name FROM (Product LEFT JOIN Connections ON Products.ID = Connections.ProductID) LEFT JOIN Category ON Connections.CategoryID = Categorys.ID