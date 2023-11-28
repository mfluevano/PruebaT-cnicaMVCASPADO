modeloFactura={
  id:0,
  FechaEmisionFactura: "",
  idCliente: 0,
  NumeroFactura:0,
  NumeroTotalArticulos:0,
  SubTotalFactura: 0,
  TotalImpuesto:0,
  TotalFactura:0,
  DetalleFactura:[]
} 

//Metodo para crear linea de captura
function agregarPartidaCaptura() {
  const combo = $("#productosSelector select").clone();
  $("#tblFacturaObj tbody").append(
    $("<tr>").append(
      $("<td class='idProducto'>").append(combo),
      $("<td class='precioProduct'>"),
      $("<td class='cantidad'>").append(
        $(
          "<input type='text' class='form-control txtCantidad input-number' value='1'>"
        )
      ),
      $("<td class='imagen'>"),
      $("<td class='total'>")
    )
  ); 
}

$("#btnAgregaPartida").on("click", function () {
  agregarPartidaCaptura();
});
// Evento  en cambio de cantidad por linea de  captura

$("#tblFacturaObj tbody").on("change", ".txtCantidad", function () {
  const precio = parseFloat(
    $(this).parent().parent().find("option:selected").data("precio")
  );

  const cantidad = parseFloat($(this).val());
  $(this)
    .closest("tr")
    .find("td.total")
    .text((precio * cantidad));
  calculoTotales();
});


$("#btnNuevaFac").on("click", function () {
  Swal.fire({
    title: "¿Esta seguro?",
    text: `Esta accion comenzara de nuevo el proceso y los cambios se perderan"`,
    icon: "warning",
    showCancelButton: true,
    confirmButtonColor: "#3085d6",
    cancelButtonColor: "#d33",
    confirmButtonText: "Si, Continiuar",
    cancelButtonText: "No, volver",
  }).then((result) => {
    if (result.isConfirmed) {
      $("#tblFacturaObj tbody").html("");
      calculoTotales();
      }})
    }
);

$("#tblFacturaObj ").on("change", ".cmbProductos", function () {
  const precio = parseFloat(
    $(this).parent().parent().find("option:selected").data("precio")
  );

  const imagen = $(this)
    .parent()
    .parent()
    .find("option:selected")
    .data("imagen");

  const cantidad = parseFloat(
    $(this).parent().parent().closest("tr").find("td.cantidad input").val()
  );

  $(this).closest("tr").find("td.precioProduct").text((precio));

  $(this)
    .closest("tr")
    .find("td.total")
    .text((precio * cantidad).toFixed(2));
  $(this)
    .closest("tr")
    .find("td.imagen")
    .html('<img src="' + imagen + '" height="50px" >');
  calculoTotales();
});

function calculoTotales() {
  //completar aqui
  let subTotal = 0;
  $(".total").each(function () {
    console.log($(this).text());
    subTotal += parseFloat($(this).text());
  });
  $(".subTotal").text(subTotal.toFixed(2));
  $(".impuestos").text((subTotal * 0.19).toFixed(2));
  $(".gTotal").text(((subTotal * 1.19).toFixed(2)));
}

$(document).ready(function () {
  $("#cmbCliente").load("Cliente/Selector");
  $("#productosSelector").load("CatProducto/Selector");
  $("#productosSelector").hide();
  calculoTotales();
});

  $("#btnGuardarFactura").click(function() {
    guardarFactura();
   });






   function guardarFactura() {
    const idCliente = parseInt($("#idCliente").val());
    const numeroFactura = parseInt($("#NumeroFactura").val());
    const fechaEmisionFactura = new Date();
  
    const detallesFactura = [];
  
      $("#tblFacturaObj tbody tr").each(function() {
        const idProducto = parseInt( $(this).find("td select").val());
        const cantidad = parseInt( $(this).find("td .txtCantidad").val());
        const precioUnitario = parseFloat($(this).find("td:eq(1)").text());
    
      detallesFactura.push({
        idProducto,
        cantidad,
        precioUnitario
      });
    });
  
    let data = {
      Id: 0,
      FechaEmisionFactura: $("#FechaEmisionFactura").val(),
      IdCliente: idCliente,
      NumeroFactura: numeroFactura,
      NumeroTotalArticulos: detallesFactura.length,
      SubTotalFactura: parseFloat($(".subTotal").text()),
      TotalImpuesto: parseFloat($(".impuestos").text()),
      TotalFactura: parseFloat($(".gTotal").text()),
      DetalleFactura: detallesFactura
    };
  console.table(data);
  console.log(JSON.stringify(data));
  $.ajax({
    url: "/Facturacion/Guardar",
    method: "POST",
    contentType: "application/json; charset=utf-8",
    data: JSON.stringify(data),
    success: function(data) {
     
        Swal.fire({
          title: "Factura Guardada",
          text: "La factura se ha guardado correctamente.",
          icon: "success",
          confirmButtonColor: "#3085ed",
          confirmButtonText: "Ok"
        }).then(()=>{
          $("#tblFacturaObj tbody").html("");
          calculoTotales();
        });

      }
    ,
    error: function(error) {
      console.error(error);
      Swal.fire({
        title: "Error al Guardar la Factura",
        text: "Error al guardar la factura: " + error.message,
        icon: "error",
        confirmButtonColor: "#3085ed",
        confirmButtonText: "Ok"
      });
    }
  });
  
  }
  