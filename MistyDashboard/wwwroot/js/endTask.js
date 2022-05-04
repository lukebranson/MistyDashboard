//this function stops all tasks on all robots
function endTask() {
    //first we get the hostname of the current page to use in the api url
    var pageUrl = new URL(window.location.href);
    var hostName = pageUrl.hostname;
    //build the api url
    apiUrl = window.location.protocol + "//" + hostName + ":" + pageUrl.port + "/api/EndTask";
    //no task data needed
    taskData = "";
    //make the actual ajax call with jquery
    $.ajax({
        url: apiUrl, contentType: "application/json", type: 'POST', data: taskData, success: function (response) {
            console.log("result: " + response);
            //if the api call succeeds, refresh the page to show the changes
            if (response == "success") {
                location.reload();
            }
            else {
                //if it didn't work, report it
                console.log("api failed");
            }
        }
    });
}