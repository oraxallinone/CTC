
        function pageLoad() {
            $(function () {

                var txtrate = $('input:text[id$=txt_rate]').keyup(foo1);
                var txtquantity = $('input:text[id$=txt_quantity]').keyup(foo1);

                var txt_discount = $('input:text[id$=txt_discount]').keyup(foo);
                var txt_netquantity = $('input:text[id$=txt_netamount]').keyup(foo);
                var txt_amount = $('input:text[id$=txt_amount]').keyup(foo);
                var txt_discountamount = $('input:text[id$=txt_discountamount]').keyup(foo);

                function foo1() {
                    //multiplication
                    var rate = txtrate.val();
                    var quantity = txtquantity.val();

                    var into = Multiplication(rate, quantity);

                    $('input:text[id$=txt_amount]').val(into);
                    $('input:text[id$=txt_netamount]').val(into);
                }
                function foo() {



                    //discount amount
                    var discountamount = txt_discountamount.val();
                    var amount = txt_amount.val();
                    var discount = txt_discount.val();
                    var percent = vat(amount, discount);
                    $('input:text[id$=txt_discountamount]').val(percent);

                    var minus = sub(amount, percent);
                    $('input:text[id$=txt_netamount]').val(minus);

                    //totalamount




                    function add() {

                        var sum = 0;

                        for (var i = 0, j = arguments.length; i < j; i++) {

                            if (IsNumeric(arguments[i])) {

                                sum += parseFloat(arguments[i]);

                            }

                        }

                        return sum;
                    }
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
  