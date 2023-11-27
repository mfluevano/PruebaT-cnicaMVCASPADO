//Modelos

const modeloCatProductos = {
  Id: 0,
  NombreProducto: "",
  ImagenProducto: "",
  PrecioUnitario: 0,
  Ext: "",
};

function readURL(input) {
  if (input.files && input.files[0]) {
    var reader = new FileReader();

    reader.onload = function (e) {
      $("#prev").attr("src", e.target.result);
      $("#ImagenProducto").val(e.target.result);
    };

    reader.readAsDataURL(input.files[0]);
  }
}

function Mostrar() {
  fetch("CatProducto/Listar")
    .then((response) => {
      return response.ok ? response.json() : Promise.reject(response);
    })
    .then((responseJson) => {
      $("#tblCatProducto tbody").html("");
      var html = "";

      responseJson.forEach((elementos) => {
        $("#tblCatProducto tbody").append(
          $("<tr>").append(
            $("<td>").text(elementos.nombreProducto),
            $("<td>").append(
              '<img src="' +elementos.imagenProducto +
              '" width="100" height="100">'
            ),
            $("<td>").text(elementos.precioUnitario),
            $("<td>").text(elementos.ext),
            $("<td>").append(
              $("<button>")
                .addClass("btn btn-primary btn-sm boton-editar-producto")
                .text("Editar")
                .data("dataProducto", elementos),
              $("<button>")
                .addClass("btn btn-danger btn-sm ms-2 boton-eliminar-producto")
                .text("Eliminar")
                .data("dataProducto", elementos)
            )
          )
        );
      });
    });
}

function MostrarModal() {
  $("#Id").val(modeloCatProductos.Id);
  $("#NombreProducto").val(modeloCatProductos.NombreProducto);
  $("#ImagenProducto").val(modeloCatProductos.ImagenProducto);
  $("#prev").attr("src", modeloCatProductos.ImagenProducto);
  $("#prev").attr("width", 100);
  $("#prev").attr("height", 100);
  $("#PrecioUnitario").val(modeloCatProductos.PrecioUnitario);
  $("#Ext").val(modeloCatProductos.Ext);
  $("#modalProducto").modal("show");
}

function Agregar() {

  // Creamos un objeto con los datos del nuevo elemento
  const datos = {
    Id: modeloCatProductos.Id,
    NombreProducto: $("#NombreProducto").val(),
    ImagenProducto: $("#ImagenProducto").val(),
    PrecioUnitario: $("#PrecioUnitario").val(),
    Ext: $("#Ext").val(),
  };
  if (modeloCatProductos.Id == 0) {
    fetch("CatProducto/Guardar", {
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
          $("#modalProducto").modal("hide");
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
    fetch("CatProducto/Editar", {
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
          $("#modalProducto").modal("hide");
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
  modeloCatProductos.Id = 0;
  modeloCatProductos.NombreProducto = "";
  modeloCatProductos.ImagenProducto = "~/img/default.svg";
  modeloCatProductos.PrecioUnitario = "";
  modeloCatProductos.Ext = "";
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

$(document).on("click", ".boton-editar-producto", function () {
  const _producto = $(this).data("dataProducto");

  modeloCatProductos.Id = _producto.id;
  modeloCatProductos.NombreProducto = _producto.nombreProducto;
  modeloCatProductos.ImagenProducto = _producto.imagenProducto;
  modeloCatProductos.PrecioUnitario = _producto.precioUnitario;
  modeloCatProductos.Ext = _producto.ext;

  MostrarModal();
});

$(document).on("click", ".boton-eliminar-producto", function () {
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
      fetch(`CatProducto/Eliminar?Id=${_producto.id}`, {
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
