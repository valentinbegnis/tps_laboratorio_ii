CREATE DATABASE Libreria_TP4;
GO
USE Libreria_TP4;
GO
CREATE TABLE Libros
(
	id INT IDENTITY(1,1) PRIMARY KEY,
	titulo VARCHAR(50) NOT NULL,
	autor VARCHAR(50) NOT NULL,
	genero VARCHAR(10) NOT NULL,
	cantidad_paginas INT NOT NULL,
	codigo INT NOT NULL,
	precio FLOAT NOT NULL
);
GO
INSERT INTO Libros (titulo, autor, genero, cantidad_paginas, codigo, precio) VALUES
	('In Search of Lost Time', 'Marcel Proust', 'Ficcion', 230, 1000, 1500),
	('Ulysses', 'James Joyce', 'Ficcion', 280, 1001, 1800),
	('Don Quixote', 'Miguel de Cervantes', 'Ficcion', 853, 1002, 3500),
	('One Hundred Years of Solitude', 'Gabriel Garcia Marquez', 'Ficcion', 134, 1003, 2456),
	('The Odyssey', 'Homer', 'Ficcion', 367, 1004, 2300),
	('The Divine Comedy', 'Dante Alighieri', 'Ficcion', 220, 1005, 1700),
	('Pride and Prejudice', 'Jane Austen', 'Ficcion', 213, 1006, 1810),
	('The Kissing Bug', 'Daisy Hernandez', 'No_Ficcion', 180, 1007, 2100),
	('Empire of Pain', 'Patrick Radden Keefe', 'No_Ficcion', 242, 1008, 3600),
	('The Trial', 'Franz Kafka', 'Ficcion', 287, 1009, 2300),
	('Aftershocks', 'Nadia Owusu', 'No_Ficcion', 193, 1010, 2230),
	('Great Expectations', 'Charles Dickens', 'Ficcion', 340, 1011, 2321),
	('How the World Is Passed', 'Clint Smith', 'No_Ficcion', 245, 1012, 2000),
	('Invisible Child', 'Andrea Elliot', 'No_Ficcion', 190, 1013, 1590),
	('Crying in H Mart', 'Michelle Zauner', 'No_Ficcion', 267, 1014, 3290),
	('A Little Devil in America', 'Hanif Abdurraqib', 'No_Ficcion', 321, 1015, 4329),
	('Middlemarch', 'George Eliot', 'Ficcion', 190, 1016, 1800),
	('Mrs. Dalloway', 'Virginia Woolf', 'Ficcion', 132, 1017, 1344),
	('Pilgrim at Tinker Creek', 'Annie Dillard', 'No_Ficcion', 265, 1018, 2312),
	('The Second Sex', 'Simone de Beauvoir', 'No_Ficcion', 234, 1019, 3210),
	('The Stranger', 'Albert Camus', 'Ficcion', 260, 1020, 2333),
	('The Feminine Mystique', 'Betty Friedan', 'No_Ficcion', 150, 1021, 2245),
	('Candide', 'Voltaire', 'Ficcion', 445, 1022, 4300),
	('The Lord of the Rings', 'Tolkien', 'Ficcion', 605, 1023, 4100),
	('The Idiot', 'Fyodor Dostoyevsky', 'Ficcion', 322, 1024, 3200),
	('Between the World and Me', 'Ta-Nehisi Coates', 'No_Ficcion', 324, 1025, 1900),
	('Notes of a Native', 'James Baldwin', 'No_Ficcion', 423, 1026, 3455),
	('The Old Man and the Sea', 'Ernest Hemingway', 'Ficcion', 122, 1027, 800),
	('Emma', 'Jane Austen', 'Ficcion', 120, 1028, 1000),
	('The Metamorphosis', 'Franz Kafka', 'Ficcion', 170, 1029, 1200),
	('The Aeneid', 'Virgil', 'Ficcion', 465, 1030, 3555);
