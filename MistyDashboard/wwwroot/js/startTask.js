//this function starts a specific task from a drop down menu
function startTask() {
    //first we get the hostname of the current page to use in the api url
    var taskName = document.getElementById("TaskSelection").value;
    //get the hostname for the api call from the current window
    var pageUrl = new URL(window.location.href);
    var hostName = pageUrl.hostname;
    //build the api url
    apiUrl = window.location.protocol + "//" + hostName + ":" + pageUrl.port + "/api/StartTask";
    //stringify the name of the task to send as json
    taskData = "\"" + taskName + "\"";
    //send the actual ajax request with jquery
    $.ajax({
        url: apiUrl, contentType: "application/json", type: 'POST', data: taskData, success: function (response) {
            console.log("result: " + response);
            //reload the page if it worked
            if (response == "success") {
                console.log(response);
                location.reload();
            }
            else {
                //report if the api failed
                console.log("api failed");
            }
        }
    });
}