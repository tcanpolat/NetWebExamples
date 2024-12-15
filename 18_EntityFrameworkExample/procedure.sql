-- Procedure oluþtur
create proc GetStudentsByDepartment @Department nvarchar(50)
as
begin
	select * from Students where Department = @Department
end

exec GetStudentsByDepartment 'Grafik'