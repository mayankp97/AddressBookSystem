using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookDB
{
    class AddressBookRepo
    {
        public static string connectionString;
        public static SqlConnection sqlConnection;

        public static List<ContactModel> contacts;
        public static void SetConnection()
        {
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=AddressBookDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            sqlConnection = new SqlConnection(connectionString);
        }
        /// <summary>
        /// Method to retrieve and display all contacts from addressBook
        /// hence there are 4 interdependent tables, used joins
        /// </summary>
        public static void RetrieveAllContacts()
        {
            contacts = new List<ContactModel>();
            try
            {
                SetConnection();
                using (sqlConnection)
                {
                    var query = @"select * from ABookTable A Inner Join AddressInfo B On A.Id = B.Id"
                                +" Inner Join ContactInfo C On A.Id = C.Id";
                    var sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlConnection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var contactModel = new ContactModel();
                            contactModel.ContactId = Convert.ToInt32(reader["Id"]);
                            contactModel.FirstName = reader["FirstName"].ToString();
                            contactModel.LastName = reader["LastName"].ToString();
                            contactModel.RelationType = reader["RelationType"].ToString();
                            contactModel.Address = reader["Address"].ToString();
                            contactModel.City = reader["City"].ToString();
                            contactModel.State = reader["State"].ToString();
                            contactModel.Zipcode = reader["ZipCode"].ToString();
                            contactModel.PhoneNumber = reader["PhoneNumber"].ToString();
                            contactModel.Email = reader["Email"].ToString();
                            contacts.Add(contactModel);
                        }
                    }
                  
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.StackTrace);
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        public static void DisplayContacts()
        {
            foreach(var contact in contacts)
            {
                contact.Display();
            }
        }
    }
}
