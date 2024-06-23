<script type="text/javascript">
           function validatefield() {
               if (document.getElementById('<%=txtcname. ClientID%>').value == "") {
                   alert('Please Enter Your Name...!!!');
                   document.getElementById('<%=txtcname. ClientID %>').focus();
                   return false;
                 
               }
               if (document.getElementById('<%=txtdob. ClientID%>').value == "") {
                   alert('Please Enter Your Dob...!!!');
                   document.getElementById('<%=txtdob. ClientID %>').focus();
                   return false;

               }
               if (document.getElementById('<%=txtcfname. ClientID%>').value == "") {
                   alert('Please Enter Your FatherName...!!!');
                   document.getElementById('<%=txtcfname. ClientID %>').focus();
                   return false;

               }
               if (document.getElementById('<%=txtcmnm. ClientID%>').value == "") {
                   alert('Please Enter Your MotherName...!!!');
                   document.getElementById('<%=txtcmnm. ClientID %>').focus();
                   return false;

               }
               if (document.getElementById('<%=txtphnno. ClientID%>').value == "") {
                   alert('Please Enter Your MobileNo...!!!');
                   document.getElementById('<%=txtphnno. ClientID %>').focus();
                   return false;

               }
               if (document.getElementById('<%=txtadress. ClientID%>').value == "") {
                   alert('Please Enter Your Address...!!!');
                   document.getElementById('<%=txtadress. ClientID %>').focus();
                   return false;

               }
               if (document.getElementById('<%=txtpurofstaying. ClientID%>').value == "") {
                   alert('Please Enter Purposes Of Staying...!!!');
                   document.getElementById('<%=txtpurofstaying. ClientID %>').focus();
                   return false;

               }
               if (document.getElementById('<%=txtemail. ClientID%>').value == "") {
                   alert('Please Enter Your Mailid...!!!');
                   document.getElementById('<%=txtemail. ClientID %>').focus();
                   return false;

               }
               if (document.getElementById('<%=txtnoofdays. ClientID%>').value == "") {
                   alert('Please Enter no Of Days Staying...!!!');
                   document.getElementById('<%=txtnoofdays. ClientID %>').focus();
                   return false;

               }
              if (document.getElementById('<%=DropDownList1. ClientID%>').value == "--Select One--") {
                   alert('Please Enter Your Photo Id Type...!!!');
                  
                   return false;

               }
           }
       
       </script>