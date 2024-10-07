using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BLL;


namespace DAL
{
    public class ubicaciones_DAL
    {
        SQLDBHelper oConexion;
        //Inicializar la conexion a la BD(Constructor)
        public ubicaciones_DAL()
        {
            oConexion = new SQLDBHelper();
        }

        public bool Agregar(ubicaciones_BLL OubicacionesBLL)
        {
            SqlCommand cmdComando = new SqlCommand();

            cmdComando.CommandText = "INSERT INTO Direccion (Ubicacion, Latitud, Longitud) VALUES (@Ubicacion, @Latitud, @Longitud)";
            cmdComando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = OubicacionesBLL.Ubicacion;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = OubicacionesBLL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = OubicacionesBLL.Longitud;

            return oConexion.EjecutarComandoSQL(cmdComando);
        }
        public bool Eliminar(ubicaciones_BLL OubicacionesBLL)
        {
            SqlCommand cmdComando = new SqlCommand();

            cmdComando.CommandText = "DELETE FROM Direccion WHERE Id = @Id";
            cmdComando.Parameters.Add("@Id", SqlDbType.Int).Value = OubicacionesBLL.ID;

            return oConexion.EjecutarComandoSQL(cmdComando);
        }
        public bool Modificar(ubicaciones_BLL OubicacionesBLL)
        {
            SqlCommand cmdComando = new SqlCommand();

            cmdComando.CommandText = "UPDATE Direccion SET Ubicacion = @Ubicacion, Latitud = @Latitud, Longitud = @Longitud WHERE Id = @Id";
            cmdComando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = OubicacionesBLL.Ubicacion;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = OubicacionesBLL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = OubicacionesBLL.Longitud;
            cmdComando.Parameters.Add("@Id", SqlDbType.Int).Value = OubicacionesBLL.ID; // Asegúrate de tener el ID en el objeto

            return oConexion.EjecutarComandoSQL(cmdComando);
        }
        //Seleccionar los registros de la tabla con un SELECT
        public DataTable Listar()
        {
            SqlCommand cmdComando = new SqlCommand();
            //Sentencia SQL para traer todos los registros de la tabla "Direcciones"
            cmdComando.CommandText = "SELECT * FROM Direccion";
            //Tipo de comando ya sea: Texto, SP etc..
            cmdComando.CommandType = CommandType.Text;

            DataTable TablaResultante = oConexion.EjecutarSentenciaSQL(cmdComando);

            return TablaResultante;
        }

        
    }
}
