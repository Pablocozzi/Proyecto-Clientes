using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;
using System.ComponentModel;

namespace Clase3_Debate2.pry
{
    internal class clsArchivo
    {
        public string NombreArchivo = "Clientes.csv";

        public void Grabar(string codigo, string nombre, string deuda, string limite)
        {
            StreamWriter AD = new StreamWriter(NombreArchivo, true);
            // cargamos un dato al lado de el otro, y al final le sumamos el salto de linea para que siga escribiendo abajo
            AD.Write(codigo);
            // ; para que nos divida los datos y no se agregue todo en la misma celda, son separadores en excel
            // quedaria asi: 12; juan; 100; 1550 enter 
            AD.Write(";");
            AD.Write(nombre);
            AD.Write(";");
            AD.Write(deuda);
            AD.Write(";");
            AD.WriteLine(limite);
            AD.Close();
            AD.Dispose();
        }

        public void Listar(DataGridView Grilla)
        {
            string DatosLeidos = "";
            // creamos vector para poder agregar los datos
            string[] vecDatos = new string[4];
            Grilla.Rows.Clear();
            StreamReader AD = new StreamReader(NombreArchivo);
            // lee las lineas 
            DatosLeidos = AD.ReadLine();
            // estructura repetitiva para leer los datos hasta que no haya mas datos
            while (DatosLeidos != null)
            {   
                // sumamos al vector los datos leidos, y la funcion split sirve para separarlos 
                vecDatos = DatosLeidos.Split(';');
                // cargamos a la grilla el vector en cada indice
                Grilla.Rows.Add(vecDatos[0], vecDatos[1], vecDatos[2], vecDatos[3] );
                DatosLeidos = AD.ReadLine();
            }
            AD.Close ();
            AD.Dispose ();
        }
        // declaramos una funcion, todas las funciones retornan un valor 
        public int CantidadClientes()
        {
            string DatosLeidos = "";
            // declaramos variable para ir sumando la cantidad de filas, osea clientes
            int c = 0;
            StreamReader AD = new StreamReader(NombreArchivo);
            DatosLeidos = AD.ReadLine();
            while (DatosLeidos != null)
            {

                c++;
                DatosLeidos = AD.ReadLine();
            }
            AD.Close();
            AD.Dispose();
            return c;
        }

        public Decimal TotalDeuda()
        {
            string DatosLeidos = "";
            Decimal total = 0;
            string[] vecDatos = new string[4];
            StreamReader AD = new StreamReader(NombreArchivo);
            DatosLeidos = AD.ReadLine();
            while (DatosLeidos != null)
            {
                //recorremos el vector y los vamos sumando
                vecDatos = DatosLeidos.Split(';');
                total = total + Convert.ToDecimal(vecDatos[2]);
                DatosLeidos = AD.ReadLine();
            }
            AD.Close();
            AD.Dispose();
            return total;
        }

        public Decimal PromedioDeuda() //de todos los clientes
        {
            // mezclamos los dos procedimientos anteriores
            string DatosLeidos = "";
            Decimal total = 0;
            int c = 0;
            Decimal Promedio = 0;
            string[] vecDatos = new string[4];
            StreamReader AD = new StreamReader(NombreArchivo);
            DatosLeidos = AD.ReadLine();
            while (DatosLeidos != null)
            {
                vecDatos = DatosLeidos.Split(';');
                total = total + Convert.ToDecimal(vecDatos[2]);
                c++;
                DatosLeidos = AD.ReadLine();
            }
            Promedio = total / c;
            AD.Close();
            AD.Dispose();
            return Promedio;
        }

        public void ListarDeudores(DataGridView Grilla)
        {
            string DatosLeidos = "";
            string[] vecDatos = new string[4];
            Grilla.Rows.Clear();
            StreamReader AD = new StreamReader(NombreArchivo); 
            DatosLeidos = AD.ReadLine();
            while (DatosLeidos != null)
            {
                vecDatos = DatosLeidos.Split(';');
                // agregamos if para elegir mayores a 0
                if (Convert.ToInt32(vecDatos[2]) > 0)
                {
                    Grilla.Rows.Add(vecDatos[0], vecDatos[1], vecDatos[2], vecDatos[3]);
                }
                DatosLeidos = AD.ReadLine();
            }
            AD.Close();
            AD.Dispose();
        }

        public int CantidadClientesDeudores()
        {
            string DatosLeidos = "";
            string[] vecDatos = new string[4];
            int c = 0;
            StreamReader AD = new StreamReader(NombreArchivo);
            DatosLeidos = AD.ReadLine();
            while (DatosLeidos != null)
            {
                vecDatos = DatosLeidos.Split(';');
                // agregamos if para elegir mayores a 0
                if (Convert.ToInt32(vecDatos[2]) > 0)
                {
                    c++;
                }
                DatosLeidos = AD.ReadLine();
            }
            AD.Close();
            AD.Dispose();
            return c;
        }

        public Decimal PromedioDeudaDeudores()
        {
            string DatosLeidos = "";
            Decimal total = 0;
            int c = 0;
            Decimal Promedio = 0;
            string[] vecDatos = new string[4];
            StreamReader AD = new StreamReader(NombreArchivo);
            DatosLeidos = AD.ReadLine();
            while (DatosLeidos != null)
            {
                vecDatos = DatosLeidos.Split(';');
                if (Convert.ToInt32(vecDatos[2]) > 0)
                {
                    total = total + Convert.ToDecimal(vecDatos[2]);
                    c++;
                }

                DatosLeidos = AD.ReadLine();
            }
            Promedio = total / c;
            AD.Close();
            AD.Dispose();
            return Promedio;
        }
        public void GenerarReporte() //con este procedimiento pasamos datos de un archivo a otro
        {
            //declaramos variable que se usa en el bucle
            string DatosLeidos = "";
            //declaramos el vector que guarda los datos de el split
            string[] vecDatos = new string[4];

            //declaramos variables para contador y acumulador
            Decimal Total = 0;
            int Cantidad = 0;


            //abrimos archivo ya creado
            StreamReader AD = new StreamReader(NombreArchivo);
            //leemos archivo
            DatosLeidos = AD.ReadLine();
            //abrimos archivo de a donde se van a pasar los datos 
            StreamWriter Reporte = new StreamWriter("Reporte.csv", false, Encoding.UTF8); //Enconding.UTF8 sirve para que el programa reconozca caracteres especiales
            // escribimos reporte 
            Reporte.WriteLine("Listado de clientes");
            Reporte.WriteLine("");
            Reporte.WriteLine("Codigo; Nombre; Deuda; Limite");

            // mientras alla datos pasamos los datos a un vector auxiliar 
            while (DatosLeidos != null)
            {

                vecDatos = DatosLeidos.Split(';');
                Reporte.Write(vecDatos[0]);
                Reporte.Write(";");
                Reporte.Write(vecDatos[1]);
                Reporte.Write(";");
                Reporte.Write(vecDatos[2]);
                Reporte.Write(";");
                Reporte.WriteLine(vecDatos[2]);
                Cantidad++;
                Total = Total + Convert.ToDecimal(vecDatos[2]);

                DatosLeidos = AD.ReadLine();
            }
            //se acaba y cerramos
            AD.Close();
            AD.Dispose();
            //mostramos valores de acumulador y contador
            Reporte.WriteLine("");
            Reporte.Write("Cantidad de clientes: ;;;");
            Reporte.WriteLine(Cantidad);
            Reporte.Write("Total de deuda: ;;;");
            Reporte.WriteLine(Total);
            Reporte.Write("Promedio de deuda: ;;;");
            Reporte.WriteLine(Total/Cantidad);

            // cerramos reporte
            Reporte.Close();
            Reporte.Dispose();

        }

        public struct RegCliente
        {
            public Int32 Codigo;
            public string Nombre;
            public Decimal Deuda;
            public Decimal Limite;
        }

        private RegCliente[] vecClientes = new RegCliente[1500];
        private Int32 IND = 0;

        private void PasarDatosVector()
        {
            string DatosLeidos = "";
            string[] vecDatos = new string[4];
            IND = 0;
            StreamReader AD = new StreamReader(NombreArchivo);

            DatosLeidos = AD.ReadLine();

            while (DatosLeidos != null)
            {

                vecDatos = DatosLeidos.Split(';');
                vecClientes[IND].Codigo = Convert.ToInt32( vecDatos[0]);
                vecClientes[IND].Nombre = vecDatos[1];
                vecClientes[IND].Deuda = Convert.ToDecimal(vecDatos[2]);
                vecClientes[IND].Limite = Convert.ToDecimal(vecDatos[3]);
                IND++;
                DatosLeidos = AD.ReadLine();
            }
            AD.Close();
            AD.Dispose();
        }

        private void OrdenarVector()
        {
            //variable con tipo de dato de el vector
            RegCliente aux;
            //metodo de ordenacion burbuja
            for (Int32 c=0; c< IND-1; c++)
            {
                for (Int32 i = 0; i < IND - 1; i++)
                {
                    if (vecClientes[i].Codigo > vecClientes[i + 1].Codigo)
                    {
                        aux = vecClientes[i];
                        vecClientes[i] = vecClientes[i + 1];
                        vecClientes[i + 1] = aux;
                    }

                }
            }
        }

        private void ReescribirArchivo()
        {
            StreamWriter AD = new StreamWriter(NombreArchivo, false);
            for (Int32 i = 0; i < IND; i++)
            {
                AD.Write(vecClientes[i].Codigo);
                AD.Write(";");
                AD.Write(vecClientes[i].Nombre);
                AD.Write(";");
                AD.Write(vecClientes[i].Deuda);
                AD.Write(";");
                AD.WriteLine(vecClientes[i].Limite);
            }
            AD.Close();
            AD.Dispose();
        }


        public void OrdenarDatos()//agarramos los datos, pasamos a vector, ordenamos vector y sobreescribimos archivo con datos ordenados
        {
            //pasar datos a vector
            PasarDatosVector();
            //ordenar vector
            OrdenarVector();
            //pasar datos ordenados a vector
            ReescribirArchivo();
        }
    }
}
