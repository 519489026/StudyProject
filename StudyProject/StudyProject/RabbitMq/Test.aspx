<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="StudyProject.RabbitMq.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        操作数量：<asp:TextBox ID="txtCount" runat="server" Text="50"></asp:TextBox><br />
        操作结果：<asp:TextBox ID="txtResult" runat="server" Width="600" Height="300" TextMode="MultiLine"></asp:TextBox><br />
        <asp:Button ID="btnAdd" runat="server" Text="写入队列" OnClick="btnAdd_Click" />
        <asp:Button ID="btnRead" runat="server" Text="读取队列" OnClick="btnRead_Click" />
        <asp:Button ID="btnConsume" runat="server" Text="消费队列" OnClick="btnConsume_Click" />
    </div>
    </form>
</body>
</html>
