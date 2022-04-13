function startTask() {
    console.log("startingTask...")
    var taskName = document.getElementById("TaskSelection").value;
    var pageUrl = new URL(window.location.href);
    var hostName = pageUrl.hostname;
    apiUrl = window.location.protocol + "//" + hostName + ":" + pageUrl.port + "/api/StartTask";
    console.log("sending request to " + apiUrl);
    taskData = "\""+taskName+"\"";
    $.ajax({
        url: apiUrl, contentType: "application/json", type: 'POST', data: taskData, success: function (response) {
            console.log("result: " + response);
            if (response == "success") {
                console.log(response);
            }
            else {
                console.log("api failed");
            }
        }
    });
    console.log("skill starter script complete");
}