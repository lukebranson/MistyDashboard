function addBot() {
    //console.log("adding robot...")
    var botName = document.getElementById("nameInput").value;
    var botIp = document.getElementById("ipInput").value;
    var pageUrl = new URL(window.location.href);
    var hostName = pageUrl.hostname;
    var responseLoc = document.getElementById("responseBox");
    apiUrl = window.location.protocol + "//" + hostName + ":" + pageUrl.port + "/api/AddRobot";
    //console.log("sending request to " + apiUrl);
    botData = { "Name": botName, "Ip": botIp };
    var postData = JSON.stringify(botData);
    responseLoc.innerHTML = "";
    document.getElementById("addBotButton").disabled = true;
    document.getElementById("addBotButton").style.opacity = "0.5";
    document.getElementById("addBotButton").innerHTML = "loading.";
    var dots = 1;
    var loadingAnimation = setInterval(function () {
        var buttonInnerHTML = "loading";
        for (i = -1; i < dots % 3; i++) {
            buttonInnerHTML += ".";
        }
        document.getElementById("addBotButton").innerHTML = buttonInnerHTML;
        dots++;
    }, 600);
    $.ajax({
        url: apiUrl, contentType: "application/json", type: 'POST', data: postData, success:function(response) {
            console.log("result: " + response);
            if (response == "success") {
                //console.log(response);
                location.reload();
            }
            else {
                if (response == "duplicateBot") {
                    responseLoc.innerHTML = "bot Name or Ip already taken";
                } else if (response == "notConnected") {
                    responseLoc.innerHTML = "failed to connect to robot";
                } else if (response == "invalidIP") {
                    responseLoc.innerHTML = "invalid IP address";
                } else if (response == "notMisty") {
                    responseLoc.innerHTML = "IP address does not belong to a Misty Bot";
                }
                else {
                    responseLoc.innerHTML = "an unknown error occurred";
                }
                document.getElementById("addBotButton").disabled = false;
                document.getElementById("addBotButton").style.opacity = "1";
                clearInterval(loadingAnimation);
                document.getElementById("addBotButton").innerHTML = "add";
                responseLoc.style.display = "block";
            }
        }
    });
    console.log("bot add script complete");
}