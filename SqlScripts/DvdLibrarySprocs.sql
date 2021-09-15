USE DvdLibrary
GO

-- Stored Procedures
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdSelectAll')
      DROP PROCEDURE DvdSelectAll
GO

CREATE PROCEDURE DvdSelectAll
AS
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd d
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdSelectById')
      DROP PROCEDURE DvdSelectById
GO

CREATE PROCEDURE DvdSelectById (
	@DvdId INT
)
AS
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd d
	WHERE d.DvdId = @DvdId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdSelectByTitle')
      DROP PROCEDURE DvdSelectByTitle
GO

CREATE PROCEDURE DvdSelectByTitle (
	@DvdTitle NVARCHAR(30)
)
AS
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd d
	WHERE d.Title LIKE '%' + @DvdTitle + '%'
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdSelectByReleaseYear')
      DROP PROCEDURE DvdSelectByReleaseYear
GO

CREATE PROCEDURE DvdSelectByReleaseYear (
	@DvdReleaseYear VARCHAR(4)
)
AS
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd d
	WHERE d.ReleaseYear = @DvdReleaseYear
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdSelectByDirector')
      DROP PROCEDURE DvdSelectByDirector
GO

CREATE PROCEDURE DvdSelectByDirector (
	@Director NVARCHAR(30)
)
AS
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd d
	WHERE d.Director LIKE '%' + @Director + '%'
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdSelectByRating')
      DROP PROCEDURE DvdSelectByRating
GO

CREATE PROCEDURE DvdSelectByRating (
	@Rating NVARCHAR(5)
)
AS
	SELECT DvdId, Title, ReleaseYear, Director, Rating, Notes
	FROM Dvd d
	WHERE d.Rating = @Rating
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdCreate')
      DROP PROCEDURE DvdCreate
GO

CREATE PROCEDURE DvdCreate (
	@DvdId INT output,
	@Title NVARCHAR(30),
	@ReleaseYear VARCHAR(4),
	@Director NVARCHAR(30),
	@Rating NVARCHAR(5),
	@Notes NVARCHAR(150)
)
AS
	INSERT INTO Dvd (Title, ReleaseYear, Director, Rating, Notes)
	VALUES (@Title, @ReleaseYear, @Director, @Rating, @Notes)

	SET @DvdId = SCOPE_IDENTITY();
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdUpdate')
      DROP PROCEDURE DvdUpdate
GO

CREATE PROCEDURE DvdUpdate (
	@DvdId INT,
	@Title NVARCHAR(30),
	@ReleaseYear VARCHAR(4),
	@Director NVARCHAR(30),
	@Rating NVARCHAR(5),
	@Notes NVARCHAR(150)
)
AS
	UPDATE Dvd
		SET Title = @Title, 
		ReleaseYear = @ReleaseYear, 
		Director = @Director, 
		Rating = @Rating, 
		Notes = @Notes
	WHERE Dvd.DvdId = @DvdId
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DvdDelete')
      DROP PROCEDURE DvdDelete
GO

CREATE PROCEDURE DvdDelete (
	@DvdId INT
)
AS
	Delete Dvd
	WHERE Dvd.DvdId = @DvdId
GO