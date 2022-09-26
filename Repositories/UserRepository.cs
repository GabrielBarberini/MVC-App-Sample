using System;
using System.Collections.Generic;
using copatroca.Interfaces;
using copatroca.Models;
using System.Data.SqlClient;

namespace copatroca.Repositories {

    internal class UserRepository : IUserRepository {
        private readonly string stringConexao = "server=labsoft.pcs.usp.br,1433;database=db_4;User=usuario_4;pwd=39431322853";

        public void CreateUser(User newUser) {
            using(SqlConnection con = new SqlConnection(stringConexao)) {
                string queryInsert = $"INSERT INTO CopaUsers VALUES (@Nome, @Email, @Password);";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con)) {
                    cmd.Parameters.AddWithValue("@Nome", newUser.Name);
                    cmd.Parameters.AddWithValue("@Email", newUser.Email);
                    cmd.Parameters.AddWithValue("@Password", newUser.Password);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateUser(User user) {
            using (SqlConnection con = new SqlConnection(stringConexao)) {
                string queryInsert = $"UPDATE CopaUsers SET Nome = @Nome, Email = @Email, Password = @Password WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con)) {
                    cmd.Parameters.AddWithValue("@Nome", user.Name);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Id", user.Id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public User ReadUser(string userEmail) {
            User user = new User();

            using (SqlConnection con = new SqlConnection(stringConexao)) {
                string querySelect = $"SELECT * FROM CopaUsers WHERE Email = @Email";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con)) {
                    cmd.Parameters.AddWithValue("@Email", userEmail);
                    rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                        rdr.Read();
                    else
                        return user;

                    user.Id = Convert.ToInt32(rdr[0]);
                    user.Name = rdr[1].ToString();
                    user.Email = rdr[2].ToString();
                    user.Password = rdr[3].ToString();
                }
            }
            return user;
        }

        public void DeleteUser(User user) {
            using (SqlConnection con = new SqlConnection(stringConexao)) {
                string queryInsert = $"DELETE FROM CopaUsers WHERE id = @Id;";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con)) {
                    cmd.Parameters.AddWithValue("@Id", user.Id);

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
    }
}
