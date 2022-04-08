function addBot() {
    console.log("adding robot...")
    var botName = document.getElementById("nameInput").value;
    var botIp = document.getElementById("ipInput").value;
    var pageUrl = new URL(window.location.href);
    var hostName = pageUrl.hostname;
    botUrl = window.location.protocol + "//" + hostName + ":" + pageUrl.port + "/api/AddRobot";
    console.log("sending request to " + botUrl);
    botData = { "Name": botName, "Ip": botIp };
    var postData = JSON.stringify(botData);
    $.ajax({
        url: botUrl, contentType: "application/json", type: 'POST', data: postData, success:function(response) {
            console.log("result: " + response);
            if (response == "success") {
                console.log(response);
                location.reload();
            }
            else {
                var responseLoc = document.getElementById("responseBox");
                if (response == "duplicateBot") {
                    responseLoc.innerHTML = "bot Name or Ip already taken";
                } else if (response == "notConnected") {
                    responseLoc.innerHTML = "failed to connect to robot";
                } else if (response == "invalidIP") {
                    responseLoc.innerHTML = "invalid IP address";
                } else {
                    responseLoc.innerHTML = "an unknown error occurred";
                }
                responseLoc.style.display = "block";
            }
        }
    });
    console.log("bot add script complete");
}