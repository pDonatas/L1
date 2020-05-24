<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Puslapis.aspx.cs" Inherits="L1.Puslapis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Maršrutai</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" Text="Vykdyti" OnClick="Button1_Click" />
        <p>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </p>
            Pradiniai duomenys:<br />
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <asp:Table ID="Table1" runat="server">
            </asp:Table>
    </form>
</body>
</html>
