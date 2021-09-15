USE DvdLibrary
GO

IF EXISTS(SELECT * FROM sys.server_principals WHERE name='DvdApp')
BEGIN
	--KILL 56
	--	SELECT session_id
	--	FROM sys.dm_exec_sessions
	--	WHERE login_name = 'DvdApp';
	
	DROP LOGIN DvdApp
	DROP USER DvdApp
END

CREATE LOGIN DvdApp WITH PASSWORD='p@ssword1'
GO

CREATE USER DvdApp FOR LOGIN DvdApp
GO

GRANT EXECUTE ON DvdCreate TO DvdApp
GRANT EXECUTE ON DvdDelete TO DvdApp
GRANT EXECUTE ON DvdSelectAll TO DvdApp
GRANT EXECUTE ON DvdSelectByDirector TO DvdApp
GRANT EXECUTE ON DvdSelectById TO DvdApp
GRANT EXECUTE ON DvdSelectByRating TO DvdApp
GRANT EXECUTE ON DvdSelectByReleaseYear TO DvdApp
GRANT EXECUTE ON DvdSelectByTitle TO DvdApp
GRANT EXECUTE ON DvdUpdate TO DvdApp
GO