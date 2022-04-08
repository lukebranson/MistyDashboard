function deleteBot(botName) {
    console.log("deleting robot...");
    var pageUrl = new URL(window.location.href);
    var hostName = pageUrl.hostname;
    botUrl = "http://" + hostName + ":" + pageUrl.port + "/api/DeleteRobot";
    botData = botName;
    var postData = JSON.stringify(botData);
    $.ajax({
        url: botUrl, contentType: "application/json", type: 'POST', data: postData, success:function(response) {
            console.log("result: " + response);
            if (response == "success") {
                console.log(response);
                location.reload();
            }
            else {
                console.log("deletion failed");
            }
        }
    });
    console.log("bot add script complete");
}