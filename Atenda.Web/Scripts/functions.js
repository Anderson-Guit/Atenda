
(function ($) {
    AddTableRow = function() {

        //$.ajax({ type: 'GET', url: '/Orcamento/AddProdutos', dataType: 'cshtml', cache: false, async: true, success: function (data) { $('#addProduto').html(data); } });

        var newRow = $('<div class="form-group">');
        var cols = "";

        cols += '<label class="control-label col-md-2" for="NomeProduto">Produto</label>';
        cols += '<div class="col-md-10">';
        cols += '<select class="form-control" id="IdProduto" name="IdProduto"><option value="IdProduto">"IdProduto"</option>';
        cols += '<option value="1">Produto1</option>';
        cols += '<option value="2">Produto2</option>';
        cols += '<option value="3">Produto3</option>';
        cols += '</select>';
        cols += '</div>';
        cols += '<button class="btn btn-danger" onclick="RemoveTableRow(this)" type="button">-</button>';

        newRow.append(cols);
        $("#product").append(newRow);

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