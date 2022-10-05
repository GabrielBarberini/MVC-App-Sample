using System;
using System.Collections.Generic;
using copatroca.Interfaces;
using copatroca.Models;
using System.Data.SqlClient;

namespace copatroca.Repositories { 

    internal class ContactRepository : IRepository<User.Contact> {
        private readonly string stringConexao = "server=labsoft.pcs.usp.br,1433;database=db_4;User=usuario_4;pwd=39431322853";
        
        public void Create(User.Contact userContact)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Contacts ([Info], [User_Id]) VALUES (@Info, @userId);";

                using(SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Info", userContact.Info);
                    cmd.Parameters.AddWithValue("@userId", userContact.uId);

                    try {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    } catch (Exception ex) {
                        Console.WriteLine(ex.GetType().Name);
                        Console.WriteLine(ex.Message);
                    }
                } 
            } 
        } 

        public void Delete(User.Contact userContact) { 
            using (SqlConnection con = new SqlConnection(stringConexao)) {
                string queryInsert = $"DELETE FROM Contacts WHERE id = @ContactId;";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con)) {
                    cmd.Parameters.AddWithValue("@ContactId", userContact.Id);

                    try {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    } catch (Exception ex) {
                        Console.WriteLine(ex.GetType().Name);
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        } 
        
        public User.Contact Read(User.Contact userContact) {
            using (SqlConnection con = new SqlConnection(stringConexao)) {
                string querySelect = $"SELECT * FROM Contacts WHERE id = @ContactId";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con)) {
                    cmd.Parameters.AddWithValue("@ContactId", userContact.Id);
                    try {
                        rdr = cmd.ExecuteReader();
                        if (rdr.HasRows) { 
                            rdr.Read();
                            userContact.Id = Convert.ToInt32(rdr[0]);
                            userContact.Info = rdr[2].ToString();
                        } 
                        else
                            throw new NullReferenceException("No contact found.");
                    } catch (Exception ex) {
                        Console.WriteLine(ex.GetType().Name);
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return userContact;
        }

        public User.Contact ReadContactByUserId(User.Contact userContact) {
            using (SqlConnection con = new SqlConnection(stringConexao)) {
                string querySelect = $"SELECT * FROM Contacts WHERE User_Id = @UserId";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con)) {
                    cmd.Parameters.AddWithValue("@UserId", userContact.uId);
                    try {
                        rdr = cmd.ExecuteReader();
                        if (rdr.HasRows) { 
                            rdr.Read();
                            userContact.Id = Convert.ToInt32(rdr[0]);
                            userContact.Info = rdr[2].ToString();
                        } 
                        else
                            throw new NullReferenceException("No contact found.");
                    } catch (Exception ex) {
                        Console.WriteLine(ex.GetType().Name);
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            return userContact;
        } 

        public void Update(User.Contact userContact)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = $"UPDATE Contacts SET Info = @Info WHERE id = @ContactId";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Info", userContact.Info);
                    cmd.Parameters.AddWithValue("@ContactId", userContact.Id);

                    try {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    } catch (Exception ex) {
                        Console.WriteLine(ex.GetType().Name);
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        public void UpdateContactByUserId(User.Contact userContact)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = $"UPDATE Contacts SET Info = @Info WHERE User_Id = @UserId";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Info", userContact.Info);
                    cmd.Parameters.AddWithValue("@UserId", userContact.uId);

                    try {
                        con.Open();
                        cmd.ExecuteNonQuery();
                    } catch (Exception ex) {
                        Console.WriteLine(ex.GetType().Name);
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }


    }
}
