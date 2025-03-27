create table Roles
(
ro_identificador int primary key identity (1,1),
ro_descripcion nvarchar(125) not null,
ro_fecha_adicion datetime default getdate() not null,
ro_adicionado_por nvarchar(10) not null,
ro_fecha_modificacion datetime,
ro_modificado_por nvarchar(10)
);