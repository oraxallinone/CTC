function ValidateEmail(x) {
    var EmailExp = /^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$/;
    if (x.value.match(EmailExp)) {
        return true;
    }

    else {
        alert("Invalid Mail ID");
        x.value = "";
        x.focus();
        return false;
    }
}

onchange = "ValidateEmail(this)"

///validationphno///
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}
onkeypress = "return isNumberKey(event)"


///Accept only Integer


<script type="text/javascript">
    function fnAllowNumeric() {
      if ((event.keyCode < 48 || event.keyCode > 57) && event.keyCode != 8) {
          event.keyCode = 0;
          alert("Accept only Integer..!");
          return false;
      }
    }
</script>

<body>
  <input id="txtChar" onkeypress="return fnAllowNumeric()" type="text" />
</body>


///Please Enter Number Only


<script type="text/javascript">
    function CheckNumericValue(e) {
       var key = e.which ? e.which : e.keyCode;
       //enter key  //backspace //tabkey      //escape key                  
       if ((key >= 48 && key <= 57) || key == 13 || key == 8 || key == 9 || key == 27) {
           return true;
       }
       else {
           alert("Please Enter Number Only");
           return false;
       }
    }
</script>

<body>
 <input id="txtChar" onkeypress="return CheckNumericValue(event)" type="text" />
</body>

///////////Decimal no validation

 function AllowNumbersOnly(input, kbEvent) {
            var keyCode, keyChar;
            keyCode = kbEvent.keyCode;
            if (window.event)
                keyCode = kbEvent.keyCode; 	// IE
            else
                keyCode = kbEvent.which; 	//firefox		         
            if (keyCode == null) return true;
            // get character
            keyChar = String.fromCharCode(keyCode);
            var charSet = ".0123456789";
            // check valid chars
            if (charSet.indexOf(keyChar) != -1) return true;
            // control keys
            if (keyCode == null || keyCode == 0 || keyCode == 8 || keyCode == 9 || keyCode == 13 || keyCode == 27) return true;
            return false;
        }

        onkeypress="return AllowNumbersOnly(this,event)"