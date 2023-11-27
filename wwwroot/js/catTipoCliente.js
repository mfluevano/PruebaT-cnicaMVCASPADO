//Modelos

const modeloTipoClientes = {
  Id: 0,
  TipoCliente: "",
};
//Modelos


function Mostrar() {
  fetch("CatTipoCliente/Listar")
    .then((response) => {
      return response.ok ? response.json() : Promise.reject(response);
    })
    .then((responseJson) => {
      $("#tblCatTipoCliente tbody").html("");
      var html = "";

      responseJson.forEach((elementos) => {
        console.log(elementos);
        $("#tblCatTipoCliente tbody").append(
          $("<tr>").append(
            $("<td>").text(elementos.tipoCliente),
            $("<td>").append(
              $("<button>")
                .addClass("btn btn-primary btn-sm boton-editar-tipo")
                .text("Editar")
                .data("dataProducto", elementos),
              $("<button>")
                .addClass("btn btn-danger btn-sm ms-2 boton-eliminar-tipo")
                .text("Eliminar")
                .data("dataProducto", elementos)
            )
          )
        );
      });
    });
}

function MostrarModal() {
  $("#Id").val(modeloTipoClientes.Id);
  $("#TipoCliente").val(modeloTipoClientes.TipoCliente);
  $("#modalTipoCliente").modal("show");    
}

function Agregar() {

  // Creamos un objeto con los datos del nuevo elemento
  const datos = {
    Id: modeloTipoClientes.Id,
    TipoCliente: $("#TipoCliente").val(),
  };
  if (modeloTipoClientes.Id == 0) {
    fetch("CatTipoCliente/Guardar", {
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
          $("#modalTipoCliente").modal("hide");
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
    fetch("CatTipoCliente/Editar", {
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
          $("#modalTipoCliente").modal("hide");
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
  modeloTipoClientes.Id=0;
  modeloTipoClientes.TipoCliente="";
  MostrarModal();
});

$("#btnAgregar").click(function () {
  Agregar();
});

$("#Imagen").change(function () {
  readURL(this);
});
document.addEventListener("DOMContentLoaded", function () {
  Mostrar();
});

$(document).on("click", ".boton-editar-tipo", function () {
  const _tipo = $(this).data("dataProducto");

  modeloTipoClientes.Id = _tipo.id;
  modeloTipoClientes.TipoCliente = _tipo.tipoCliente;

  MostrarModal();
});

$(document).on("click", ".boton-eliminar-tipo", function () {
  const _producto = $(this).data("dataProducto");

  Swal.fire({
    title: "Esta seguro?",
    text: `Eliminar producto "${_producto.nombreProducto}"`,
    icon: "warning",
    showCancelButton: true,
    confirmButtonColor: "#3085d6",
    cancelButtonColor: "#d33",
    confirmButtonText: "Si, eliminar",
    cancelButtonText: "No, volver",
  }).then((result) => {
    if (result.isConfirmed) {
      fetch(`CatTipoCliente/Eliminar?Id=${_producto.id}`, {
        method: "DELETE",
      })
        .then((response) => {
          return response.ok ? response.json() : Promise.reject(response);
        })
        .then((responseJson) => {
          if (responseJson.valor) {
            Swal.fire("Listo!", "Producto fue elminado", "success");
            Mostrar();
          } else Swal.fire("Lo sentimos", "No se puedo eliminar", "error");
        });
    }
  });
});
