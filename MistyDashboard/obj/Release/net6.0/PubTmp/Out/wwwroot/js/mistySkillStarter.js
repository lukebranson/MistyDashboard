function startMisty(botIP) {
    botUrl = "http://" + botIP + "/api/skills/start";
    skillData = { "Skill" : "Hello World" };
    $.post({
        url: botUrl, skillData, function(result) {
            console.log(result);
        }
    });
    console.log("misty log complete");
}