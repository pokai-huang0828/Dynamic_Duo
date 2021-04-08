$(document).ready(function () {


});

$("#UpdateBtn").click(event => {
    event.preventDefault();

    var currentStatus = $("#deliveryStatusText").text();
    var checkOutId = $("#UpdateBtn").attr("data-checkoutid");

    $.ajax({
        url: "https://localhost:44333/deliverystatus?id=" + checkOutId + "&deliveryStatus=" + currentStatus,
        method: 'GET',
        dataType: "text",
        success: function (result) {
            console.log("result return here!!", result);
            $("#deliveryStatusText").text(result);
        },
        error: function () {
            $("#deliveryStatusText").text("Server Error");
        }    
    });
});