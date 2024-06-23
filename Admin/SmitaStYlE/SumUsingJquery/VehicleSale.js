
        function pageLoad() {
            $(function () {

                var txtrate = $('input:text[id$=txt_rate]').keyup(foo);
                var txtquantity = $('input:text[id$=txt_Quantity]').keyup(foo);

                var txt_discount = $('input:text[id$=txt_DiscountAmount]').keyup(fog);
                var txt_GrossAmount = $('input:text[id$=txt_GrossAmount]').keyup(foo);

                var txt_amount = $('input:text[id$=txt_billamount]').keyup(foo);
                var txtvat = $('input:text[id$=txtvat]').keyup(foo);

                var txt_billamount = $('input:text[id$=txt_billamount]').keyup(foo);
                var txt_vatamount = $('input:text[id$=txt_vatamount]').keyup(foo);

                var txt_other = $('input:text[id$=txt_other]').keyup(foo);

                function foo() {
                    var includingvat = Multiplication(txtquantity.val(), txtrate.val());
                    $('input:text[id$=txt_amount]').val(includingvat);

                    var x = Multiplication(txtrate.val(), 100);
                    var y = Sum(txtvat.val(), 100);

                    //using math.round
                   var amount =Math.round( Divison(x, y)+'e2')+'e-2';
                $('input:text[id$=txt_GrossAmount]').val(amount);


                var VatAmmt =round(sub(txtrate.val(),amount),2);
                    $('input:text[id$=txt_vatamount]').val(VatAmmt);

                    var billamount =round(Sum(txtrate.val(), txt_other.val()),2);
                    $('input:text[id$=txt_billamount]').val(billamount);

                    var Gamount = Sum(amount, txt_discount.val());
                    $('input:text[id$=txt_GrossAmount]').val(Gamount);


                }
                function fog() {

                    var afterdisc = sub(txtrate.val(), txt_discount.val());

                    var includingvat = Multiplication(txtquantity.val(), txtrate.val());
                    $('input:text[id$=txt_amount]').val(includingvat);

                    var x = Multiplication(afterdisc, 100);
                    var y = Sum(txtvat.val(), 100);

                    //using math.round
                    var amount = Math.round(Divison(x, y) + 'e2') + 'e-2';
                    $('input:text[id$=txt_GrossAmount]').val(amount);


                    var VatAmmt = round(sub(afterdisc, amount), 2);
                    $('input:text[id$=txt_vatamount]').val(VatAmmt);

                    var billamount = round(Sum(afterdisc, txt_other.val()), 2);
                    $('input:text[id$=txt_billamount]').val(billamount);

                    var Gamount = Sum(amount, txt_discount.val());
                    $('input:text[id$=txt_GrossAmount]').val(Gamount);


                }
                //using round function

                function round(value, decimals) {
                    return Number(Math.round(value + 'e' + decimals) + 'e-' + decimals);
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


                
                function Multiplication() {

                    var into = 0;

                    into = (parseFloat(arguments[0]) * parseFloat(arguments[1]));

                    return into;


                }
                function Sum() {

                    var into = 0;

                    into = (parseFloat(arguments[0]) + parseFloat(arguments[1]));

                    return into;


                }
                function vat() {

                    var percent = 0;

                    percent = (parseFloat(arguments[0]) * parseFloat(arguments[1])) / 100;

                    return percent;


                }

                function Divison() {

                    var div = 0;

                    div = (parseFloat(arguments[0]) / parseFloat(arguments[1]));

                    return div;


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
  