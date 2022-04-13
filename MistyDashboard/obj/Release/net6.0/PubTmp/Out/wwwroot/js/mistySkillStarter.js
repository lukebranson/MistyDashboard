function startMisty(botIP) {
    botUrl = "http://" + "10.12.132.44" + "/api/skills/start";
    skillData = { "skill" : "Dancing" };
    $.post({
        url: botUrl, skillData, function(result) {
            console.log(result);
        }
    });
    console.log("misty log complete");
}