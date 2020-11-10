﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AddressBookDB
{
    public class AddressBookRepo
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

        public static void UpdateContact(ContactModel updateContactModel)
        {
            try
            {
                SetConnection();
                var sqlCommand = new SqlCommand("SpUpdateContact", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", updateContactModel.ContactId);
                sqlCommand.Parameters.AddWithValue("@FirstName", updateContactModel.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", updateContactModel.LastName);
                sqlCommand.Parameters.AddWithValue("@RelationType", updateContactModel.RelationType);
                sqlCommand.Parameters.AddWithValue("@Address", updateContactModel.Address);
                sqlCommand.Parameters.AddWithValue("@City", updateContactModel.City);
                sqlCommand.Parameters.AddWithValue("@State", updateContactModel.State);
                sqlCommand.Parameters.AddWithValue("@Zipcode", updateContactModel.Zipcode);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", updateContactModel.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Email", updateContactModel.Email);
                sqlConnection.Open();
                var reader = sqlCommand.ExecuteReader();
                if (reader.Read())
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
                    var existingContact = contacts.FirstOrDefault(c => c.ContactId == updateContactModel.ContactId);
                    if (existingContact != null)
                    {
                        contacts.Remove(existingContact);
                        contacts.Add(contactModel);
                    }
                    else
                        contacts.Add(contactModel);
                    contactModel.Display();
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
