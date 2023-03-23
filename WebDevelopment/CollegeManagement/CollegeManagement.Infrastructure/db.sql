--create new table
create table Student
(
   Id int identity primary key,
   Name varchar(100),
   Contact varchar(100),
   Major varchar(100),
   DOB datetime2,
   Semester varchar(5),
);

--get data
select * from Student
select Name, Contact from Student where Id=1
--insert data
insert into Student
values ('Roshan Twayana', '9843317682', 'Science', '1997/11/29', 'VI');

--update table
update Student
set Major='Arts'
where Id=2

--delete
delete from Student
where Id=3

--create a table called "teacher" with at least 5 columns and insert data for 5 teachers in there
create table Teacher 
(
Id int identity primary key,
Name nvarchar(50),
Contact varchar(100),
Department varchar(50),
Salary decimal,
);

Insert into Teacher
values('Leo Messi', '987654322', 'Mathematics' ,500000),
('Ronaldo', '9866654322', 'English' ,400000),
('Di Maria', '988852365', 'Science' ,300000),
('Lewandoski', '9555654322', 'History' ,550000),
('kaka', '8887654322', 'Mathematics',45000);

--drop table Teacher