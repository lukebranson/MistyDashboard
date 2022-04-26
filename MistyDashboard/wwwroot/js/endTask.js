function endTask() {
    console.log("startingTask...");
    var pageUrl = new URL(window.location.href);
    var hostName = pageUrl.hostname;
    apiUrl = window.location.protocol + "//" + hostName + ":" + pageUrl.port + "/api/EndTask";
    console.log("sending request to " + apiUrl);
    taskData = "";
    $.ajax({
        url: apiUrl, contentType: "application/json", type: 'POST', data: taskData, success: function (response) {
            console.log("result: " + response);
            if (response == "success") {
                console.log(response);
                location.reload();
            }
            else {
                console.log("api failed");
            }
        }
    });
    console.log("skill starter script complete");
}