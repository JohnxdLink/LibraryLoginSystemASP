/*
Data Engine: ECCLESIASTES\SQLEXPRESS
Creating Table
CREATE TABLE registration (
	Id_no INT PRIMARY KEY IDENTITY (777000, 1),
	Last_name VARCHAR(50) NOT NULL,
	First_name VARCHAR(50) NOT NULL,
	Course VARCHAR(50) NOT NULL,
	School_year INT NOT NULL,
	Major VARCHAR(50),
	Photo VARCHAR(255),
);

Insert Data
INSERT INTO registration (Last_name, First_name, Course, School_year, Major)
VALUES
('Castro', 'John Christian', 'BSIT', '1', 'Info-Tech'),
('Hornido', 'Mark', 'BSIT', '2', 'Info-Tech'),
('Rosales', 'Gaiel', 'BSIT', '2', 'Info-Tech'),
('Petralba', 'John Klevin', 'BSIT', '2', 'Info-Tech'),
('Avila', 'Jiesel Perales', 'BSIT', '2', 'Info-Tech');

INSERT INTO registration (Last_name, First_name, Course, School_year, Major)
VALUES
('Monisit', 'Febie', 'BIT', '3', 'Drafting'),
('Aliganga', 'Veronica', 'BEED', '2', 'Mathematics'),
('Escuitor', 'Caren', 'BEED', '4', 'English'),
('De Jesus', 'Julie Anne', 'BSCS', '1', 'Data Mining'),
('Maneja', 'Erika Jean', 'BIT', '3', 'Computer'),
('Andrino', 'Maria Angel', 'BIT', '3', 'Computer'),
('Lapuebla', 'Ana Marie', 'BSCS', '3', 'Data Mining'),
('Maneja', 'Erika Jean', 'BIT', '3', 'Computer');

This trigger fires after an INSERT operation is performed on the registration table. It updates the Photo_Id column with the value of the Id_no column for any new rows where Photo_Id is currently NULL.
CREATE TRIGGER photo_id_trigger
ON registration
AFTER INSERT
AS
BEGIN
    UPDATE registration
    SET Photo_id = Id_no
    WHERE Photo_id IS NULL;
END;

EXEC sp_rename 'timelog.Data_log', 'Date_log', 'COLUMN';

CREATE TABLE timelog (
		Id_no INT, FOREIGN KEY(Id_no) REFERENCES registration(Id_no),
		Timelog_id INT IDENTITY(0, 1) PRIMARY KEY,
		Time_in TIME,
		Time_out TIME,
		First_Time_in TIME,
		Last_Time_out TIME,
		Date_log DATE
);

INSERT INTO timelog(Id_no, Time_in, Date_log)
VALUES(777000, FORMAT(GETDATE(), 'HH:mm:ss'), CONVERT(DATE, GETDATE()));

*/