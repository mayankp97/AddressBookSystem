use AddressBookDB
Go

select COUNT(City), City, State from ABookTable
group by State, City;
Go