USE EpiLibrary;

INSERT INTO Genres VALUES
(NEWID(), 'Romanzo'),
(NEWID(), 'Narrativa'),
(NEWID(), 'Fantasy'),
(NEWID(), 'Fantascienza'),
(NEWID(), 'Giallo'),
(NEWID(), 'Thriller'),
(NEWID(), 'Horror'),
(NEWID(), 'Romanzo Rosa'),
(NEWID(), 'Storico'),
(NEWID(), 'Avventura'),
(NEWID(), 'Young Adult'),
(NEWID(), 'Distopico'),
(NEWID(), 'Biografico'),
(NEWID(), 'Saggio'),
(NEWID(), 'Autobiografia'),
(NEWID(), 'Poesia'),
(NEWID(), 'Umoristico'),
(NEWID(), 'Drammatico'),
(NEWID(), 'Mistero'),
(NEWID(), 'Filosofico'),
(NEWID(), 'Self-help');

SELECT * FROM Genres;
SELECT * FROM Books;

INSERT INTO Books VALUES
(NEWID(), 'Harry Potter e la pietra filosofale', 'J.K. Rowling', 1, null, '017B0695-6ADE-4B57-A345-617EF8A028C3'),
(NEWID(), 'Il codice Da Vinci', 'Dan Brown', 0, null, 'F58D7D3F-D63C-4899-B238-6951B448EB07'),
(NEWID(), 'Cinquanta sfumature di grigio', 'E.L. James', 1, null, 'C0EE143C-D668-4869-99EC-82ED7B7B789C'),
(NEWID(), 'L''alchimista', 'Paulo Coelho', 0, null, 'EA2294D3-A8E9-4179-9C9B-ACB52A2A4FC9'),
(NEWID(), 'Hunger Games', 'Suzanne Collins', 1, null, '14034E83-FFE7-4902-97EC-837166E33F3F'),
(NEWID(), 'Il cacciatore di aquiloni', 'Khaled Hosseini', 0, null, 'C6089CC4-17D0-43EB-90EA-E35E9044E016'),
(NEWID(), 'Uomini che odiano le donne', 'Stieg Larsson', 1, null, '1D7F9D6D-567C-45DB-A9E0-0B180BD3F51C'),
(NEWID(), 'Twilight', 'Stephenie Meyer', 0, null, '017B0695-6ADE-4B57-A345-617EF8A028C3'),
(NEWID(), 'Storia di una ladra di libri', 'Markus Zusak', 1, null, '1FBA6532-AA55-43B2-BE2D-C14A943AB2E6'),
(NEWID(), 'Colpa delle stelle', 'John Green', 0, null, 'C0EE143C-D668-4869-99EC-82ED7B7B789C'),
(NEWID(), 'The Help', 'Kathryn Stockett', 1, null, '1FBA6532-AA55-43B2-BE2D-C14A943AB2E6'),
(NEWID(), 'Vita di Pi', 'Yann Martel', 0, null, 'EA2294D3-A8E9-4179-9C9B-ACB52A2A4FC9'),
(NEWID(), 'Amabili resti', 'Alice Sebold', 1, null, 'C6089CC4-17D0-43EB-90EA-E35E9044E016'),
(NEWID(), 'Il rifugio', 'William P. Young', 0, null, 'A8D639DD-E032-4D7D-B202-1750F7CC7E2A'),
(NEWID(), 'La strada', 'Cormac McCarthy', 1, null, '14034E83-FFE7-4902-97EC-837166E33F3F'),
(NEWID(), 'L''amore bugiardo', 'Gillian Flynn', 0, null, 'F58D7D3F-D63C-4899-B238-6951B448EB07'),
(NEWID(), 'Il segreto', 'Rhonda Byrne', 1, null, 'C8B1C1F7-6375-466B-8090-12E582AC55A1'),
(NEWID(), 'La ragazza del treno', 'Paula Hawkins', 0, null, 'F58D7D3F-D63C-4899-B238-6951B448EB07'),
(NEWID(), 'Le pagine della nostra vita', 'Nicholas Sparks', 1, null, 'C0EE143C-D668-4869-99EC-82ED7B7B789C'),
(NEWID(), 'Shining', 'Stephen King', 0, null, '8E44FB8B-37F8-4A74-B42C-9AD71389C524');

SELECT * FROM Users;

INSERT INTO Users VALUES
(NEWID(), 'Gianluca', 1),
(NEWID(), 'Pippo', 0),
(NEWID(), 'Pluto', 0),
(NEWID(), 'Paperino', 0);

SELECT * FROM Lendings;

