using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_reserva.Models
{
    public class Reservaandres
    {
        public int idReserva { get; set; }
        public string nombre { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public string categoria { get; set; }
        public int cantpasj { get; set; }
        public string  cedula { get; set; }



        public Reservaandres() { }


        public Reservaandres(int id, string Nombre, string Origen, string Destino, string Categoria, int  Cantpasj, string Cedul)
        {
            idReserva = id;
            nombre = Nombre;
            origen =  Origen;
            destino = Destino;
            categoria = Categoria;
            cantpasj = Cantpasj;
            cedula = Cedul;



        }


        public Reservaandres(string Nombre, string Origen, string Destino, string Categoria, int Cantpasj, string Cedul)
        {

            nombre = Nombre;
            origen = Origen;
            destino = Destino;
            categoria = Categoria;
            cantpasj = Cantpasj;
            cedula = Cedul;
        }

    }



}