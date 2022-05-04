//this function pulls data from the "Add Robot" form and makes an AJAX request to add the robot specified
function addBot() {
    //grab the name and ip adress from the form fields
    var botName = document.getElementById("nameInput").value;
    var botIp = document.getElementById("ipInput").value;
    //get the url of the page because this will have the same hostname to which we should send the api request
    var pageUrl = new URL(window.location.href);
    //pull the hostname form the url
    var hostName = pageUrl.hostname;
    //get the div where we will print response info
    var responseLoc = document.getElementById("responseBox");
    //build the api url
    apiUrl = window.location.protocol + "//" + hostName + ":" + pageUrl.port + "/api/AddRobot";
    //assemble the body data for the post request
    botData = { "Name": botName, "Ip": botIp };
    //turn the botData into a string so it can be passed in the AJAX function
    var postData = JSON.stringify(botData);
    //clear any previous messages
    responseLoc.innerHTML = "";
    //make the button look disabled
    document.getElementById("addBotButton").disabled = true;
    document.getElementById("addBotButton").style.opacity = "0.5";
    document.getElementById("addBotButton").innerHTML = "loading.";
    //the following animation makes the buttton say:
    //   loading.
    //   loading..
    //   loading...
    //and so on
    var dots = 1;
    var loadingAnimation = setInterval(function () {
        var buttonInnerHTML = "loading";
        for (i = -1; i < dots % 3; i++) {
            buttonInnerHTML += ".";
        }
        document.getElementById("addBotButton").innerHTML = buttonInnerHTML;
        dots++;
    }, 600);
    //now we make the actual ajax call with jquery
    $.ajax({
        url: apiUrl, contentType: "application/json", type: 'POST', data: postData, success:function(response) {
            console.log("result: " + response);
            //if it worked, refresh the page to show the new bot
            if (response == "success") {
                location.reload();
            }
            //otherwise, print the reponse to the responseLocation
            else {
                responseLoc.innerHTML = response;
                document.getElementById("addBotButton").disabled = false;
                document.getElementById("addBotButton").style.opacity = "1";
                clearInterval(loadingAnimation);
                document.getElementById("addBotButton").innerHTML = "add";
                responseLoc.style.display = "block";
            }
        }
    });
}