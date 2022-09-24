using System;
using System.Collections.Generic;
using copatroca.Interfaces;
using copatroca.Models;
using System.Data.SqlClient;

namespace copatroca.Repositories { 

    internal class ContactRepository {
        private readonly string stringConexao = "server=labsoft.pcs.usp.br,1433;database=db_4;User=usuario_4;pwd=39431322853";    

        /*public void Create(Product newProduct) { 
            using (SqlConnection con = new SqlConnection(stringConexao)) {
                string queryInsert = $"INSERT INTO Products (IdProduct, Name, Description, Price) VALUES (@IdProduct, @Name, @Description, @Price);";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con)) {
                    // To prevent SQL injection
                    cmd.Parameters.AddWithValue("@IdProduct", newProduct.IdProduct);
                    cmd.Parameters.AddWithValue("@Name", newProduct.Name);
                    cmd.Parameters.AddWithValue("@Description", newProduct.Description);
                    cmd.Parameters.AddWithValue("@Price", newProduct.Price);

                    con.Open();
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    con.Close();
                } 
            } 
        } 

        public void Delete(string idProduct) { 
            throw new NotImplementedException();
        } 
        */

        public Contact Read(User user)
        {
            Contact contact = new Contact(user);

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
        /*
        public void Update(Product product) {
            throw new NotImplementedException();
        } 


        public void LoadData() { 
            Faker<Product> ProductFaker() => new Faker<Product>()
                .RuleFor(d => d.IdProduct, f => f.Random.Guid().ToString())
                .RuleFor(d => d.Name, f => f.Commerce.ProductName())
                .RuleFor(d => d.Description, f => f.Commerce.ProductDescription())
                .RuleFor(d => d.Price, f => Convert.ToDecimal(f.Commerce.Price()));

            List<Product> products = ProductFaker().Generate(150);

            using (SqlConnection con = new SqlConnection(stringConexao)) {
                string queryInsert = $"INSERT INTO Products (IdProduct, Name, Description, Price) VALUES (@IdProduct, @Name, @Description, @Price);";
                con.Open();
                foreach (var item in products) { 
                    using (SqlCommand cmd = new SqlCommand(queryInsert, con)) {
                        // To prevent SQL injection
                        cmd.Parameters.AddWithValue("@IdProduct", item.IdProduct);
                        cmd.Parameters.AddWithValue("@Name", item.Name);
                        cmd.Parameters.AddWithValue("@Description", item.Description);
                        cmd.Parameters.AddWithValue("@Price", item.Price);

                        cmd.Prepare();
                        cmd.ExecuteNonQuery();
                    }
                } 

                con.Close();
            }
        } 
    */
    } 
} 
