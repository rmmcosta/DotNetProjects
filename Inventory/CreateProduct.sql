Create table Product(
	Id bigint identity(1,1) primary key,
	Name varchar(50) not null,
	Category varchar(50),
	Color varchar(25),
	Price decimal not null,
	AvailableQuantity int not null,
	CreatedOn datetime default getdate() not null
);