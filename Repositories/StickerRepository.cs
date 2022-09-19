using System;
using System.Collections.Generic;
using copatroca.Interfaces;
using copatroca.Models;
using Sql.Data.SqlClient;
using Sql.Data;

namespace copatroca.Repositories { 

    internal class StickerRepository {
        //private readonly string stringConexao = "server=127.0.0.1;uid=root;pwd=maker;database=Catalog";        

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

        public List<Product> ReadAll() {
            List<Product> listProducts = new List<Product>();

            using (SqlConnection con = new SqlConnection(stringConexao)) {
                String querySelect = "SELECT * FROM Products;"; 
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con)) {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read()) {
                        Product product = new Product() {
                            IdProduct = rdr["IdProduct"].ToString(),
                            Name = rdr[1].ToString(),
                            Description = rdr[2].ToString(),
                            Price = Convert.ToDecimal(rdr[3])
                        }; 

                        listProducts.Add(product);
                    } 
                } 

                con.Close();
            } 
            
            return listProducts;
        }  

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
