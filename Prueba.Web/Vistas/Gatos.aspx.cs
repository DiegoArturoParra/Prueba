using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prueba.Web.Vistas
{
    public partial class Gatos : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void BTN_buscar_Click(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://api.thecatapi.com/v1/images/search"))
                {
                    string json = await response.Content.ReadAsStringAsync();
                   
                }
            }
        }
    }
}