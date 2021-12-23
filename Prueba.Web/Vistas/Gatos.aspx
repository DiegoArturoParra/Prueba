<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gatos.aspx.cs" Async="true" Inherits="Prueba.Web.vistas.Gatos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="Formulario" runat="server">
        <div>
            <asp:Button Text="Buscar gatos" ID="BTN_buscarGatos" OnClick="BTN_buscarGatos_Click" runat="server" />
            <asp:Label ID="LB_Mensaje" Font-Bold="true" Visible="false" runat="server" />
            <asp:Button Text="Guardar" ID="BTN_guardar" Visible="false" OnClick="BTN_guardar_Click" runat="server" />
        </div>

        <br />
        <div>
            <asp:Image ID="ImagenGato" Width="400" Height="400" runat="server" />
        </div>
        <div>
            <asp:GridView ID="GV_Gatos" OnRowCommand="GV_Gatos_RowCommand" AutoGenerateColumns="False" runat="server">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
                    <asp:ImageField DataImageUrlField="url" ControlStyle-Height="200" ControlStyle-Width="250" HeaderText="Imagen" SortExpression="url" />
                    <asp:BoundField DataField="width" HeaderText="Ancho" SortExpression="width" />
                    <asp:BoundField DataField="height" HeaderText="Altura" SortExpression="height" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
