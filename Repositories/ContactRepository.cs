using System;
using System.Collections.Generic;
using copatroca.Interfaces;
using copatroca.Models;
using System.Data.SqlClient;

namespace copatroca.Repositories { 

    internal class ContactRepository {
        private readonly string stringConexao = "server=labsoft.pcs.usp.br,1433;database=db_4;User=usuario_4;pwd=39431322853";
        
        /// <summary>
        ///Adiciona uma informação de contato de um determinado usuário 
        /// </summary>
        /// <param name="newContact">String livre para o usuário inserir as informações de contato</param>
        /// <param name="newContactUser">Contato que terá o contato adicionado</param>
        public void CreateContact(string email, string info)
        {
            UserRepository _userDB = new UserRepository();
            User user = _userDB.ReadUser(email);

            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Contacts ([Info], [User_Id]) VALUES (@Info, @userId);";

                using(SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Info", info);
                    cmd.Parameters.AddWithValue("@userId", user.Id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                } 
            } 
        } 

        public void DeleteContact(User user) { 
            using (SqlConnection con = new SqlConnection(stringConexao)) {
                string queryInsert = $"DELETE FROM Contacts WHERE User_Id = @UserId;";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con)) {
                    cmd.Parameters.AddWithValue("@UserId", user.Id);

                    con.Open();
                    try {
                        cmd.ExecuteNonQuery();
                    } catch (Exception ex) {
                        Console.WriteLine(ex.GetType().Name);
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        } 
        
        public string ReadContact(User user) {
            string info = "";

            using (SqlConnection con = new SqlConnection(stringConexao)) {
                string querySelect = $"SELECT * FROM Contacts WHERE User_Id = @UserId";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con)) {
                    cmd.Parameters.AddWithValue("@UserId", user.Id);
                    rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                        rdr.Read();

                    else
                        return info;

                     info = rdr[1].ToString();
                }
            }
            return info;
        }

        public void UpdateContact(User user, string info)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = $"UPDATE Contacts SET Info = @Info WHERE User_Id = @UserId";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Info", info);
                    cmd.Parameters.AddWithValue("@UserId", user.Id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }

    }
}
