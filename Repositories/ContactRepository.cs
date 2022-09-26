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
        public void Create(Contact newContact)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Contacts ([Info], [User_Id]) VALUES (@Info, @User_Id);";

                using(SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Info", newContact.Info);
                    cmd.Parameters.AddWithValue("@User_Id", newContact.User_Id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                } 
            } 
        } 

        public void Delete(string idProduct) { 
            throw new NotImplementedException();
        } 
        

        public Contact Read(User user)
        {
            Contact contact = new Contact(user, "");

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = $"SELECT * FROM Contacts WHERE User_Id = @UserId";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@UserId", user.Id);
                    rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                        rdr.Read();

                    else
                        return contact;

                    contact.Info = rdr[1].ToString();
                    

                }

            }
            return contact;
        }

        public void Update(Contact updateContact)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = $"UPDATE Contacts SET Info = @Info WHERE User_Id = @UserId";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Info", updateContact.Info);
                    cmd.Parameters.AddWithValue("@UserId", updateContact.User_Id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }

    }
}