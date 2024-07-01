function onClickAnchor(model) {
    if (model == "") {
        $('#tab-2-details').html('<p>Solución inviable</p>')
        return;
    }
    var object = JSON.parse(atob(model))
    var sortedData = arrangeData(object)

    $.ajax({
        type: "POST",
        url: "/Tabling/GetPartialView",
        data: sortedData,
        success: function (data) {
            $('#tab-2-details').html(data)
        },
        error: function (error) {
            console.log(error)
        }
    })
}
