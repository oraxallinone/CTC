
        function pageLoad() {
            $(function () {

                var txtrate = $('input:text[id$=txt_rate]').keyup(foo1);
                var txtquantity = $('input:text[id$=txt_quantity]').keyup(foo1);

                var txt_AGrossAmount = $('input:text[id$=txt_AGrossAmount]').keyup(foo);
                var txtvat = $('input:text[id$=txtvat]').keyup(foo);

                var txtcst = $('input:text[id$=txtcst]').keyup(foo);

                var txt_vatamount = $('input:text[id$=txt_vatamount]').keyup(foo);
                var txt_cstamount = $('input:text[id$=txt_cstamount]').keyup(foo);
                var txt_other = $('input:text[id$=txt_other]').keyup(foo);

                var txt_ADiscountAmount = $('input:text[id$=txt_ADiscountAmount]').keyup(foo);
                var txt_billamount = $('input:text[id$=txt_billamount]').keyup(foo);

                function foo1() {
                    //multiplication
                    var rate = txtrate.val();
                    var quantity = txtquantity.val();

                    var into = Multiplication(rate, quantity);

                    $('input:text[id$=txt_amount]').val(into);
                }
                function foo() {
                    //vat amount
                    var gross = txt_AGrossAmount.val();
                    var discountamount = txt_ADiscountAmount.val();
                    var minus = sub(gross, discountamount);
                    $('input:text[id$=txt_billamount]').val(minus);

                    var vatamount = txtvat.val();
                    var cstamount = txtcst.val();
                    var billamount = txt_billamount.val();
                    var percent = vat(billamount, vatamount);

                    $('input:text[id$=txt_vatamount]').val(percent);

                    //cst amount
                    var percent = cst(billamount, cstamount);

                    $('input:text[id$=txt_cstamount]').val(percent);


                    //discount amount


                    var tvatamount = txt_vatamount.val();
                    var tcstamount = txt_cstamount.val();
                    var other = txt_other.val();
                    var sum = add(billamount, tvatamount, tcstamount, other);

                    $('input:text[id$=txt_billamount]').val(sum);


                }


                function Multiplication() {

                    var into = 0;

                    into = (parseFloat(arguments[0]) * parseFloat(arguments[1]));

                    return into;


                }

                function vat() {

                    var percent = 0;

                    percent = (parseFloat(arguments[0]) * parseFloat(arguments[1])) / 100;

                    return percent;


                }

                function cst() {

                    var percent = 0;

                    percent = (parseFloat(arguments[0]) * parseFloat(arguments[1])) / 100;

                    return percent;


                }


                function add() {

                    var sum = 0;

                    for (var i = 0, j = arguments.length; i < j; i++) {

                        if (IsNumeric(arguments[i])) {

                            sum += parseFloat(arguments[i]);

                        }

                    }

                    return sum;
                }
                function sub() {

                    var minus = 0;

                    minus = (parseFloat(arguments[0]) - parseFloat(arguments[1]));

                    return minus;


                }

                function IsNumeric(input) {

                    return (input - 0) == input && input.length > 0;

                }
            });
        }
  