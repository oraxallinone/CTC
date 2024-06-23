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
            $('input:text[id$=txt_PartAmount]').val(PartAmount);

            var PartNetAmt = SB2Sub(PartAmount, txt_PartDiscount.val());

            var PartTaxAmount = SBPerCal(PartNetAmt, txt_PartVat.val());
            $('input:text[id$=txt_PartTaxAmount]').val(PartTaxAmount);

            var PartTotal = SB2Add(PartNetAmt, PartTaxAmount);
            $('input:text[id$=txt_PartTotal]').val(PartTotal);
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


        var txt_SQuantity = $('input:text[id$=txt_SQuantity]').keyup(SBfoo2);
        var txt_SRate = $('input:text[id$=txt_SRate]').keyup(SBfoo2);
        var txt_SAmount = $('input:text[id$=txt_SAmount]').keyup(SBfoo3);

        function SBfoo2() {
            var value1 = txt_SQuantity.val();
            var value2 = txt_SRate.val();
            var SAmount = SBAmount(value1, value2);
            $('input:text[id$=txt_SAmount]').val(SAmount);
        }

        function SBfoo3() {
            var value1 = txt_SQuantity.val();
            var SAmount = txt_SAmount.val();
            var SRate = SBRate(value1, SAmount);
            $('input:text[id$=txt_SRate]').val(SRate);
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

        var txt_AGrossAmount = $('input:text[id$=txt_AGrossAmount]').keyup(SBfoo4);
        var txt_ASerDiscountPer = $('input:text[id$=txt_ASerDiscountPer]').keyup(SBfoo4);
        var txt_ASerDiscountAmount = $('input:text[id$=txt_ASerDiscountAmount]').keyup(SBfoo4);
        var txt_ANetAmount = $('input:text[id$=txt_ANetAmount]').keyup(SBfoo4);
        var txt_AVatAmount = $('input:text[id$=txt_AVatAmount]').keyup(SBfoo4);
        var txt_ATotalSpareAmount = $('input:text[id$=txt_ATotalSpareAmount]').keyup(SBfoo4);
        var txt_ALabourCharges = $('input:text[id$=txt_ALabourCharges]').keyup(SBfoo4);
        var txt_ALabDiscountPer = $('input:text[id$=txt_ALabDiscountPer]').keyup(SBfoo4);
        var txt_ALabDiscountAmount = $('input:text[id$=txt_ALabDiscountAmount]').keyup(SBfoo4);
        var txt_ALabourChargesAftDisc = $('input:text[id$=txt_ALabourChargesAftDisc]').keyup(SBfoo4);
        var txt_AServiceTaxPer = $('input:text[id$=txt_AServiceTaxPer]').keyup(SBfoo4);
        var txt_AServiceTaxAmt = $('input:text[id$=txt_AServiceTaxAmt]').keyup(SBfoo4);
        var txt_AOtherAmount = $('input:text[id$=txt_AOtherAmount]').keyup(SBfoo4);
        var txt_ABillAmount = $('input:text[id$=txt_ABillAmount]').keyup(SBfoo4);

        function SBfoo4() {
            var value1 = txt_AGrossAmount.val();
            var value2 = txt_ASerDiscountPer.val();
            var SerDiscountAmount = SBPerCal(value1, value2);
            $('input:text[id$=txt_ASerDiscountAmount]').val(SerDiscountAmount);

            var value3 = txt_AGrossAmount.val();
            var value4 = txt_ASerDiscountAmount.val();
            var NetAmount = SB2Sub(value3, value4);
            $('input:text[id$=txt_ANetAmount]').val(NetAmount);

            var value5 = txt_ALabourCharges.val();
            var value6 = txt_ALabDiscountPer.val();
            var LabDiscountAmount = SBPerCal(value5, value6);
            $('input:text[id$=txt_ALabDiscountAmount]').val(LabDiscountAmount);

            var value7 = txt_ALabourCharges.val();
            var value8 = txt_ALabDiscountAmount.val();
            var LabourChargesAftDisc = SB2Sub(value7, value8);
            $('input:text[id$=txt_ALabourChargesAftDisc]').val(LabourChargesAftDisc);

            var value9 = txt_ALabourChargesAftDisc.val();
            var value10 = txt_AServiceTaxPer.val();
            var ServiceTaxAmt = SBPerCal(value9, value10);
            $('input:text[id$=txt_AServiceTaxAmt]').val(ServiceTaxAmt);

            var VatAmount = txt_AVatAmount.val();
            var TotalSpareAmount = txt_ATotalSpareAmount.val();
            var OtherAmount = txt_AOtherAmount.val();
            var BillAmount = add(txt_ANetAmount.val(), VatAmount, TotalSpareAmount, txt_ALabourChargesAftDisc.val(), txt_AServiceTaxAmt.val(), OtherAmount);
            $('input:text[id$=txt_ABillAmount]').val(BillAmount);
        }
    });
    
}