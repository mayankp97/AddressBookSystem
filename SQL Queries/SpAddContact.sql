CREATE Procedure SpAddContact
(
@FirstName varchar(20),
@LastName varchar(20),
@RelationType varchar(15),
@Address varchar(15),
@City varchar(15),
@State varchar(20),
@Zipcode varchar(6),
@PhoneNumber varchar(13),
@Email varchar(25),
@DateAdded Date
)
As
Begin
Insert into ABookTable values (@FirstName,
							   @LastName,
							   @RelationType,
							   @DateAdded)
					  
insert into AddressInfo values (@Address,
								@City,
								@State,
								@Zipcode)
insert into ContactInfo values (@PhoneNumber,
								@Email)

End