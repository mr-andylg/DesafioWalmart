$(document).ready(function () {
    $("#txtBuscador").on("keyup", function (event) {
        InputSearch_OnKeyUp(event);
    });    
});

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

function InputSearch_OnKeyUp(event) {
    
    let inputSearch = $(event.currentTarget);
    let btnSearch = $("#btnBuscar");
    let busqueda = inputSearch.val();
    if ($.isNumeric(busqueda) || busqueda.length >= MIN_CHAR_TO_SEARCH) {
        btnSearch.removeClass("disabled");
        btnSearch.removeAttr("disabled");
    }
    else {
        btnSearch.addClass("disabled");
        btnSearch.attr("disabled", "");
    }
}

function MostrarError(errorText) {
    let htmlError = "<div class=\"alert alert-danger alert-dismissible fade in\">\n    <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>\n    <strong>¡Error!</strong> <div>" + errorText + "</div>\n</div>\n";
    $("#divError").html(htmlError);

}