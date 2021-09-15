USE DvdLibrary
GO

DELETE Dvd
GO

SET IDENTITY_INSERT Dvd ON;

INSERT INTO Dvd (DvdId, Title, ReleaseYear, Director, Rating, Notes)
	VALUES(1, 'Marvin''s Room', '1996', 'Jerry Zaks', 'PG-13', 'Turn the family upside down.'),
	(2, 'Tucker and Dale vs Evil', '2010', 'Eli Craig', 'R', 'Affable hillbillies Tucker and Dale are on vacation'),
	(3, 'Quills', '2000', 'Philip Kaufman', 'R', 'In a Napoleonic era insane asylum.'),
	(4, 'The Man From Earth', '2007', 'Richard Schenkman', NULL, 'An impromptu goodbye party.')

SET IDENTITY_INSERT Dvd OFF;
GO