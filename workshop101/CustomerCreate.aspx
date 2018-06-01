<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerCreate.aspx.cs" Inherits="workshop101.CustomerCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">Customer form</div>
                    <div class="panel-body">
                        <div class="form-group">
                            <asp:Label text="รหัสลูกค้า" Font-Bold="true" runat="server"></asp:Label>
                            <asp:TextBox runat="server" id="txtId" placeholder="รหัสลูกค้า" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label Text="ชื่อลูกค้า" Font-Bold="true" runat="server"></asp:Label>
                            <asp:TextBox runat="server" ID="txtName" placeholder="ชื่อลูกค้า" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label Text="ชื่อติดต่อ" Font-Bold="true" runat="server"></asp:Label>
                            <asp:TextBox runat="server" ID="txtContact" placeholder="ชื่อติดต่อ" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">Address</div>
                    <div class="panel-body">
                        <div class="form-group">
                            <asp:Label Text="ที่อยู่" Font-Bold="true" runat="server"></asp:Label>
                            <asp:TextBox runat="server" ID="txtAddress" placeholder="ที่อยู่" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label Text="เมือง" Font-Bold="true" runat="server"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCity" placeholder="เมือง" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label Text="รหัสไปรษณีย์" Font-Bold="true" runat="server"></asp:Label>
                            <asp:TextBox runat="server" ID="txtPostalCode" placeholder="รหัสไปรษณีย์" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:Label Text="ประเทศ" Font-Bold="true" runat="server"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCountry" placeholder="ประเทศ" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <asp:Label Text="Test Drop down list" Font-Bold="true" runat="server"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddl" CssClass="form-control">
                                <asp:ListItem Text="test1"></asp:ListItem>
                                <asp:ListItem Text="test2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:Label Text="Test date&time" Font-Bold="true" runat="server"></asp:Label>
                            <div class='input-group date' id="dtDate">
                                <input type="text" class="form-control" id="txtDate" runat="server" style="background-color:unset;" readonly />
                                <span class="input-group-addon">
                                    <span class="glyphicon glyphicon-calendar"></span>
                                </span>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label Text="Test picture upload" Font-Bold="true" runat="server"></asp:Label>
                            <asp:FileUpload ID="fuCoverImg" CssClass="form-control" runat="server" AllowMultiple="false" />
                        </div>
                        <asp:Button 
                            id="btnSubmitDelete" 
                            Text="Confirm" 
                            class="btn btn-primary" 
                            OnClick="btnSubmitDelete_Click" 
                            OnClientClick="return submitClick();" 
                            runat="server"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $('#dtDate').datetimepicker({
                format: 'YYYY/MM/DD',
                ignoreReadonly: true,
                defaultDate: new Date()
            });
        });
        $(function submitClick() {
            if (!$('#MainContent_txtId').val()) {
                showAlertError("กรุณาระบุรหัสลูกค้า");
                return false;
            }
            if (!$('#MainContent_txtName').val()) {
                showAlertError("กรุณากรอกชือ");
                return false;
            }
            if (!$('#MainContent_txtContact').val()) {
                showAlertError("กรุณาใส่ชื่อผู้ติดต่อ");
                return false;
            }
            if (!$('#MainContent_txtAddress').val()) {
                showAlertError("กรุณาใส่ที่อยู่");
                return false;
            }
            if (!$('#MainContent_txtCity').val()) {
                showAlertError("กรุณาใส่เมือง");
                return false;
            }
            if (!$('#MainContent_txtPostalCode').val()) {
                showAlertError("กรุณาใส่รหัสไปรษณีย์");
                return false;
            }
            if (!$('#MainContent_txtCountry').val()) {
                showAlertError("กรุณาใส่ประเทศ");
                return false;
            }
        });
    </script>
</asp:Content>
