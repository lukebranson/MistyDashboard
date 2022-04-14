function startMisty(botIP) {
    botUrl = "http://" + "10.12.132.44" + "/api/skills/start?skill=98716077-e2af-4a57-8cfb-59228f65c1bb";
    skillData = { "skill": "98716077-e2af-4a57-8cfb-59228f65c1bb", "method":null };
    var postData = JSON.stringify(skillData);
    $.post({
        url: botUrl, skillData, function(result) {
            console.log(result);
        }
    });
    console.log("misty log complete");
}