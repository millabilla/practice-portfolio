$(document).ready(function () {

    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Home/GitInfo",
        success: displayUser,
        error: errorFunc
    });

    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Home/GitRepos",
        success: displayRepos,
        error: errorFunc
    });


});


function displayUser(jsonObj) {
    console.log(jsonObj);
    $("#picture").append('<img src="' + jsonObj.photo + '" style="width: 200px; height: 200px;"/>');
    $("#name").append(jsonObj.name);
    $("#username").append(jsonObj.username);
    $("#email").append(jsonObj.email);
    $("#location").append(jsonObj.loc);
    $("#company").append(jsonObj.comp);

}

function displayRepos(repoList) {
    console.log(repoList);
    
    for (i in Object.keys(repoList)) {
        //<a class="w3-btn w3-disabled" href="https://www.w3schools.com">Link Button</a>
        $('<h4><a href="https://github.com/' + repoList[i].owner + '/' + repoList[i].repo + '">' + repoList[i].repo + '</a>').appendTo('#repotiles');
        $('<div class="thumbnail"><img src="' + repoList[i].avatar + '"/>').appendTo($('#repotiles'));
        $('<p>').append('owner: ' + repoList[i].owner).appendTo($('#repotiles'));
        $('<p>').append('last edited: ' + repoList[i].editedAt).appendTo($('#repotiles'));
        $('<p><a href="' + repoList[i].commits + '" class="btn btn-primary"> Commits</a>').appendTo($('#repotiles'));

        //<p><a href="" class="btn btn-primary btn-lg">Week 5 Assignment &raquo;</a></p>
        
    }
}

function errorFunc() {
    console.log("whoops");
}
