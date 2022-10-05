using System;
using System.Collections.Generic;
using copatroca.Interfaces;
using copatroca.Models;
using copatroca.Controllers;
using copatroca.Views;
using System.Data.SqlClient;

namespace copatroca.Repositories {

    internal class UserRepository : IRepository<User> {
        private readonly string stringConexao = "server=labsoft.pcs.usp.br,1433;database=db_4;User=usuario_4;pwd=39431322853";

        public void Create(User newUser) {
            using(SqlConnection con = new SqlConnection(stringConexao)) {
                string queryInsert = $"INSERT INTO CopaUsers VALUES (@Nome, @Email, @Password);";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con)) {
                    cmd.Parameters.AddWithValue("@Nome", newUser.Name);
                    cmd.Parameters.AddWithValue("@Email", newUser.Email);
                    cmd.Parameters.AddWithValue("@Password", newUser.Password);

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

        public void Update(User user) {
            using (SqlConnection con = new SqlConnection(stringConexao)) {
                string queryInsert = $"UPDATE CopaUsers SET Nome = @Nome, Email = @Email, Password = @Password WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con)) {
                    cmd.Parameters.AddWithValue("@Nome", user.Name);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Parameters.AddWithValue("@Id", user.Id);

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

        public User Read(User user) {
            User rUser;
            using (SqlConnection con = new SqlConnection(stringConexao)) {
                string querySelect = $"SELECT * FROM CopaUsers WHERE Id = @Id";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con)) {
                    cmd.Parameters.AddWithValue("@Id", user.Id);

                    try {
                        rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                            rdr.Read();

                        rUser = new User(Id: Convert.ToInt32(rdr[0]), Name: rdr[1].ToString(), Email: rdr[2].ToString(), Password: rdr[3].ToString(), Info: "No contact info");
                    } catch (Exception ex) {
                        return user;
                    }
                }
            }

            return rUser;
        }

        public User ReadUserByEmail(User user) {
            User rUser;
            using (SqlConnection con = new SqlConnection(stringConexao)) {
                string querySelect = $"SELECT * FROM CopaUsers WHERE Email = @Email";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con)) {
                    cmd.Parameters.AddWithValue("@Email", user.Email);

                    try {
                        rdr = cmd.ExecuteReader();
                        if (rdr.HasRows)
                            rdr.Read();

                        rUser = new User(Id: Convert.ToInt32(rdr[0]), Name: rdr[1].ToString(), Email: rdr[2].ToString(), Password: rdr[3].ToString(), Info: "No contact info");
                    } catch (Exception ex) {
                        return user;
                    }
                }
            }

            return rUser;
        }

        public void Delete(User user) {
            using (SqlConnection con = new SqlConnection(stringConexao)) {
                string queryInsert = $"DELETE FROM CopaUsers WHERE id = @Id;";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con)) {
                    cmd.Parameters.AddWithValue("@Id", user.Id);

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
