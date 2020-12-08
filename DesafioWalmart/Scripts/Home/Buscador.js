//se registra el evento
$(document).ready(function () {
    $("#txtBuscador").on("keyup", function (event) {
        InputSearch_OnKeyUp(event);
    });    
});

//realiza la peticion ajax
function BuscarProducto() {
    let currentHtmlResultado = $("#resultadoBusqueda").html();
    let htmlCargando = "<div class= 'loading' style = 'text-align:center' > <img style='vertical-align:midle' src='/Content/gif/ajax-loader.gif' alt='loading' /> <br />Cargando...</div >";
    $("#resultadoBusqueda").html(htmlCargando);
    $.ajax({
        data: {
            "busqueda": $.trim($("#txtBuscador").val())
        },
        url: "/Home/ListarProductos",
        type: "post",
        success: function (response) {
            if (response && response.Result == null) {
                $("#resultadoBusqueda").html(response);
            }
            else {
                MostrarError(response.Msg);
                $("#resultadoBusqueda").html(currentHtmlResultado);
            }
        },
        error: function ($res) {
            $("#resultadoBusqueda").html(currentHtmlResultado);
            MostrarError("Error en la respuesta. <br/>" + $res);
        }
    });
}

//manejar el tecleo en el buscador
function InputSearch_OnKeyUp(event) {
    
    let inputSearch = $(event.currentTarget);
    let btnSearch = $("#btnBuscar");
    let busqueda = inputSearch.val();
    if (ValidaEstadoBotonBuscar()) {
        btnSearch.removeClass("disabled");
        btnSearch.removeAttr("disabled");

        //revisamos si es un enter
        if (event.key === "Enter") {
            event.preventDefault();
            btnSearch.trigger("click");
        }

    }
    else {
        btnSearch.addClass("disabled");
        btnSearch.prop("disabled", true);
    }

    
}

function ValidaEstadoBotonBuscar() {
    let inputSearch = $("#txtBuscador");    
    let busqueda = inputSearch.val();
    
    return $.isNumeric(busqueda) || busqueda.length >= MIN_CHAR_TO_SEARCH;

}

function MostrarError(errorText) {
    let htmlError = "<div class=\"alert alert-danger alert-dismissible fade in\">\n    <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>\n    <strong>¡Error!</strong> <div>" + errorText + "</div>\n</div>\n";
    $("#divError").html(htmlError);

}