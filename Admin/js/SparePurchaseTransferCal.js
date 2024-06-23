function pageLoad() {
    $(function SB() {

        var txt_PartQuantity = $('input:text[id$=txt_transfer]').keyup(SBfoo);
        var txt_PartRate = $('input:text[id$=txt_rate]').keyup(SBfoo);
        var txt_PartAmount = $('input:text[id$=txt_amount]').keyup(SBfoo1);
        var txt_PartDiscount = $('input:text[id$=txt_discount]').keyup(SBfoo);
        var txt_PartVat = $('input:text[id$=txt_vat]').keyup(SBfoo);
        var txt_PartTaxAmount = $('input:text[id$=txt_taxamount]').keyup(SBfoo);
        var txt_PartTotal = $('input:text[id$=txt_total]').keyup(SBfoo);

        function SBfoo() {
            var value1 = txt_PartQuantity.val();
            var value2 = txt_PartRate.val();
            var PartAmount = SBAmount(value1, value2);
            $('input:text[id$=txt_amount]').val(PartAmount);

            var PartNetAmt = SB2Sub(PartAmount, txt_PartDiscount.val());

            var PartTaxAmount = SBPerCal(PartNetAmt, txt_PartVat.val());
            $('input:text[id$=txt_taxamount]').val(PartTaxAmount);

            var PartTotal = SB2Add(PartNetAmt, PartTaxAmount);
            $('input:text[id$=txt_total]').val(PartTotal);
        }

        function SBfoo1() {
            var value1 = txt_PartQuantity.val();
            var PartAmount = txt_PartAmount.val();
            var PartRate = SBRate(value1, PartAmount);
            $('input:text[id$=txt_rate]').val(PartRate);

            var PartNetAmt = SB2Sub(PartAmount, txt_PartDiscount.val());

            var PartTaxAmount = SBPerCal(PartNetAmt, txt_PartVat.val());
            $('input:text[id$=txt_taxamount]').val(PartTaxAmount);

            var PartTotal = SB2Add(PartNetAmt, PartTaxAmount);
            $('input:text[id$=txt_total]').val(PartTotal);
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
        function SBAmount() {
            var sum = 0;
            sum = parseFloat(arguments[0]) * parseFloat(arguments[1]);
            return sum;
        }
        function SBRate() {
            var sum = 0;
            sum = parseFloat(arguments[1]) / parseFloat(arguments[0]);
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