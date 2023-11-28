$(document).ready(function () {
  $("#selectorCliente").load("../Cliente/Selector", function () {
    $("#rdbNumeroFactura").prop("checked", true);
    $("#idCliente").prop("disabled", true);
  });

  $("#rdbNumeroFactura").on("click", function () {
    $("#idCliente").prop("disabled", true);
    $("#txtNumeroFactura").prop("disabled", false);
  });

  $("#rdbCliente").on("click", function () {
    $("#idCliente").prop("disabled", false);
    $("#txtNumeroFactura").prop("disabled", true);
  });

  $("#btnBuscar").on("click", function () {
    if ($("#rdbNumeroFactura").prop("checked")) {
      BuscarFacturaPorNumeroFactura();
    } else {
      BuscarFacturaPorCliente();
    }
  });

  function BuscarFacturaPorNumeroFactura() {
    var numeroFactura = $("#txtNumeroFactura").val();

    if (numeroFactura !== "") {
      $.ajax({
        url: "/Facturacion/BuscarFacturaPorNumeroFactura",
        data: { numeroFactura: numeroFactura },
        method: "GET",
        success: function (response) {
          if (response !== null) {
            MostrarResultadoFactura(response);
          } else {
            alert("No se encontró ninguna factura con el número de factura especificado.");
          }
        },
        error: function (error) {
          console.error(error);
          alert("Ocurrió un error al buscar la factura.");
        }
      });
    } else {
      alert("Ingrese el número de factura para buscar.");
    }
  }

  function BuscarFacturaPorCliente() {
    var idCliente = $("#idCliente").val();

    if (idCliente !== "") {
      $.ajax({
        url: "/Facturacion/BuscarFacturaPorCliente",
        data: { idCliente: idCliente },
        method: "GET",
        success: function (response) {
          if (response !== null && response.length > 0) {
            MostrarResultadoFactura(response);  
          } else {
            alert("No se encontró ninguna factura para el cliente seleccionado.");
          }
        },
        error: function (error) {
          console.error(error);
          alert("Ocurrió un error al buscar las facturas del cliente.");
        }
      });
    } else {
      alert("Seleccione un cliente para buscar.");
    }
  }

  function MostrarResultadoFactura(facturas) {
    var html="";
    console.table(facturas)
    $.each(facturas,factura => {
       html += "<tr>";
      html += "<td>" + facturas[factura]["numeroFactura"] + "</td>";
      html += "<td>" + facturas[factura]["fechaEmisionFactura"] + "</td>";
      html += "<td>" + facturas[factura]["subTotalFactura"] + "</td>";
      html += "</tr>";
    });
      
    $("#tablaFacturas tbody").html(html);
  }

  function MostrarResultadoFacturas(facturas) {
    var html = "";

    for (var i = 0; i < facturas.length; i++) {
      var factura = facturas[i];

      html += "<tr>";
      html += "<td>" + factura.numeroFactura + "</td>";
      html += "<td>" + factura.fechaEmisionFactura + "</td>";
      html += "<td>" + factura.subTotalFactura + "</td>";
      html += "</tr>";
    }

    $("#tablaFacturas").html(html);
  }
});
