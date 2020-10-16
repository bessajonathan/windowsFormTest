using Desafio.Models;
using Desafio.ViewModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System;

namespace Desafio.Repository
{
    public class Context
    {
        public readonly SQLiteConnection connection;

        public Context()
        {
            connection = new SQLiteConnection("Data Source=db.sqlite3 ");

            if (!File.Exists("./db.sqlite3"))
            {
                try
                {
                    SQLiteConnection.CreateFile("db.sqlite3");
                    CreateTable();
                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
        }

        private void OpenConnection()
        {
            if(connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        private void CloseConnection()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        private void CreateTable()
        {
            try
            {
                OpenConnection();
                var query = "CREATE TABLE Users (Id int,Nome varchar(50),Empresa varchar(50),Hash varchar(50),HashDecrip varchar(50))";
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteScalar();
                CloseConnection();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            try
            {
                var lst = new List<UserViewModel>();
                var query = "SELECT *FROM Users";
                OpenConnection();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                SQLiteDataReader result = command.ExecuteReader();

                if (result.HasRows)
                {

                    while (result.Read())
                    {
                        lst.Add(new UserViewModel
                        {
                            Id = int.Parse(result["Id"].ToString()),
                            Nome = result["Nome"].ToString(),
                            Empresa = result["Empresa"].ToString(),
                            Hash = result["Hash"].ToString(),
                            HashDecrip = result["HashDecrip"].ToString(),

                        });
                    }
                }

                CloseConnection();

                return lst;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        private void DeleteAllUsers()
        {
            try
            {
                var query = "DELETE FROM Users";
                OpenConnection();
                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.ExecuteScalar();
                CloseConnection();
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public void PopulationTableUsers(List<User> lstUsers)
        {
            try
            {
                DeleteAllUsers();
                OpenConnection();

                foreach (var users in lstUsers)
                {
                    var query = "INSERT INTO Users (Id,Nome,Empresa,Hash,HashDecrip) VALUES (@Id,@Nome,@Empresa,@Hash,@HashDecrip)";
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    command.Parameters.AddWithValue("Id",users.Id);
                    command.Parameters.AddWithValue("Nome",users.Name);
                    command.Parameters.AddWithValue("Empresa",users.Company);
                    command.Parameters.AddWithValue("Hash",users.Hash);
                    command.Parameters.AddWithValue("HashDecrip", users.HashDecrip);
                    command.ExecuteNonQuery();
                }

                CloseConnection();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}