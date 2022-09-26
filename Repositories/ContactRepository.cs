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
        public void CreateContact(User user, string info)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Contacts ([Info], [userId]) VALUES (@Info, @userId);";

                using(SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Info", info);
                    cmd.Parameters.AddWithValue("@userId", user.Id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                } 
            } 
        } 

        public void DeleteContact(string idProduct) { 
            throw new NotImplementedException();
        } 
        

        public User.Contact ReadContact(User user) {
            using (SqlConnection con = new SqlConnection(stringConexao)) {
                string querySelect = $"SELECT * FROM Contacts WHERE userId = @UserId";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con)) {
                    cmd.Parameters.AddWithValue("@UserId", user.Id);
                    rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                        rdr.Read();

                    else
                        return user.contact;

                    user.contact.Info = rdr[1].ToString();
                }
            }
            return user.contact;
        }

        public void UpdateContact(User user)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = $"UPDATE Contacts SET Info = @Info WHERE userId = @UserId";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Info", user.contact.Info);
                    cmd.Parameters.AddWithValue("@UserId", user.Id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }

    }
}
