Use AddressBookDB
Go

create table ABookTable
	(
	Id INT IDENTITY(1,1),
	FirstName varchar(20) not null,
	LastName varchar(20) not null,
	Address varchar(15) not null,
	City varchar(15) not null,
	State varchar(20) not null,
	Zipcode varchar(6) not null,
	PhoneNumber varchar(12) not null,
	Email varchar(30) not null
);