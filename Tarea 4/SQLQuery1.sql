create database tfnos2
use tfnos2
create table telefonos (
						nombre char(30) not null,
						direccion char(30) not null, 
						telefono char(12) primary key not null,
						observaciones char(240)
						)
insert into telefonos values ('Juan Perez', 'Zaragoza',
							'976111222', 'Es el profesor')
select * from telefonos