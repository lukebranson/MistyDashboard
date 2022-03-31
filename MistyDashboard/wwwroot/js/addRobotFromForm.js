function addBot() {
    console.log("working");
    var botName = document.getElementById("nameInput").value;
    var botIp = document.getElementById("ipInput").value;
    var pageUrl = new URL(window.location.href);
    var hostName = pageUrl.hostname;
    botUrl = "http://" + hostName + "/api/AddRobot";
    console.log(botUrl);
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