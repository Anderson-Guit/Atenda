(function($) {
    AddTableRow = function() {

        var newRow = $('<div>@Html.LabelFor(model => model.NomeProduto, htmlAttributes: new { @class = "control-label col-md-2" })</div>');
        var cols = "";

        cols += '<div>';
        cols += '@Html.DropDownList("IdProduto", null, "-Escolha um Produto", new { @class = "form-control" })';
        cols += '@Html.ValidationMessageFor(model => model.IdProduto, "", new { @class = "text-danger" })';
        cols += '</div>';
        cols += '<div>';
        cols += '<button onclick="RemoveTableRow(this)" type="button">Remover</button>';
        cols += '</div>';

        newRow.append(cols);
        $("#products-div").append(newRow);

        return false;
    };
})(jQuery);

(function ($) {

    RemoveTableRow = function (handler) {
        var tr = $(handler).closest('div');

        tr.fadeOut(400, function () {
            tr.remove();
        });

        return false;
    };
})(jQuery);