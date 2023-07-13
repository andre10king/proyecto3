using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace back_reserva.Models
{
    public class GestorReservaandres
    {

        public List<Reservaandres> GetReservaandres()
        {
            List<Reservaandres> lista = new List<Reservaandres>();
            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Reserva_All";
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    int id = dr.GetInt32(0);
                    string nombre = dr.GetString(1).Trim();
                    string origen = dr.GetString(2).Trim();
                    string destino = dr.GetString(3).Trim();
                    string categoria = dr.GetString(4).Trim();
                    int cantpasj = dr.GetInt32(5);
                    string cedula = dr.GetString(6).Trim();




                    Reservaandres reservaandres = new Reservaandres(id, nombre, origen, destino, categoria, cantpasj, cedula);

                    lista.Add(reservaandres);
                }

                dr.Close();
                conn.Close();
            }

            return lista;
        }

        public bool addReserva(Reservaandres reservaandres)
        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "Reserva_Add";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nombre", reservaandres.nombre);
                cmd.Parameters.AddWithValue("@origen", reservaandres.origen);
                cmd.Parameters.AddWithValue("@destino", reservaandres.destino);
                cmd.Parameters.AddWithValue("@categoria", reservaandres.categoria);
                cmd.Parameters.AddWithValue("@cantpasj", reservaandres.cantpasj);
                cmd.Parameters.AddWithValue("@cedula", reservaandres.cedula);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return res;
            }
        }

        public bool updateReserva(int id, Reservaandres reservaandres)
        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "Reserva_Update";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombre", reservaandres.nombre);
                cmd.Parameters.AddWithValue("@origen", reservaandres.origen);
                cmd.Parameters.AddWithValue("@destino", reservaandres.destino);
                cmd.Parameters.AddWithValue("@categoria", reservaandres.categoria);
                cmd.Parameters.AddWithValue("@cantpasj", reservaandres.cantpasj);
                cmd.Parameters.AddWithValue("@cedula", reservaandres.cedula);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return res;
            }
        }

        public bool deleteReserva(int id)
        {
            bool res = false;

            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "Reserva_Delete";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    res = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

                return res;
            }
        }
    }
}