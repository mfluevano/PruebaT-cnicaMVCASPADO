
const modeloCliente = {
  Id:0,
  RazonSocial:"" ,
  IdTipoCliente:0,
  TipoCliente:"" ,
  FechaCreacion:"", 
  RFC :""
};

function llenaComboTipos() {
  fetch("CatTipoCliente/Listar")
    .then((response) => {
      return response.ok ? response.json() : Promise.reject(response);
    })
    .then((responseJson) => {
      responseJson.forEach((item) => {
        $(".cmbTipoCLiente").append(
          $("<option>").val(item.id).text(item.tipoCliente)
        );
      });
    });
}

function Mostrar() {
  fetch("Cliente/Listar")
    .then((response) => {
      return response.ok ? response.json() : Promise.reject(response);
    })
    .then((responseJson) => {
      $("#tblCatProducto tbody").html("");
      var html = "";

      responseJson.forEach((elementos) => {
        $("#tblCatProducto tbody").append(
          $("<tr>").append(
            $("<td>").text(elementos.razonSocial),
            $("<td>").text(elementos.tipoCliente),
            $("<td>").text(elementos.fechaCreacion),
            $("<td>").text(elementos.rfc),

            $("<td>").append(
              $("<button>")
                .addClass("btn btn-primary btn-sm boton-editar-cliente")
                .text("Editar")
                .data("dataCliente", elementos),
              $("<button>")
                .addClass("btn btn-danger btn-sm ms-2 boton-eliminar-cliente")
                .text("Eliminar")
                .data("dataCliente", elementos)
            )
          )
        );
      });
    });
}

function MostrarModal() {
  $("#Id").val(modeloCliente.Id);
  $("#RazonSocial").val(modeloCliente.RazonSocial);
  $("#IdTipoCliente").val(modeloCliente.IdTipoCliente);
  $("#TipoCliente").val(modeloCliente.TipoCliente);
  $("#FechaCreacion").val(modeloCliente.FechaCreacion);
  $("#RFC").val(modeloCliente.RFC );
  $("#modalCliente").modal("show");
}

function Agregar() {

  // Creamos un objeto con los datos del nuevo elemento
  const datos = {
    Id: modeloCliente.Id,
    RazonSocial: $("#RazonSocial").val(),
    IdTipoCliente: $("#IdTipoCliente").val(),
    RFC: $("#RFC").val()
  } 


  if (modeloCliente.Id == 0) {
    fetch("Cliente/Guardar", {
      method: "POST",
      headers: { "Content-Type": "application/json; charset=utf-8" },
      body: JSON.stringify(datos),
    })
      .then((response) => {
        // Si la respuesta es exitosa, mostramos un mensaje de éxito
        if (response.ok) {
          Swal.fire({
            title: "Éxito",
            text: "El elemento se agregó correctamente",
            icon: "success",
          });

          // Refrescamos la tabla
          Mostrar();

          // Cierra el modal
          $("#modalCliente").modal("hide");
        } else {
          // Si la respuesta no es exitosa, mostramos un mensaje de error
          const error = response.json();
          error.then((error) => {
            Swal.fire({
              title: "Error",
              text: error.message,
              icon: "error",
            });
          });
        }
      })
      .catch((error) => {
        // Si ocurre un error, mostramos un mensaje de error
        Swal.fire({
          title: "Error",
          text: error.message,
          icon: "error",
        });
      });
  }
  else
  {
    fetch("Cliente/Editar", {
      method: "PUT",
      headers: { "Content-Type": "application/json; charset=utf-8" },
      body: JSON.stringify(datos),
    })
      .then((response) => {
        // Si la respuesta es exitosa, mostramos un mensaje de éxito
        if (response.ok) {
          Swal.fire({
            title: "Éxito",
            text: "El elemento se modifico correctamente",
            icon: "success",
          });

          // Refrescamos la tabla
          Mostrar();

          // Cierra el modal
          $("#modalCliente").modal("hide");
        } else {
          // Si la respuesta no es exitosa, mostramos un mensaje de error
          const error = response.json();
          error.then((error) => {
            Swal.fire({
              title: "Error",
              text: error.message,
              icon: "error",
            });
          });
        }
      })
      .catch((error) => {
        // Si ocurre un error, mostramos un mensaje de error
        Swal.fire({
          title: "Error",
          text: error.message,
          icon: "error",
        });
      });
  }
}
$("#btnNuevo").click(function () {
  modeloCliente.Id=0;
  modeloCliente.RazonSocial="";
  modeloCliente.IdTipoCliente=0;
  modeloCliente.TipoCliente="";
  modeloCliente.FechaCreacion="",
  modeloCliente.RFC="";
  MostrarModal();
});

$(document).on("click", ".boton-editar-cliente", function () {
  const _cliente = $(this).data("dataCliente");

  modeloCliente.Id= _cliente.id;
  modeloCliente.RazonSocial = _cliente.razonSocial;
  modeloCliente.IdTipoCliente =_cliente.idTipoCliente;
  modeloCliente.TipoCliente = _cliente.tipoCliente;
  modeloCliente.FechaCreacion = _cliente.fechaCreacion;
  modeloCliente.RFC =_cliente.rfc;
  
  MostrarModal();
});
$("#btnAgregar").click(function () {
  Agregar();
});

document.addEventListener("DOMContentLoaded", function () {
  llenaComboTipos();
  Mostrar()
});


$(document).on("click", ".boton-eliminar-cliente", function () {
  const _cliente = $(this).data("dataCliente");
  console.table(_cliente)
  Swal.fire({
    title: "Esta seguro?",
    text: `Eliminar Cliente "${_cliente.razonSocial}"`,
    icon: "warning",
    showCancelButton: true,
    confirmButtonColor: "#3085d6",
    cancelButtonColor: "#d33",
    confirmButtonText: "Si, eliminar",
    cancelButtonText: "No, volver",
  }).then((result) => {
    if (result.isConfirmed) {
      fetch(`Cliente/Eliminar?Id=${_cliente.id}`, {
        method: "DELETE",
      })
        .then((response) => {
          return response.ok ? response.json() : Promise.reject(response);
        })
        .then((responseJson) => {
          if (responseJson.valor) {
            Swal.fire("Listo!", "Cliente fue elminado", "success");
            Mostrar();
          } else Swal.fire("Lo sentimos", "No se puedo eliminar", "error");
        });
    }
  });
});

