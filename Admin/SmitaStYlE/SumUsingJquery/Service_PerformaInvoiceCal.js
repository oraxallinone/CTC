
function pageLoad() {
    $(function PINVOICE() {

        var txt_SGrossAmount = $('input:text[id$=txt_SGrossAmount]').keyup(PIfoo);
        var txt_SDiscountPer = $('input:text[id$=txt_SDiscountPer]').keyup(PIfoo);
        var txt_SerDiscountAmount = $('input:text[id$=txt_SerDiscountAmount]').keyup(PIfoo);
        var txt_StotalAmount = $('input:text[id$=txt_StotalAmount]').keyup(PIfoo);
        var txt_TotalSpareAmount = $('input:text[id$=txt_TotalSpareAmount]').keyup(PIfoo);
        var txt_LabourCharges = $('input:text[id$=txt_LabourCharges]').keyup(PIfoo);
        var txt_LabDiscountPer = $('input:text[id$=txt_LabDiscountPer]').keyup(PIfoo);
        var txt_LabourChargesAftDisc = $('input:text[id$=txt_LabourChargesAftDisc]').keyup(PIfoo);
        var txt_BillAmount = $('input:text[id$=txt_BillAmount]').keyup(PIfoo);
        var txt_SVatAmount = $('input:text[id$=txt_SVatAmount]').keyup(PIfoo);
        var txt_sertaxamount = $('input:text[id$=txt_sertaxamount]').keyup(PIfoo);
        var txt_outsidecharge = $('input:text[id$=txt_outsidecharge]').keyup(PIfoo);
        var txt_otherchrg = $('input:text[id$=txt_otherchrg]').keyup(PIfoo);

        function PIfoo() {
            var SGrossAmount = txt_SGrossAmount.val();
            var SDiscountPer = txt_SDiscountPer.val();
            var SerDiscountAmount = txt_SerDiscountAmount.val();
            var StotalAmount = txt_StotalAmount.val();
            var TotalSpareAmount = txt_TotalSpareAmount.val();
            var SVatAmount = txt_SVatAmount.val();
            var BillAmount = txt_BillAmount.val();
            var LabourChargesAftDisc = txt_LabourChargesAftDisc.val();
            var sertaxamount = txt_sertaxamount.val();
            var outsidecharge = txt_outsidecharge.val();
            var otherchrg = txt_otherchrg.val();

           //Service discount Amount
            var percent = DiscountAmount(SGrossAmount, SDiscountPer);
            $('input:text[id$=txt_SerDiscountAmount]').val(percent);

            //Service total amount
            var sub1 = SB2Sub1(SGrossAmount, percent);
            $('input:text[id$=txt_StotalAmount]').val(sub1);


         
            //Bill Amount
            var sum1 = SB2Add(sub1, TotalSpareAmount,outsidecharge);
//                        $('input:text[id$=txt_BillAmount]').val(sum1);

            //Total Amount With Vat
                        var sum2 = SB2Add1(sum1, SVatAmount);
//            $('input:text[id$=txt_BillAmount]').val(sum2);



            var LabourCharges = txt_LabourCharges.val();
            var LabDiscountPer = txt_LabDiscountPer.val();



            //labour percent
            var percent = DiscountAmount(LabourCharges, LabDiscountPer);
            $('input:text[id$=txt_LabDiscountAmount]').val(percent);

            //labour after discount
            var sub = SB2Sub(LabourCharges, percent);
            $('input:text[id$=txt_LabourChargesAftDisc]').val(sub);
            //            //labour charges
            var sum3 = SB2Add2(sum2, sub);
            $('input:text[id$=txt_BillAmount]').val(sum3);

            //other amount
            var other = add1(sum3, otherchrg,sertaxamount);
            $('input:text[id$=txt_BillAmount]').val(other);

//            var other = add(StotalAmount, SVatAmount, TotalSpareAmount, LabourChargesAftDisc, sertaxamount, outsidecharge);
//            $('input:text[id$=txt_BillAmount]').val(other);
                        
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
        function IsNumeric(input) {
            return (input - 0) == input && input.length > 0;
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

        function SB2Sub1() {
            var sub1 = 0;
            sub1 = parseFloat(arguments[0]) - parseFloat(arguments[1]);
            return sub1;
        }
        function SB2Sub() {
            var sub = 0;
            sub = parseFloat(arguments[0]) - parseFloat(arguments[1]);
            return sub;
        }
        function SB2Add() {
            var sum1 = 0;
            sum1 = parseFloat(arguments[0]) + parseFloat(arguments[1])+ parseFloat(arguments[2]);
            return sum1;
        }
        function SB2Add1() {
            var sum2 = 0;
            sum2 = parseFloat(arguments[0]) + parseFloat(arguments[1]);
            return sum2;
        }
        function SB2Add2() {
            var sum3 = 0;
            sum3 = parseFloat(arguments[0]) + parseFloat(arguments[1]);
            return sum3;
        }
        function add1() {
            var other = 0;
            other = parseFloat(arguments[0]) + parseFloat(arguments[1])+parseFloat(arguments[2]);
            return other;
        }
        function DiscountAmount() {

            var percent = 0;

            percent = (parseFloat(arguments[0]) * parseFloat(arguments[1])) / 100;

            return percent;


        }


    });

}