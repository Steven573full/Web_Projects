
create database DBVENTA

go

use DBVENTA

go

--Tabla para el Menú Principal
create table Menu(
idMenu int primary key identity(1,1),
descripcion varchar(30),
idMenuPadre int references Menu(idMenu),
icono varchar(30),
controlador varchar(30),
paginaAccion varchar(30),
esActivo bit,
fechaRegistro datetime default getdate()
)

go

--Tabla para los roles del usuario
create table Rol(
idRol int primary key identity(1,1),
descripcion varchar(30),
esActivo bit,
fechaRegistro datetime default getdate()
)

go
 --Tabla para el control de roles en el menú
 create table RolMenu(
 idRolMenu int primary key identity(1,1),
 idRol int references Rol(idRol),
 idMenu int references Menu(idMenu),
 esActivo bit,
 fechaRegistro datetime default getdate()
 )

go
--Tabla para el control de Usuarios
create table Usuario(
idUsuario int primary key identity(1,1),
nombre varchar(50),
correo varchar(50),
telefono varchar(50),
idRol int references Rol(idRol),
urlFoto varchar(500),
nombreFoto varchar(100),
clave varchar(100),
esActivo bit,
fechaRegistro datetime default getdate()
)

go
--Tabla para las categorias del producto
create table Categoria(
idCategoria int primary key identity(1,1),
descripcion varchar(50),
esActivo bit,
fechaRegistro datetime default getdate()
)

go
--Tabla para el control de productos
create table Producto(
idProducto int primary key identity(1,1),
codigoBarra varchar(50),
marca varchar(50),
descripcion varchar(100),
idCategoria int references Categoria(idCategoria),
stock int,
urlImagen varchar(500),
nombreImagen varchar(100),
precio decimal(10,2),
esActivo bit,
fechaRegistro datetime default getdate()
)

go
--Tabla para el numero del Coorelativo (Para visualizar las compras realizadas por X Usuario)
create table NumeroCorrelativo(
idNumeroCorrelativo int primary key identity(1,1),
ultimoNumero int,
cantidadDigitos int,
gestion varchar(100),
fechaActualizacion datetime
)

go
--Tabla para registrar tipo de venta (Boleta o factura)
create table TipoDocumentoVenta(
idTipoDocumentoVenta int primary key identity(1,1),
descripcion varchar(50),
esActivo bit,
fechaRegistro datetime default getdate()
)

go
--Tabla para la venta
create table Venta(
idVenta int primary key identity(1,1),
numeroVenta varchar(6),
idTipoDocumentoVenta int references TipoDocumentoVenta(idTipoDocumentoVenta),
idUsuario int references Usuario(idUsuario),
documentoCliente varchar(10),
nombreCliente varchar(20),
subTotal decimal(10,2),
impuestoTotal decimal(10,2),
Total decimal(10,2),
fechaRegistro datetime default getdate()
)

go
--Tabla para observar el detalle de la venta X
create table DetalleVenta(
idDetalleVenta int primary key identity(1,1),
idVenta int references Venta(idVenta),
idProducto int,
marcaProducto varchar(100),
descripcionProducto varchar(100),
categoriaProducto varchar(100),
cantidad int,
precio decimal(10,2),
total decimal(10,2)
)

go
--Tabla para el control de negocios
create table Negocio(
idNegocio int primary key,
urlLogo varchar(500),
nombreLogo varchar(100),
numeroDocumento varchar(50),
nombre varchar(50),
correo varchar(50),
direccion varchar(50),
telefono varchar(50),
porcentajeImpuesto decimal(10,2),
simboloMoneda varchar(5)
)

go
--Tabla para las configuraciones externas(Claves y Creencias) con esto evitamos entrar al código y cambiarlo 
create table Configuracion(
recurso varchar(50),
propiedad varchar(50),
valor varchar(60)
)

