using System;
using System.Collections.Generic;
using System.Text;

using TestApp.Entities;

using System.Data.SqlClient;
using TestApp.Helpers;

namespace TestApp.Respository
{
    class MusicianRepository : IRepository<Musician, int>
    {
        SqlCommand command;
        public Musician Create(Musician entity)
        {
            command = new SqlCommand(
                $"INSERT INTO tb_musician (inss_number, first_name, last_name, salary, tb_address_id, created_by, updated_by) " +
                $"VALUES ('{entity.inss_number}', '{entity.first_name}', '{entity.last_name}', '{entity.salary}', " +
                $"'{entity.tb_address_id}', '{entity.created_by}', '{entity.updated_by}')"
            );
            SqlConnection conn = GlobalSettings.Connection();
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            command.Parameters.Clear();
            return entity;
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<Musician> GetAll()
        {
            command = new SqlCommand($"SELECT * FROM tb_musician");
            SqlConnection conn = GlobalSettings.Connection();
            command.Connection = conn;
            conn.Open();
            SqlDataReader reader = command.ExecuteReader(); /*Permite leer un flujo de filas*/

            List<Musician> musicians = new List<Musician>(); /*Crea una lista para guardar los registros*/

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    musicians.Add( /*Agrega elementos a la lista*/
                        new Musician() {
                            inss_number = reader["inss_number"].ToString(),
                            first_name = reader["first_name"].ToString(),
                            last_name = reader["last_name"].ToString(),
                        }
                    );
                }
            }

            return musicians;
        }

        public Musician GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public Musician Update(Musician entity)
        {
            throw new NotImplementedException();
        }
    }
}
