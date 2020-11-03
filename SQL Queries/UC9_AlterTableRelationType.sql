use AddressBookDB
Go

alter table ABookTable
add RelationType varchar(15)
Go


update ABookTable set RelationType ='Self' where FirstName='Mayank';
update ABookTable set RelationType ='Brother' where FirstName='Rajat';
update ABookTable set RelationType ='Cousin' where FirstName='Chinmayi';
update ABookTable set RelationType ='Cousin' where FirstName='Terissa';

select * from ABookTable;