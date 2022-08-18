function AddtoCart(clickedIndex) {
    var selectedProduct = $("#SelectedProduct");
    var control = $("#CartDetailsPartial");
    selectedProduct.val(clickedIndex);
    var addtoCartClick = $("#AddtoCartClick");
    addtoCartClick.val(true);
    var $form = $("#FormProducts :input");
    var data = $form.serialize();
    $.ajax({
        type: 'POST',
        url: 'Tesco/Inventory',
        datatype: "Json",
        data: data,
        success: function (data) {
            control.html("");
            control.html(data);
        }
    });
}