<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transaction.aspx.cs" Inherits="BookBorrowing.transaction" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        *{
            font-family: Tahoma;
        }
        h1{
            color: white;
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
            border: solid 3px white;
            background-color: black;
            border-radius: 30px;
        }
        .lbl{
            font-weight: bold;
            color: white;
        }
        .result{
            color: black;
        }
        .btn{
            border: solid 2px white;
            background-color: black;
            color: white;
            font-weight: bold;
            border-radius: 5px;
            height: 30px;
            margin-left: 8px; margin-right: 8px;
            padding: 5px;
        }
        .ddl{
            height: 40px;
            color: white;
            background-color: black;
            border: solid 2px white;
        }
        .btn:hover{
            background-color: white;
            color: black;
        }
        .auto-style1 {
            width: 127px;
        }
        .auto-style2 {
            width: 138px;
        }
        .auto-style3 {
            width: 537px;
        }
        .auto-style6 {
            width: 115px;
        }
        .auto-style7 {
            width: 100px;
        }
        #MultiView1{
            margin-left: 10px;
            padding: 20px;
        }
        body{
            background: url(img/bkb2.jpg);
            background-color: black;
            background-size:cover;
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh; /* Adjust the height as needed */
        }
        .auto-style8 {
            height: 130px;
        }
        
        .auto-style9 {
            width: 233px;
            height: 45px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <center class="FormDiv">
        <div id="FormBorder" runat="server" class="auto-style3">
            <h1>ADD TRANSACTION</h1>
            <table >
                <tr>
                    <td class="auto-style2">
                        <asp:Label class="lbl" ID="lbltransactionid" runat="server" Text="Transaction ID"></asp:Label>
                    </td>
                    <td colspan="3" class="auto-style1">
                        <asp:TextBox class="txt" ID="txttransactionid" runat="server" Width="165px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <br/>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label class="lbl" ID="lblborrowerid" runat="server" Text="Borrower ID"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox class="txt" ID="txtborrowerid" runat="server" Width="100px"></asp:TextBox >
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label class="lbl" ID="lblborrowername" runat="server" Text="Borrower Name"></asp:Label>
                    </td>
                    <td colspan="3" class="auto-style1">
                        <asp:TextBox class="txt" ID="txtborrowername" runat="server" Width="307px" OnTextChanged="txtborrowername_TextChanged"></asp:TextBox >
                    </td>
                </tr>
                 <tr>
                    <td class="auto-style2">
                        <asp:Label class="lbl" ID="lblbooksallowed" runat="server" Text="No. Allowed"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox class="txt" ID="txtbooksallowed" runat="server" Width="100px"></asp:TextBox >
                    </td>
                    <td class="auto-style6">
                        <asp:Label class="lbl" ID="lblbooksborrowed" runat="server" Text="No. Borrowed" ></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox class="txt" ID="txtbooksborrowed" runat="server" Width="79px"></asp:TextBox >
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <br/>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label class="lbl" ID="lblbookid" runat="server" Text="Book ID"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox class="txt" ID="txtbookid" runat="server" Width="100px"></asp:TextBox >
                    </td>
                    <td class="auto-style6">
                        <asp:Button class="btn" ID="btnFind" runat="server"  Text="FIND" OnClick="btnFind_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label class="lbl" ID="lblbooktitle" runat="server" Text="Book Title"></asp:Label>
                    </td>
                    <td colspan="3" class="auto-style1">
                        <asp:TextBox class="txt" ID="txtbooktitle" runat="server" Width="305px"></asp:TextBox >
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label class="lbl" ID="lblbstatus" runat="server" Text="Status"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox class="txt" ID="txtstatus" runat="server" Width="100px"></asp:TextBox >
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <br/>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label class="lbl" ID="lbltransactioncategory" runat="server" Text="Category"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:Button class="btn" ID="btnBorrow" runat="server" Text="BORROW" OnClick="btnBorrow_Click" />
                        <asp:Button class="btn" ID="btnReturn" runat="server" Text="RETURN" OnClick="btnReturn_Click" />
                        <asp:TextBox class="txt" ID="txttransactioncatid" runat="server" Width="100px"></asp:TextBox >
                    </td>
                </tr>
            </table>
            <br/>
            <center>
                <table>
                    <tr>
                        <td>
                            <asp:Label class="lbl" ID="lbltransactiondate" runat="server" Text="Borrow Date:"></asp:Label>
                        
                        </td>
                        <td>
                            <asp:TextBox class="txt" ID="txttransactiondate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <asp:Label class="lbl" ID="lblreturndate" runat="server" Text="Return Date:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox class="txt" ID="txtreturndate" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </center>
            <center>
                <table class="auto-style8">
                    <tr>
                        <td colspan="3" height="50px">
                            <asp:Button class="btn" ID="btnSave" runat="server" Text="Save Transaction" OnClick="btnSave_Click"  />
                            <asp:Button class="btn" ID="btnAnother" runat="server" Text="Another Transaction" OnClick="btnAnother_Click" />
                            <asp:Button class="btn" ID="btnDisplay" runat="server" Text="View Booklist" OnClick="btnDisplay_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" height="50px">
                            <center>
                            <asp:Button class="btn" ID="btnBack" runat="server" Text="Choose Patron" OnClick="btnBack_Click" />
                            </center>
                        </td>
                    </tr>
                </table>
            </center>
        </div>
        </center>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <div id="div2" runat="server" align="center">
                    <br />
                    <center>
                    <table>
                        <tr>
                            <td class="auto-style9">
                                <asp:DropDownList class="ddl" ID="ddlfilter" runat="server" Height="16px" Width="136px"></asp:DropDownList>
                                <asp:Button class="btn" ID="btnfilter" runat="server" Text="Filter" OnClick="btnfilter_Click" />
                            </td>
                        </tr>

                    </table>
                </center>
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
                            <asp:TemplateField HeaderText="Book Category" SortExpression="BookCat">
                                <ItemTemplate>
                                    <asp:Label class="result" ID="lblbkcat" runat="server" Text='<%# Bind("bookcategory") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Height="25px" Width="80px" HorizontalAlign="Center" Font-Size="Smaller"/>
                            </asp:TemplateField>
                             <%--Column 3--%>
                            <asp:TemplateField HeaderText="Category Detail" SortExpression="CatDetail">
                                <ItemTemplate>
                                    <asp:Label class="result" ID="lblcatdetail" runat="server" Text='<%# Bind("bookcatdetail") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Height="25px" Width="80px" HorizontalAlign="Center" Font-Size="Smaller"/>
                            </asp:TemplateField>
                             <%--Column 4--%>
                            <asp:TemplateField HeaderText="Book ID" SortExpression="FirstName">
                                <ItemTemplate>
                                    <asp:Label class="result" ID="lblbkid" runat="server" Text='<%# Bind("bookid") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Height="25px" Width="80px" HorizontalAlign="Center" Font-Size="Smaller"/>
                            </asp:TemplateField>
                             <%--Column 5--%>
                            <asp:TemplateField HeaderText="Boook Title" SortExpression="FirstName">
                                <ItemTemplate>
                                    <asp:Label class="result" ID="lblempid" runat="server" Text='<%# Bind("booktitle") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Height="25px" Width="80px" HorizontalAlign="Center" Font-Size="Smaller"/>
                            </asp:TemplateField>
                            <%--Column 6--%>
                            <asp:TemplateField HeaderText="Copy No" SortExpression="Status">
                                <ItemTemplate>
                                    <asp:Label class="result" ID="lblempid" runat="server" Text='<%# Bind("copynum") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Height="25px" Width="80px" HorizontalAlign="Center" Font-Size="Smaller"/>
                            </asp:TemplateField>
                            <%--Column 7--%>
                            <asp:TemplateField HeaderText="Status" SortExpression="DepartmentName">
                                <ItemTemplate>
                                    <asp:Label class="result" ID="lblempid" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Height="25px" Width="80px" HorizontalAlign="Center" Font-Size="Smaller"/>
                            </asp:TemplateField>
                            <%--Column 8--%>
                            <asp:TemplateField HeaderText="No. of Days Allowed" SortExpression="MonthlySalary">
                                <ItemTemplate>
                                    <asp:Label class="result" ID="lblempid" runat="server" Text='<%# Bind("numberofdaysallowed") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Height="25px" Width="80px" HorizontalAlign="Center" Font-Size="Smaller"/>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <br />
                    <asp:Button class="btn" ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" />
                </div>
                <br />
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
