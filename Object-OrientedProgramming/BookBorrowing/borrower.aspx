`<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="borrower.aspx.cs" Inherits="BookBorrowing.Borrower" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Borrower Information</title>
</head>
<body style="background: url(img/bkb2.jpg);
            background-size:cover;">
    <form id="form1" runat="server">
        <center>
        <div>
            <table style="background:rgba(0,0,0,0.7); box-shadow:inset -2px 2px 5px white; padding-right:2%;
                          border-radius:10px; font-size:16px; font-weight:500;font-family:'Copperplate Gothic'; font-size:18px; 
                          width: 700px; height:530px; color:white; text-align:right; margin-top:7%; padding-bottom:2em;">
                <tr>
                    <td colspan="2" style="font-size:25px; padding-top:1em; color:white; text-align:center; padding-left:7%; font-family: 'Showcard Gothic';  ">
                        --BORROWER INFORMATION--
                    </td>
                </tr>

                <tr>
                    <td>
                        Borrower ID : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtborrowerid" runat="server"  Width="230px" style="font-family:'Bookman Old Style'; "></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        Borrower Name : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtborrowername" runat="server"  Width="230px" style="font-family:'Bookman Old Style'; "></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        Course : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtcourse" runat="server"  Width="230px" style="font-family:'Bookman Old Style'; "></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        Section : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtsection" runat="server"  Width="230px" style="font-family:'Bookman Old Style'; "></asp:TextBox>
                    </td>
                </tr>

                 <tr>
                    <td>
                        No. of Books Allowed : 
                    </td>
                    <td>
                        <asp:TextBox ID="txtbooksallowed" runat="server"  Width="230px" style="font-family:'Bookman Old Style'; "></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <center>
                    <td colspan="4" style ="text-align: center">
                        <asp:Button ID="btnReload" runat="server" Text="Reload" OnClick="btnReload_Click"  Style="font-family: Century Gothic" />
                    </td>
                    </center>
                </tr>

                  <tr >
                    <td colspan="4" style="text-align:center; padding-left:2.5em;">
                        <asp:Button ID="btnFirst" runat="server" Text="<< First" Style="width: 75px; height: 30px; border-radius: 5px; border-color: white; color: black; font-family: 'Copperplate Gothic'; font-size: 15px; font-weight: 500;" OnClick="btnFirst_Click" />

                        <asp:Button ID="btnPrevious" runat="server" Text="< Prev" Style="width: 75px; height: 30px; border-radius: 5px; border-color: white; color: black; font-family: 'Copperplate Gothic'; font-size: 15px; font-weight: 500;" OnClick="btnPrevious_Click" />

                        <asp:Button ID="btnNext" runat="server" Text="Next >" Style="width: 75px; height: 30px; border-radius: 5px; border-color: white; color: black; font-family: 'Copperplate Gothic'; font-size: 15px; font-weight: 500;" OnClick="btnNext_Click" />

                        <asp:Button ID="btnLast" runat="server" Text="Last >> " Style="width: 75px; height: 30px; border-radius: 5px; border-color: white; color: black; font-family: 'Copperplate Gothic'; font-size: 15px; font-weight: 500;" OnClick="btnLast_Click" />

                    </td>
                </tr>

                

                <tr>

                    <td colspan="3" style="padding-top:2%; padding-right:7%;  ">
                        <asp:Label ID="lblentborroweridno" runat="server" Text="Enter Borrower ID:" style="font-size:18px;" ></asp:Label>
                        <asp:TextBox ID="txtentborroweridno" runat="server" Width="150px"></asp:TextBox>
                        <asp:Button ID="btnSearchID" runat="server" Text="Search" Style="height: 25px; width: 85px; border-color: white; color: black; font-family: 'Copperplate Gothic'; font-size: 13px;"  OnClick="btnSearchID_Click"/>              
                    </td>
                </tr>

                <tr >
                    <td colspan="4" style="text-align:center; padding-top:1px; padding-left:2em;  ">
                        <asp:Button ID="btnAdd" runat="server" Text="Add" Style="height: 35px; width: 85px; border-color: white; color: black; font-family: 'Copperplate Gothic'; font-size: 15px; font-weight: 500; " OnClick="btnAdd_Click" />

                        <asp:Button ID="btnEdit" runat="server" Text="Edit" Style="height: 35px; width: 85px; border-color: white; color: black;;
                                                                            font-family: 'Copperplate Gothic'; font-size: 15px; font-weight:500; "   OnClick="btnEdit_Click"/>

                        <asp:Button ID="btnSave" runat="server" Text="Save" Style="height: 35px; width: 85px; border-color: white; color: black; font-family: 'Copperplate Gothic'; font-size: 15px; font-weight: 500;" OnClick="btnSave_Click" />
                        
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Style="height: 35px; width: 85px; border-color: white; color: black; font-family: 'Copperplate Gothic'; font-size: 15px; font-weight: 500;" OnClick="btnCancel_Click" />

                        <asp:Button ID="btnDelete" runat="server" Text="Delete" Style="height: 35px; width: 85px; border-color: white; color: black; font-family: 'Copperplate Gothic'; font-size: 15px; font-weight: 500;" OnClick="btnDelete_Click" />
                    </td>
                </tr>

                <tr>
                    <td colspan="6" style="text-align:center; padding-left: 2em; padding-top:2em; " >
                        <asp:Button ID="btnBack2" runat="server" Text="<<   landing page" Style="height: 25px; width: 200px; border-color: white; color: white; background-color: black; font-family: 'Copperplate Gothic'; font-size: 15px; font-weight: 500;" OnClick="btnBack2_Click" />
                        <asp:Button ID="btnborrower" runat="server" Text="<   add book   >" Style="height: 25px; width: 200px; border-color: white; color: white; background-color: black; font-family: 'Copperplate Gothic'; font-size: 15px; font-weight: 500;" OnClick="btnborrower_Click" />                        
                        <asp:Button ID="btMultipleSearch1" runat="server" Text=" add transaction   >>" Style="height: 25px; width: 200px; border-color: white; color: white; background-color: black; font-family: 'Copperplate Gothic'; font-size: 15px; font-weight: 500;" OnClick="btMultipleSearch1_Click" />
                        
                    </td>

                </tr>

                
            </table>
        </div>
        </center>
    </form>
</body>
</html>
