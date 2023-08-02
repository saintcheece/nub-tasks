<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="book.aspx.cs" Inherits="BookBorrowing.Book" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        *{
            font-family: Tahoma;
        }
        body{
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
        }
        form{
            display: flex;
            justify-content: center;
            align-items: center;
        }
        .FormDiv{
            margin-right: 10px;
            padding: 20px;
        }
        #FormBorder{
            border: solid 3px black;
            background-color: white;
            border-radius: 30px;
            width: 573px;
        }
        .lbl{
            font-weight: bold;
        }
        .rbtnl{
            display: inline;
        }
        #MultiView1{
            margin-left: 10px;
            padding: 20px;
        }
        .auto-style1 {
            width: 92px;
        }
        .auto-style2 {
            width: 108px;
        }
        .auto-style3 {
            width: 185px;
        }
        .auto-style5 {
            width: 97px;
        }
        .auto-style6 {
            height: 85px;
        }
        .auto-style7 {
            height: 50px;
        }
        .auto-style8 {
            width: 30px;
        }
        .auto-style9 {
            width: 110px;
        }
    </style>
</head>
<body style="background: url(img/bkb2.jpg);
            background-size:cover;">
    <form id="form1" runat="server">
        <center class="FormDiv">
        <div id="FormBorder" class="auto-style4">
            <h1>BOOK INFORMATION</h1>
            <table>
                <tr>
                    <td class="auto-style2">
                        <asp:Label class="lbl" ID="lblbookid" runat="server" Text="Book ID"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtbookid" runat="server" Width="80px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label class="lbl" ID="btnbooktitle" runat="server" Text="Book Title"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtbooktitle" runat="server" Width="290px" ></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">
                        <asp:Label class="lbl" ID="lblbookcategory" runat="server" Text="Book Category"></asp:Label>
                    </td >
                    <td class="auto-style8">
                        <asp:DropDownList ID="ddlbookcategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlbookcategory_SelectedIndexChanged" Width="88px"></asp:DropDownList>

                    </td>
                    <td colspan="2" class="auto-style5">
                        <asp:TextBox ID="txtbookcatdetail" runat="server" Width="198px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label class="lbl" ID="lblstatus" runat="server" Text="Status" ></asp:Label>
                    </td>
                    <td colspan="2" class="auto-style1">
                        <asp:RadioButtonList class="rbtnl" ID="rblstatus" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"></asp:RadioButtonList>
                    </td>
                </tr>

                <tr>
                    <td class="auto-style2">
                        <asp:Label class="lbl" ID="lblcopynum" runat="server" Text="Copy No."></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:TextBox ID="txtcopynum" runat="server" Width="80px"></asp:TextBox>
                    </td>
                    <td class="auto-style9">
                        <asp:Label class="lbl" ID="lbldaysallowed" runat="server" Text="Days Allowed"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="txtdaysallowed" runat="server" Width="84px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <br/>
            <table>
                 <tr >
                    <td colspan="4">
                        <asp:Button ID="btnFirst" runat="server" Text="<<" OnClick="btnFirst_Click" />

                        <asp:Button ID="btnPrevious" runat="server" Text="<" OnClick="btnPrevious_Click" />

                        <asp:Button ID="btnNext" runat="server" Text=">" OnClick="btnNext_Click" />

                        <asp:Button ID="btnLast" runat="server" Text=">>" OnClick="btnLast_Click" />

                    </td>
                </tr>
            </table>

            <table>
                 <tr>

                    <td colspan="3" style="padding-top:2%; padding-right:7%;  " class="auto-style3">
                        <asp:Label class="lbl" ID="lblentbookidno" runat="server" Text="Enter Borrower ID:" style="font-size:18px;" ></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtentbookidno" runat="server" Width="150px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnSearchID" runat="server" Text="Search" OnClick="btnSearchID_Click"/>              

                    </td>
                </tr>
            </table>
            <center>
                <asp:Button ID="btnReload" runat="server" Text="Reload" OnClick="btnReload_Click" />
            </center>
            <table class="auto-style7">
                <tr>
                    <td colspan="4">
                        <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />

                        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />

                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />

                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />

                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                    </td>
                </tr>
            </table>
            <asp:Button ID="btnMultipleSearch" runat="server" Text="View Booklist" OnClick="btnMultipleSearch_Click" />
            <table class="auto-style6">
                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnBack2" runat="server" Text="Landing Page" OnClick="btnBack2_Click" />
                        <asp:Button ID="btnborrower" runat="server" Text="Add Borrower" OnClick="btnborrower_Click" />                        
                        <asp:Button ID="btnaddtransaction" runat="server" Text="Add Transaction" OnClick="btnAddTransaction_Click" />
                    </td>
                </tr>
            </table>
        </div>
        </center>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <div id="div2" runat="server" align="center">
                    <br />
                    <asp:GridView ID="gvShowData" runat="server" BorderStyle="Solid" BorderWidth="1px" AutoGenerateColumns="False" Backcolor="White" BorderColor="#999999" GridLines="Vertical" Cellpadding="3" CellSpacing="5" >
                        <AlternatingRowStyle BackColor="#e5e5e5" />
                        <HeaderStyle BackColor="DarkGray" Font-Bold="True" Font-Size="Small" Font-Names="Tahoma" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="white" ForeColor="Black" HorizontalAlign="Left" Font-Size="Smaller" Font-Names="Tahoma" Height="25px" Width="200px"/>
                        <Columns>
                           <%--Column 1--%>
                            <asp:TemplateField HeaderText="SNo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle Height="25px" Width="40px" HorizontalAlign="Center" Font-Size="Smaller"/>
                            </asp:TemplateField>
                            <%--Column 2--%>
                            <asp:TemplateField HeaderText="ID" SortExpression="BookCat">
                                <ItemTemplate>
                                    <asp:Label class="lbl" ID="lblbkcat" runat="server" Text='<%# Bind("bookid") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Height="25px" Width="80px" HorizontalAlign="Center" Font-Size="Smaller"/>
                            </asp:TemplateField>
                             <%--Column 3--%>
                            <asp:TemplateField HeaderText="Title" SortExpression="CatDetail">
                                <ItemTemplate>
                                    <asp:Label class="lbl"  ID="lblcatdetail" runat="server" Text='<%# Bind("booktitle") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Height="25px" Width="160px" HorizontalAlign="Center" Font-Size="Smaller"/>
                            </asp:TemplateField>
                             <%--Column 4--%>
                            <asp:TemplateField HeaderText="Category" SortExpression="FirstName">
                                <ItemTemplate>
                                    <asp:Label class="lbl"  ID="lblbkid" runat="server" Text='<%# Bind("bookcatdetail") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Height="25px" Width="80px" HorizontalAlign="Center" Font-Size="Smaller"/>
                            </asp:TemplateField>
                             <%--Column 5--%>
                            <asp:TemplateField HeaderText="Copy No." SortExpression="FirstName">
                                <ItemTemplate>
                                    <asp:Label class="lbl"  ID="lblempid" runat="server" Text='<%# Bind("copynum") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Height="25px" Width="40px" HorizontalAlign="Center" Font-Size="Smaller"/>
                            </asp:TemplateField>
                            <%--Column 6--%>
                            <asp:TemplateField HeaderText="Days Allowed" SortExpression="Status">
                                <ItemTemplate>
                                    <asp:Label class="lbl"  ID="lblempid" runat="server" Text='<%# Bind("numberofdaysallowed") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Height="25px" Width="40px" HorizontalAlign="Center" Font-Size="Smaller"/>
                            </asp:TemplateField>
                            <%--Column 7--%>
                            <asp:TemplateField HeaderText="Status" SortExpression="DepartmentName">
                                <ItemTemplate>
                                    <asp:Label class="lbl"  ID="lblempid" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Height="25px" Width="50px" HorizontalAlign="Center" Font-Size="Smaller"/>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" />
                </div>
                <br />
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
