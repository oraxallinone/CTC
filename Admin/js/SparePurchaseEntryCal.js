function pageLoad() {
    $(function SB() {

        var txt_PartQuantity = $('input:text[id$=txt_PartQuantity]').keyup(SBfoo);
        var txt_PartRate = $('input:text[id$=txt_PartRate]').keyup(SBfoo);
        var txt_PartAmount = $('input:text[id$=txt_PartAmount]').keyup(SBfoo1);
        var txt_PartDiscount = $('input:text[id$=txt_PartDiscount]').keyup(SBfoo);
        var txt_PartVat = $('input:text[id$=txt_PartVat]').keyup(SBfoo);
        var txt_PartTaxAmount = $('input:text[id$=txt_PartTaxAmount]').keyup(SBfoo);
        var txt_PartTotal = $('input:text[id$=txt_PartTotal]').keyup(SBfoo);

        function SBfoo() {
            var value1 = txt_PartQuantity.val();
            var value2 = txt_PartRate.val();
            var PartAmount = SBAmount(value1, value2);
            $('input:text[id$=txt_PartTotal]').val(PartAmount);



//            var includingvat = Multiplication(txt_PartAmount.val(), txtrate.val());
//            $('input:text[id$=txt_amount]').val(includingvat);

            var x = SBAmount(txt_PartTotal.val(), 100);
            var y = addition(txt_PartVat.val(), 100);

            //using math.round
            var amount = round(SBRate(x, y), 2);
            $('input:text[id$=txt_PartAmount]').val(amount);


            var VatAmmt = round(sub(txt_PartTotal.val(), amount), 2);
            $('input:text[id$=txt_PartTaxAmount]').val(VatAmmt);

//            var billamount = round(Sum(txtrate.val(), txt_other.val()), 2);
//            $('input:text[id$=txt_billamount]').val(billamount);

           var Gamount = addition(amount, txt_PartDiscount.val());
            $('input:text[id$=txt_PartAmount]').val(Gamount);

//            var PartNetAmt = SB2Sub(PartAmount, txt_PartDiscount.val());

//            var PartTaxAmount = SBPerCal(PartNetAmt, txt_PartVat.val());
//            $('input:text[id$=txt_PartTaxAmount]').val(PartTaxAmount);

//            var PartTotal = SB2Add(PartNetAmt, PartTaxAmount);
            //            $('input:text[id$=txt_PartTotal]').val(PartTotal);

            //using round function

            function round(value, decimals) {
                return Number(Math.round(value + 'e' + decimals) + 'e-' + decimals);
            }

        }

        function SBfoo1() {
            var value1 = txt_PartQuantity.val();
            var PartAmount = txt_PartAmount.val();
            var PartRate = SBRate(value1, PartAmount);
            $('input:text[id$=txt_PartRate]').val(PartRate);

            var PartNetAmt = SB2Sub(PartAmount, txt_PartDiscount.val());

            var PartTaxAmount = SBPerCal(PartNetAmt, txt_PartVat.val());
            $('input:text[id$=txt_PartTaxAmount]').val(PartTaxAmount);

            var PartTotal = SB2Add(PartNetAmt, PartTaxAmount);
            $('input:text[id$=txt_PartTotal]').val(PartTotal);
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
        function addition() {
            var sum = 0;
            sum = parseFloat(arguments[0]) + parseFloat(arguments[1]);
            return sum;
        }
        function SBAmount() {
            var sum = 0;
            sum = parseFloat(arguments[0]) * parseFloat(arguments[1]);
            return sum;
        }
        function sub() {
            var sum = 0;
            sum = parseFloat(arguments[0]) - parseFloat(arguments[1]);
            return sum;
        }
        function SBRate() {
            var sum = 0;
            sum = parseFloat(arguments[0]) / parseFloat(arguments[1]);
            return sum;
        }
        function IsNumeric(input) {
            return (input - 0) == input && input.length > 0;
        }


        var txt_ATotal = $('input:text[id$=txt_ATotal]').keyup(SBfoo2);
        var txt_APackagingAmt = $('input:text[id$=txt_APackagingAmt]').keyup(SBfoo2);
        var txt_AOtherAmount = $('input:text[id$=txt_AOtherAmount]').keyup(SBfoo2);
        var txt_ABillAmount = $('input:text[id$=txt_ABillAmount]').keyup(SBfoo2);

        function SBfoo2() {
            var value1 = txt_ATotal.val();
            var value2 = txt_APackagingAmt.val();
            var value3 = txt_AOtherAmount.val();
            var BillAmount = add(value1, value2, value3);
            $('input:text[id$=txt_ABillAmount]').val(BillAmount);
        }
        function SB2Sub() {
            var sum = 0;
            sum = parseFloat(arguments[0]) - parseFloat(arguments[1]);
            return sum;
        }
        function SB2Add() {
            var sum = 0;
            sum = parseFloat(arguments[0]) + parseFloat(arguments[1]);
            return sum;
        }
        function SBPerCal() {
            var sum = 0;
            sum = (parseFloat(arguments[0]) / 100) * parseFloat(arguments[1]);
            return sum;
        }




        var txt_ATotal = $('input:text[id$=txt_ATotal]').keyup(SBfoo3);
        var txt_APackagingAmt = $('input:text[id$=txt_APackagingAmt]').keyup(SBfoo3);
        var txt_AOtherAmt = $('input:text[id$=txt_AOtherAmt]').keyup(SBfoo3);
        function SBfoo3() {
            var value1 = txt_APackagingAmt.val();
            var value2 = txt_AOtherAmt.val();
            var value3 = txt_ATotal.val();
            var PartAmount = add(value1, value2, value3);
            $('input:text[id$=txt_AFinalAmount]').val(PartAmount);
        }
    });
    
}