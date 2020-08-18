using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPRN3_U3
{
    class DataBase
    {
        private string conn = ConfigurationManager.ConnectionStrings["connectionstringDPRN3"].ToString();

        public DataTable Get_Lista()
        {
            //SE CREA EL OBJETO DATATABLE
            DataTable dt = new DataTable();
            try
            {
                // SE USA LA CLASE SQL CONNECTION QUE RECIBE COMO PARÁMETRO LA CADENA DE CONEXIÓN
                using (SqlConnection cn = new SqlConnection(conn))
                {
                    //SE ABRE LA CADENA DE CONEXIÓN
                    cn.Open();
                    //SE USA LA CLASE SQLCOMMAND QUE INSTANCIA EL COMANDO SQL A UTILIZAR
                    //EN ESTE CASO, SE USA UN STORED PROCEDURE
                    using (SqlCommand cmd = new SqlCommand("dbo.spObtenerListaEmpleado", cn))
                    {
                        //SE LE DICE AL COMANDO QUE ES UN STORED PROCEDURE
                        cmd.CommandType = CommandType.StoredProcedure;
                        //SE USA LA CLASE SQLADAPTER PARA ASIGNAR LOS VALORES OBTENIDOS AL
                        //DATA TABLE
                        using (SqlDataAdapter da = new SqlDataAdapter())
                        {
                            da.SelectCommand = cmd;
                            da.Fill(dt);
                        }
                    }
                }
            }
            //SE OBTIENE LA EXCEPCIÓN DE TIPO SQL SI SE GENERA
            catch (SqlException ex)
            {
                //SE CREA UN MÉTODO GENÉRICO PARA MOSTRAR EN CONSOLA LOS ERRORES
                //PROPORCIONADOS POR LA EXCEPCIÓN ATRAPADA.
                MostrarErroresSQL(ex);
            }
            //SE DEVUELVEN LOS DATOS EN UN TIPO DATATABLE
            return dt;
        }

        private static void MostrarErroresSQL(SqlException exception)
        {
            //SE OBTIENEN LOS ERRORES DE LA EXCEPCIÓN OBTENIDA
            for (int i = 0; i < exception.Errors.Count; i++)
            {
                Console.WriteLine("Index #" + i + "\n" +
                    "Error: " + exception.Errors[i].ToString() + "\n");
            }
            Console.ReadLine();
        }
    }
}
