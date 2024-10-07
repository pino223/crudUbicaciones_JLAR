using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Capas
using BLL;
using DAL;

namespace crudUbicaciones_JLAR
{
    public partial class frmUbicaciones : System.Web.UI.Page
    {
        ubicaciones_BLL oUbicacionesBLL;
        ubicaciones_DAL oUbicacionesDAL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarUbicaciones();
            }
            
        }

        //Metodo encargado de listar los datos de la BD en un GRIDview
        public void ListarUbicaciones()
        {
            oUbicacionesDAL = new ubicaciones_DAL();
            gvUbicaciones.DataSource = oUbicacionesDAL.Listar();
            gvUbicaciones.DataBind();
        }

        //Metodo encargado de recolectar datos de nuestra interfaz
        public ubicaciones_BLL datosUbicacion()
        {
            int ID = 0;
            int.TryParse(txtID.Value, out ID);
            oUbicacionesBLL = new ubicaciones_BLL();
            //Recolectar datos de la capa de presentacion
            oUbicacionesBLL.ID = ID;
            oUbicacionesBLL.Ubicacion = txtUbicacion.Text;
            oUbicacionesBLL.Latitud = txtLat.Text;
            oUbicacionesBLL.Longitud = txtLong.Text;

            return oUbicacionesBLL;
        }

        
        

        protected void AgregarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDAL = new ubicaciones_DAL();
            oUbicacionesDAL.Agregar(datosUbicacion());
            ListarUbicaciones(); //Para mostrarlo en el gv
        }

        protected void ModificarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDAL = new ubicaciones_DAL();
            oUbicacionesDAL.Modificar(datosUbicacion());
            ListarUbicaciones(); // Para actualizar el GridView después de modificar
        }

        

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            oUbicacionesDAL = new ubicaciones_DAL();
            int ubicacionID = datosUbicacion().ID;
            oUbicacionesDAL.Eliminar(datosUbicacion());
            ListarUbicaciones(); //Para mostrarlo en el GV
        }

        protected void gvUbicaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnSeleccionar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                GridViewRow filaSeleccion = gvUbicaciones.Rows[indice];

                string idUbicacion = filaSeleccion.Cells[1].Text;
                string ubicacion = filaSeleccion.Cells[2].Text;
                string latitud = filaSeleccion.Cells[3].Text;
                string longitud = filaSeleccion.Cells[4].Text;

                txtID.Value = idUbicacion;
                txtUbicacion.Text = ubicacion;
                txtLat.Text = latitud;
                txtLong.Text = longitud;
            }
        }
    }
}