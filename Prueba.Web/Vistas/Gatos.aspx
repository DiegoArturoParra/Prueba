<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gatos.aspx.cs" Inherits="Prueba.Web.Vistas.Gatos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="BTN_buscar" BackColor="Green" Text="Buscar Gato" OnClick="BTN_buscar_Click" runat="server" />
        </div>
        <asp:GridView ID="GV_Gatos" runat="server">

        </asp:GridView>
        grid
    </form>
</body>
</html>
