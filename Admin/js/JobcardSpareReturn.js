function pageLoad() {
    $(function SB() {

        var txt_returnquantity = $('input:text[id$=txt_returnquantity]').keyup(SBfoo);
        var txt_PartQuantity = $('input:text[id$=txt_PartQuantity]').keyup(SBfoo);
        var txt_PartRate = $('input:text[id$=txt_PartRate]').keyup(SBfoo);
        var txt_PartAmount = $('input:text[id$=txt_PartAmount]').keyup(SBfoo);
        var txt_PartDiscount = $('input:text[id$=txt_PartDiscount]').keyup(SBfoo);
        var txt_PartVat = $('input:text[id$=txt_PartVat]').keyup(SBfoo);
        var txt_PartTaxAmount = $('input:text[id$=txt_PartTaxAmount]').keyup(SBfoo);
        var txt_PartTotal = $('input:text[id$=txt_PartTotal]').keyup(SBfoo);

        function SBfoo() {

            var quantity = txt_PartQuantity.val();
            var requantity = txt_returnquantity.val();
            var discount = txt_PartDiscount.val();
            var vat = txt_PartVat.val();
            var rate = txt_PartRate.val();
            var qnty = SB2Sub(quantity, requantity);

            var PartAmount = SBAmount(qnty, rate).toFixed(2);
            $('input:text[id$=txt_PartAmount]').val(PartAmount);

            var PartNetAmt = SB2Sub(PartAmount, discount);

            var PartTaxAmount = SBPerCal(PartNetAmt, vat).toFixed(2);
            $('input:text[id$=txt_PartTaxAmount]').val(PartTaxAmount);

            var PartTotal = SB2Add(PartNetAmt, PartTaxAmount);
            $('input:text[id$=txt_PartTotal]').val(PartTotal);
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
        function SBAmount() {
            var sum = 0;
            sum = parseFloat(arguments[0]) * parseFloat(arguments[1]);
            return sum;
        }

        function SB2Sub() {
            var sum = 0;
            sum = parseFloat(arguments[0]) - parseFloat(arguments[1]);
            return sum;
        }

    });
        }