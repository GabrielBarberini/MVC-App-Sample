using System;
using System.Collections.Generic;
using copatroca.Interfaces;
using copatroca.Models;
using System.Data.SqlClient;

namespace copatroca.Repositories { 

    internal class ContactRepository {
                
        
        public void Update(Contact updateContact)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = $"UPDATE Contacts SET Info = @Info WHERE User_Id = @UserId";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Info", updateContact.Info);
                    cmd.Parameters.AddWithValue("@UserId", updateContact.UserId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }


        }
     
    } 
} 
