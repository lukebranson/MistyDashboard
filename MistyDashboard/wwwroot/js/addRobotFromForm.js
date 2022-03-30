function addBot(botIP) {
    console.log("working");
    var botName = document.getElementById("nameInput").value;
    var botIp = document.getElementById("ipInput").value;
    var pageUrl = newURL(window.location.href);
    var hostName = pageUrl.hostname;
    botUrl = "http://" + hostname + "/api/AddRobot";
    botData = { "Name" : botName, "Ip" : botIp };
    $.post({
        url: botUrl, skillData, function(result) {
            if (result == "success") {
                console.log("success");
                //location.reload();
            }
        }
    });
}