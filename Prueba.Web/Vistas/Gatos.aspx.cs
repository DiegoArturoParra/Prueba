using Newtonsoft.Json;
using Prueba.Models;
using Prueba.Models.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Prueba.Web.vistas
{
    public partial class Gatos : System.Web.UI.Page
    {
        private static Gato gato { get; set; }
        private GatoService service = new GatoService();
        protected async void Page_Load(object sender, EventArgs e)
        {

            await actualizarTabla();

        }

        protected async void BTN_buscarGatos_Click(object sender, EventArgs e)
        {
            gato = await service.GetGato();
            ImagenGato.ImageUrl = gato.url;
            LB_Mensaje.Text = "De click en guardar si desea este gato.";
            LB_Mensaje.Visible = true;
            BTN_guardar.Visible = true;
        }

        protected async void BTN_guardar_Click(object sender, EventArgs e)
        {
            if (gato != null)
            {
                string json = JsonConvert.SerializeObject(gato);
                LB_Mensaje.Text = await service.GuardarGato(json);
                await actualizarTabla();
            }
        }

        private async Task actualizarTabla()
        {
            try
            {
                List<Gato> gatos = new List<Gato>();
                gatos = await service.GetGatos();
                GV_Gatos.DataSource = gatos;
                GV_Gatos.DataBind();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        protected async void GV_Gatos_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                //Primero capturas la fila
                int numFila = ((GridViewRow)((LinkButton)e.CommandSource).Parent.Parent).RowIndex;

                //Obtienes el nombre y precio de los boundfield
                string Id = (GV_Gatos.Rows[numFila].Cells[0].Text);
                if (!string.IsNullOrEmpty(Id))
                {
                    LB_Mensaje.Text = await service.Eliminar(Id);
                    LB_Mensaje.Visible = true;
                    await actualizarTabla();
                }
            }
        }
    }
}