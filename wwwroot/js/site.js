function checkTest(modelo) {
    var result = JSON.parse(modelo);
    result.forEach(function (result, index) {
        var identTempInput = "#q" + result.WordId;
        var contentInput = $(identTempInput).val();

        if ($.trim(contentInput) != "") {
            var valueIndex = result.TrueOptions.indexOf(contentInput);
            if (valueIndex != -1) {
                $(identTempInput).removeClass("border-danger").addClass("border-success");
            } else {
                $(identTempInput).removeClass("border-success").addClass("border-danger");
            }
        } else {
            $(identTempInput).removeClass("border-success").addClass("border-danger");
        }                
    });
    
}
