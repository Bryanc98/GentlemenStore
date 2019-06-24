create database GeltlemenStore;

use GeltlemenStore;

create table EmpleadosGS(
	ID_Empleado int identity(1,1),
	Nom_Empleado Varchar(50),
	Cedula_Empleado varchar(14),
	Edad int,
	Telefono varchar(20),
	Ocupacion_Empleado varchar(30),
	Salario_Empleado float,
	IdCargoEmp int,
	IdDepEmp int,
	constraint PK_EMP primary key (ID_Empleado),
	constraint FK_CARGO foreign key (IdCargoEmp) references EmpleadoCargoGS(IdEmpCargo),
	constraint FK_DEP foreign key (IdDepEmp) references DepartamentoGS(IdDepartamento)
);

create table SuplidoresGS(
	ID_Suplidor int identity(1,1),
	Nom_Suplidor varchar(50),
	RNC_Suplidor int,
	Dirrec_Suplidor varchar(50),
	Tel_Suplidor int,
	Email_Suplidor varchar(50),
	constraint PK_SUPLI primary key (ID_Suplidor)
);

create table ProductosGS(
	ID_Productos int identity(1,1),
	Nom_Producto varchar(50),
	Tipo_Producto varchar(50),
	Cantidad_Producto int,
	CostoU_Producto int,
	Suplidor_P int,
	IdCategoria int,
	IdSubCategoria int,
	constraint PK_PRODUC primary key (ID_Productos),
	constraint FK_SUPLI foreign key (Suplidor_P) references SuplidoresGS(ID_Suplidor),
	constraint FK_CATEG foreign key (IdCategoria) references CategoriaGS(Id_Categoria),
	constraint FK_SUBCATEG foreign key (IdSubCategoria) references SubCategoriaGS(Id_SubCategoria)
);

create table ClientesGS(
	ID_Cliente int identity(1,1),
	Nom_Cliente varchar(50),
	Identificacion_CGS int,
	Tel_Cliente int,
	Email_Cliente varchar(50),
	IdMetodoPago int,
	constraint PK_CGS primary key (ID_Cliente),
	constraint FK_METODPAGO foreign key (IdMetodoPago) references MetodoPagoGS(IdMetodoPago),
);

create table SubCategoriaGS(
	Id_SubCategoria int primary key identity(1,1),
	NombreSubcategoria varchar(60),
	IdCategoria int,
    constraint FK_Categoria foreign key (IdCategoria) references CategoriaGS(Id_Categoria)
);

create table CategoriaGS(
	Id_Categoria int primary key identity(1,1),
	Nombre varchar(60)
);

create table ProveedorPagoGS(
	IdProveedorPago int primary key identity(1,1),
	Nombre varchar(20)
);

create table MetodoPagoGS(
	IdMetodoPago int primary key identity(1,1),
	Nombre varchar(60),
	IdProveedorPago int,
    constraint FK_PROVEPAGO foreign key (IdProveedorPago) references ProveedorPagoGS(IdProveedorPago)
);

create table EmpleadoCargoGS(
	IdEmpCargo int primary key identity(1,1),
	NombreCargo varchar(60)
);

create table DepartamentoGS(
	IdDepartamento int primary key identity(1,1),
	NombreDep varchar(30)
);

--create table FacturasGS(
--ID_Factura int,
--fecha date,
--Cliente_Fact int,
--Product_Comprados int,
--Cantidad_Comp int,
--constraint PK_Fact primary key (ID_Factura),
--constraint FK_CGS1 foreign key (Cliente_Fact) references ClientesGS(ID_Cliente)
--);

