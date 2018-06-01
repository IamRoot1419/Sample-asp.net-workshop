<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="workshop101.CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .scrollbar101{
            width: auto; 
            height: 800px; 
            overflow-y: scroll; 
            scrollbar-arrow-color:blue; 
            scrollbar-face-color: #e7e7e7; 
            scrollbar-3dlight-color: #a0a0a0; 
            scrollbar-darkshadow-color:#888888
        }
    </style>
    <div id="popup" class="scrollbar101">
        <div class="container">
            <div class="row">
                <div class="col" style="padding-top:10px">
                    <asp:GridView ID="gvCustTable" Width="100%" BorderWidth="0" GridLines="None" runat="server" 
                        AutoGenerateColumns="false" CssClass="table table-condensed">
                        <Columns>
                            <asp:BoundField DataField="CustomerID" HeaderText="รหัสลูกค้า" />
                            <asp:TemplateField HeaderText="image">
                                <ItemTemplate>
                                    <asp:Image ID="img" Height="80px" ImageUrl='<%#Eval("coverImg") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="CustomerName" HeaderText="ชื่อลูกค้า" />
                            <asp:BoundField DataField="ContactName" HeaderText="ชื่อติดต่อ" />
                            <asp:BoundField DataField="Address" HeaderText="ที่อยู่" />
                            <asp:BoundField DataField="City" HeaderText="เมือง" />
                            <asp:BoundField DataField="PostalCode" HeaderText="รหัสไปรษณีย์" />
                            <asp:BoundField DataField="Country" HeaderText="ประเทศ" />
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:Button 
                                        CssClass="btn btn-primary"
                                        OnClick="btnEdit_Click"
                                        text="Edit"
                                        id="btnEdit"
                                        runat="server"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:Button
                                            CssClass="btn btn-danger"
                                            OnClientClick="return confirm('คุณต้องการลบข้อมูลรายการนี้ใช่หรือไม่ ?');"
                                            OnClick="btnDel_Click"
                                            Text="Delete"
                                            ID="btnDelete"
                                            runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                    
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
