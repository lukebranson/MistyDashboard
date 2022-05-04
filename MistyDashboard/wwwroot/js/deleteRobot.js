//this function deletes a robot by name
function deleteBot(botName) {
    //first we get the hostname of the current page to use in the api url
    var pageUrl = new URL(window.location.href);
    var hostName = pageUrl.hostname;
    //build the api url
    botUrl = window.location.protocol + "//" + hostName + ":" + pageUrl.port + "/api/DeleteRobot";
    //build the data to pass in the body from the parameter
    botData = botName;
    //stringify the data so it can be passed
    var postData = JSON.stringify(botData);
    //make the acutal ajax call with jquery
    $.ajax({
        url: botUrl, contentType: "application/json", type: 'POST', data: postData, success:function(response) {
            console.log("result: " + response);
            //if the deletion succeeds, refresh to show the change
            if (response == "success") {
                console.log(response);
                location.reload();
            }
            else {
                console.log("deletion failed");
            }
        }
    });
}