function pageLoad() {
    $(function SBJ() {
        var txt_APackagingAmt = $('input:text[id$=txt_APackagingAmt]').keyup(SBfoo);
        var txt_AOtherAmt = $('input:text[id$=txt_AOtherAmt]').keyup(SBfoo);
        function SBfoo() {
            var value1 = txt_APackagingAmt.val();
            var value2 = txt_AOtherAmt.val();
            var PartAmount = SB2Add(value1, value2);
            $('input:text[id$=txt_AFinalAmount]').val(PartAmount);
        }
        function SB2Add() {
            var sum = 0;
            sum = parseFloat(arguments[0]) + parseFloat(arguments[1]);
            return sum;
        }
    });
}