function checkTest(modelo) {
    var result = JSON.parse(modelo);
    result.forEach(function (result, index) {
        console.log("WordId " + result.WordId + " | WordtoShow: " + result.WordToShow + " TrueOptions: " + result.TrueOptions)
    });
    
}
