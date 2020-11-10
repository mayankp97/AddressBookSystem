Create Procedure SpUpdateContact
(
@Id int,
@FirstName varchar(20),
@LastName varchar(20),
@RelationType varchar(15),
@Address varchar(15),
@City varchar(15),
@State varchar(20),
@Zipcode varchar(6),
@PhoneNumber varchar(13),
@Email varchar(25)
)
As
Begin
Update ABookTable Set FirstName = @FirstName,
					  LastName = @LastName,
					  RelationType = @RelationType
					  where Id = @Id ;
Update AddressInfo Set Address = @Address,
					   City = @City,
					   State = @State,
					   Zipcode = @Zipcode
					   where Id = @Id ;
Update ContactInfo Set PhoneNumber = @PhoneNumber,
					   Email = @Email
					   where Id = @Id;
Select * from ABookTable A Inner Join AddressInfo B On A.Id = B.Id
								Inner Join ContactInfo C On A.Id = C.Id
								where A.Id = @Id;
End