using System;
using System.Collections.Generic;
using copatroca.Interfaces;
using copatroca.Models;
using System.Data.SqlClient;

namespace copatroca.Repositories {

    internal class UserRepository : IUserRepository
    {
        private readonly string stringConexao = "server=labsoft.pcs.usp.br,1433;database=db_4;User=usuario_4;pwd=39431322853";

        public void Create(User newUser)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = $"INSERT INTO CopaUsers VALUES (@Nome, @Email, @Password);";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", newUser.Name);
                    cmd.Parameters.AddWithValue("@Email", newUser.Email);
                    cmd.Parameters.AddWithValue("@Password", newUser.Password);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Update(User updateUser)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = $"UPDATE CopaUsers SET Nome = @Nome, Email = @Email, Password = @Password WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", updateUser.Name);
                    cmd.Parameters.AddWithValue("@Email", updateUser.Email);
                    cmd.Parameters.AddWithValue("@Password", updateUser.Password);
                    cmd.Parameters.AddWithValue("@Id", updateUser.Id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
} 
