function addBot() {
    console.log("adding robot...")
    var botName = document.getElementById("nameInput").value;
    var botIp = document.getElementById("ipInput").value;
    var pageUrl = new URL(window.location.href);
    var hostName = pageUrl.hostname;
    botUrl = "http://" + hostName + ":" + pageUrl.port + "/api/AddRobot";
    console.log("sending request to " + botUrl);
    botData = { "Name": botName, "Ip": botIp };
    var postData = JSON.stringify(botData);
    $.post({
        url: botUrl, dataType: 'json', contentType: "application/json", type: 'post', data: postData, function(result) {
            console.log("result: " + result);
            if (result == "success") {
                console.log(result);
                location.reload();
            }
        }
    });
    console.log("bot add script complete");
}