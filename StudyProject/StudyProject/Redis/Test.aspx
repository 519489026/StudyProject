<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="StudyProject.Redis.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        键：<asp:TextBox ID="txtKey" runat="server" Text="Key"></asp:TextBox><br />
        值：<asp:TextBox ID="txtValue" runat="server"></asp:TextBox><br />
        操作结果：<asp:TextBox ID="txtResult" runat="server" Width="500" Height="300" TextMode="MultiLine"></asp:TextBox><br />
        <asp:Button ID="btnWrite" runat="server" Text="写入" OnClick="btnWrite_Click" />
        <asp:Button ID="btnRead" runat="server" Text="读取" OnClick="btnRead_Click" />
        <asp:Button ID="btnRemove" runat="server" Text="删除" OnClick="btnRemove_Click" />
    </div>
    </form>
</body>
</html>
