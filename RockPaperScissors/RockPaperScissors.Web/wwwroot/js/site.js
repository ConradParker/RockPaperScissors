var results = $("#Results");
var onBegin = function () {
    results.html("<img src=\"/images/ajax-loader.gif\" alt=\"Loading\" />");
};

var onComplete = function () {
    results.html("Completed");
};

var onSuccess = function (context) {
    alert(context);
};

var onFailed = function (context) {
    alert("Failed");
};