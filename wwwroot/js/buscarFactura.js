
$(document).ready(function () {
    
    $("#selectorCliente").load("../Cliente/Selector",function(){
        $("#rdbNumeroFactura").prop("checked",true);    
        $("#idCliente").prop("disabled",true);
    });
    
    $("#rdbNumeroFactura").on("click",function(){
        $("#idCliente").prop("disabled",true);
        $("#txtNumeroFactura").prop("disabled",false);
    })
    $("#rdbCliente").on("click",function(){
        $("#idCliente").prop("disabled",false);
        $("#txtNumeroFactura").prop("disabled",true);
    })
});


