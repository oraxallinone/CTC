<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerList.aspx.cs" Inherits="Admin_CustomerList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        table {
            border: 1px solid #ccc;
        }

            table th {
                background-color: #F7F7F7;
                color: #333;
                font-weight: bold;
            }

            table th, table td {
                padding: 5px;
                border-color: #ccc;
            }

        .Pager span {
            color: #333;
            background-color: #F7F7F7;
            font-weight: bold;
            text-align: center;
            display: inline-block;
            width: 20px;
            margin-right: 3px;
            line-height: 150%;
            border: 1px solid #ccc;
        }

        .Pager a {
            text-align: center;
            display: inline-block;
            width: 20px;
            border: 1px solid #ccc;
            color: #fff;
            color: #333;
            margin-right: 3px;
            line-height: 150%;
            text-decoration: none;
        }

        .highlight {
            background-color: #FFFFAF;
        }
    </style>


    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        td {
            cursor: pointer;
        }

        .hover_row {
            background-color: #A1DCF2;
        }

        #left {
            float: left;
            width: 65%;
            overflow: hidden;
        }

        #right {
            overflow: hidden;
        }
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="../ASPSnippets_Pager.min.js" type="text/javascript"></script>
    
    <script type="text/javascript">

        $(function () {
            GetCustomers(1);
        });
        $("[id*=txtSearch]").live("keyup", function () {
            GetCustomers(parseInt(1));
        });

        function SearchTerm() {
            return jQuery.trim($("[id*=txtSearch]").val());
        };
        function GetCustomers(pageIndex) {
            $.ajax({
                type: "POST",
                url: "CustomerList.aspx/GetCustomers",
                data: '{searchTerm: "' + SearchTerm() + '", pageIndex: ' + pageIndex + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        }
        var row;
        function OnSuccess(response) {
            var xmlDoc = $.parseXML(response.d);
            var xml = $(xmlDoc);
            var customers = xml.find("AME_Master_Customer");
            if (row == null) {
                row = $("[id*=gvCustomers] tr:last-child").clone(true);
            }
            $("[id*=gvCustomers] tr").not($("[id*=gvCustomers] tr:first-child")).remove();
            if (customers.length > 0) {
                $.each(customers, function () {
                    var customer = $(this);
                    $("td", row).eq(0).html($(this).find("Mc_Id").text());
                    $("td", row).eq(1).html($(this).find("Mc_Name").text());
                    $("td", row).eq(2).html($(this).find("Mc_City").text());
                    $("td", row).eq(3).html($(this).find("Mc_code").text());

                    $("[id*=gvCustomers]").append(row);
                    row = $("[id*=gvCustomers] tr:last-child").clone(true);
                });
                var pager = xml.find("Pager");
                $(".Pager").ASPSnippets_Pager({
                    ActiveCssClass: "current",
                    PagerCssClass: "pager",
                    PageIndex: parseInt(pager.find("PageIndex").text()),
                    PageSize: parseInt(pager.find("PageSize").text()),
                    RecordCount: parseInt(pager.find("RecordCount").text())
                });

                $(".ContactName").each(function () {
                    var searchPattern = new RegExp('(' + SearchTerm() + ')', 'ig');
                    $(this).html($(this).text().replace(searchPattern, "<span class = 'highlight'>" + SearchTerm() + "</span>"));
                });
            } else {
                var empty_row = row.clone(true);
                $("td:first-child", empty_row).attr("colspan", $("td", row).length);
                $("td:first-child", empty_row).attr("align", "center");
                $("td:first-child", empty_row).html("No records found for the search criteria.");
                $("td", empty_row).not($("td:first-child", empty_row)).remove();
                $("[id*=gvCustomers]").append(empty_row);
            }
        };



        $(function () {
            GetCustomers(1);
            $("[id*=gvCustomers] tr").click(function () {
                //Selected Row.
                var selectedRow = $(this).closest('tr');
                //In eq(0) portion you need to mention the cell number.
                var customerId = $(selectedRow).find('td').eq(0).html();
                var contactName = $(selectedRow).find('td').eq(1).html();
                var city = $(selectedRow).find('td').eq(2).html();
                var code = $(selectedRow).find('td').eq(3).html();

                //$('[id*=txtCustomerId]').html(customerId);
                //$('[id*=txtContactName]').val(contactName);
                //$('[id*=txtCity]').val(city);
                //$('[id*=txtCode]').val(code);

                var sdate = '{cusId: "' + code + '" }'

                $.ajax({
                    type: "POST",
                    url: "CustomerList.aspx/getCutomerDetails",
                    data: sdate,
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        var value = data.d[0];
                        $('#<%= txt_scode.ClientID %>').val(value.Mc_code);
                        $('#<%= txt_sname.ClientID %>').val(value.Mc_Name);
                        $('#<%= txt_address.ClientID %>').val(value.Mc_Address);
                        $('#<%= txt_city.ClientID %>').val(value.Mc_City);
                        $('#<%= txt_pin.ClientID %>').val(value.Mc_Pinno);
                        $('#<%= txt_phno.ClientID %>').val(value.Mc_Mobileno);
                        $('#<%= txt_tinno.ClientID %>').val(value.Mc_Tin);
                    },
                    error: function (data) {
                        alert("fail");
                    }
                });
            });
        });
        $(".Pager .page").live("click", function () {
            GetCustomers(parseInt($(this).attr('page')));
        });

        $(document).ready(function () {
            $("#btnUpdate").click(function () {
                debugger;

                var txtcode = $("[id*=txt_scode]");
                var txtname = $("[id*=txt_sname]");
                var txtadress = $("[id*=txt_address]");
                var txtcity = $("[id*=txt_city]");
                var txtpin = $("[id*=txt_pin]");
                var txtphone = $("[id*=txt_phno]");
                var txttin = $("[id*=txt_tinno]");

                $.ajax({
                    type: "POST",
                    url: "CustomerList.aspx/UpdateCustomer",


                    data: '{code: "' + txtcode.val() + '", name: "' + txtname.val() + '", adress: "' + txtadress.val() + '", city: "' + txtcity.val() + '", pin: "' + txtpin.val() + '", mobile: "' + txtphone.val() + '", tin: "' + txttin.val() + '" }',


                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        debugger;

                        $('#txt_scode').val("");
                        $('#txt_sname').val("");
                        $('#txt_address').val('');
                        $('#txt_city').val("");
                        $('#txt_pin').val("");
                        $('#txt_phno').val("");
                        $('#txt_tinno').val("");


                        GetCustomers(parseInt(1));




                        alert("Update done");

                    },
                    error: function (data) {
                        alert("fail");
                    }
                });
                return false;

            });
        });
    </script>


</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="wrapper">
            <div id="left">
                Search By Name:
        <asp:TextBox ID="txtSearch" runat="server" Height="25px" Width="300px" />
                <hr />

                <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="False" Width="90%" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField HeaderStyle-Width="100px" DataField="Mc_Id" HeaderText="Customers ID"
                            ItemStyle-CssClass="ContactName">
                            <HeaderStyle Width="100px" Height="33px"></HeaderStyle>

<ItemStyle CssClass="ContactName"></ItemStyle>

                        </asp:BoundField>



                        <asp:BoundField HeaderStyle-Width="150px" DataField="Mc_Name" HeaderText="Customers Name">
                            <HeaderStyle Width="150px"></HeaderStyle>
                        </asp:BoundField>







                        <asp:BoundField HeaderStyle-Width="150px" DataField="Mc_City" HeaderText="Customers City">
                            <HeaderStyle Width="150px"></HeaderStyle>
                        </asp:BoundField>





                        <asp:BoundField HeaderStyle-Width="150px" DataField="Mc_code" HeaderText="Customers Code">
                            <HeaderStyle Width="150px"></HeaderStyle>
                        </asp:BoundField>







                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
                <br />
                <div class="Pager">
                </div>

                <script type="text/javascript">
                    $(function () {
                        $("[id*=gvCustomers] td").hover(function () {
                            $("td", $(this).closest("tr")).addClass("hover_row");
                        },
                        function () {
                            $("td", $(this).closest("tr")).removeClass("hover_row");
                        });
                    });
                </script>
            </div>
            <div id="right">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                   

                    <tr>
                        <td colspan="2">

                            <table width="100%">


                                <tr>

                                    <td align="right" width="15%">Party Code </td>
                                    <td align="left" width="1%">
                                        <strong>:</strong></td>
                                    <td align="left" colspan="5">
                                        <asp:TextBox ID="txt_scode" runat="server" Height="30px"
                                            Width="270px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>

                                    <td align="right" width="15%">&nbsp;Party Name</td>
                                    <td align="left" width="1%">
                                        <strong>:</strong></td>
                                    <td align="left" colspan="5">
                                        <asp:TextBox ID="txt_sname" runat="server"  Height="30px"
                                            Width="270px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>

                                    <td align="right" width="15%">&nbsp;</td>
                                    <td align="left" width="1%">&nbsp;</td>
                                    <td align="left" colspan="2" width="120px">
                                        <asp:Label ID="lblpresentadress" runat="server" Text="PRESENT ADDRESS"
                                            Font-Bold="True" Font-Size="15px"></asp:Label>
                                    </td>

                                </tr>
                                <tr>

                                    <td align="right" width="15%" valign="top">Address</td>
                                    <td align="left" width="1%">
                                        <strong>:</strong></td>
                                    <td align="left" colspan="3">
                                        <asp:TextBox ID="txt_address" runat="server"
                                            CssClass="SmalldottedTextBox" Width="270px" Rows="4" TextMode="MultiLine"></asp:TextBox>

                                    </td>

                                </tr>
                                <tr>

                                    <td align="right" valign="top" width="15%">City</td>
                                    <td align="left" width="1%">:</td>
                                    <td align="left" valign="top" colspan="3">
                                        <asp:TextBox ID="txt_city" runat="server"  Height="30px"
                                            Width="120px"></asp:TextBox>
                                        Pin<asp:TextBox ID="txt_pin" runat="server"  Height="30px"
                                            MaxLength="6" onkeypress="return AllowNumbersOnly(this,event)" Width="90px"></asp:TextBox>
                                    </td>

                                </tr>
                                <tr>

                                    <td align="right" width="15%">Phone No</td>
                                    <td align="left" width="1%">
                                        <strong>:</strong></td>
                                    <td align="left" colspan="5">
                                        <asp:TextBox ID="txt_phno" runat="server"  Height="30px" MaxLength="10"
                                            onkeypress="return AllowNumbersOnly(this,event)" Width="270px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>

                                    <td align="right" valign="top" width="15%"
                                        style="font-weight: bold; color: #000000">TIN/SRIN</td>
                                    <td align="left" width="1%">
                                        <strong>:</strong></td>
                                    <td align="left" width="10%">
                                        <asp:TextBox ID="txt_tinno" runat="server"  Height="30px"
                                            Width="120px"></asp:TextBox>
                                    </td>
                                    <td align="left" width="2%">&nbsp;</td>
                                    <td align="left" class="style1" colspan="2">&nbsp;</td>
                                    <td align="left">&nbsp;</td>
                                </tr>

                                <tr>
                                    <td align="center" width="20%" colspan="8">
                                        
                                        <button type="button" value="btnUpdate"   id="btnUpdate" style="height:30px" >UPDATE</button>

                                    </td>
                                </tr>
                            </table>


                        </td>
                    </tr>


                </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
