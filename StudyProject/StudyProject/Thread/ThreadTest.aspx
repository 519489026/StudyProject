<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ThreadTest.aspx.cs" Inherits="StudyProject.Thread.ThreadTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        创建数量<asp:TextBox ID="txtCount" runat="server"></asp:TextBox><br />
        <asp:Button runat="server" Text="确认创建" ID="btnCreate" OnClick="btnCreate_Click" /><br />
        <asp:TextBox ID="txtResult" runat="server" TextMode="MultiLine" Width="600" Height="600"></asp:TextBox>
    </div>
    </form>
</body>
</html>
