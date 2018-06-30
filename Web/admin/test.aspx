<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Web.admin.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="日结奖金" onclick="Button1_Click" />&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="周发奖金" onclick="Button2_Click"/>
        <br/>
          <br/>
            <br/>
              <br/>
                <br/>
                  <br/>
        <div style="display:">
    <asp:TextBox Text="delete tb_user where UserID>1; delete tb_bonus; delete tb_agent where AgentCode<>'system';delete from tb_remit;update tb_user set Emoney=1000000,LeftScore=0,BonusAccount=0,leftzt=0,rightzt=0, rightscore = 0, leftnewscore=0,rightnewscore=0,LeftBalance=0,rightbalance=0 where UserCode='system'" TextMode="MultiLine" runat="server" ID="txt_text" Width="400" Height="120"></asp:TextBox><br/><br/>
        <asp:LinkButton  ID="LinkButton1" runat="server" onclick="LinkButton1_Click">执行SQl</asp:LinkButton>

        </div>
    </div>
    </form>
</body>
</html>
