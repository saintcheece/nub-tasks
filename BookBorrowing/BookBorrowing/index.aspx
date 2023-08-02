<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BookBorrowing.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body{
            background-color: black;
        }
    </style>
</head>
<body >
    <form id="form1" runat="server">
        <center>
        <div>
            <table style ="background: url(img/nu4.png);  background-size:cover; width:250px; height: 250px; margin-top: 5%; " >
                
            </table>

            <table style =" width:900px; height: 50px;" >
                <tr>
                   <td>
                        
                   </td>


                </tr >

                <tr>
                    <td style="font-size:25px; color:white; text-align:center; padding-top:2em; padding-left:7%; 
                        font-family: 'Copperplate Gothic'; font-weight:bold; padding:0; text-align:center;">

                        ---learning resources---

                    </td>
                </tr>

                <tr>
                    <td style="text-align:center; padding-top:2em;" >
                        <asp:Button ID="btntransaction" runat="server" Text="Make a Transaction" Height="45px" Width="550px" Style="background-color: cornflowerblue; font-family: 'Copperplate Gothic'; font-weight: bold; font-size: 20px; border-radius: 20px; box-shadow: 5px 7px 3px rgba(255, 252, 127, 0.3);" OnClick="btntransaction_Click" />
                    </td>
                </tr>

               

                 <tr>
                    <td colspan="2" style="text-align:center; padding-top:2em;" >
                        <asp:Button ID="btnManageBooks" runat="server" Text="Manage Books" Height="40px" Width="250px" Style="background-color: #FFFF8F; font-family: 'Copperplate Gothic'; 
                                                                                                                font-weight: bold; font-size: 18px; border-radius: 20px; 
                                                                                                                box-shadow: 0px 5px 5px 2px rgba(113, 187, 212, 0.3);" OnClick="btnManageBooks_Click" />

                        <asp:Button ID="btnManagePatrons" runat="server" Text="Manage Patrons" Height="40px" Width="250px" Style="background-color: #FFFF8F; font-family: 'Copperplate Gothic'; font-weight: bold; font-size: 18px; border-radius: 20px; box-shadow: 0px 5px 5px 2px rgba(113, 187, 212, 0.3);" OnClick="btnManagePatrons_Click" />
                    </td>
                </tr>
               
               
            </table>
                

               

            
        </div>
        </center>
    </form>
</body>
</html>
