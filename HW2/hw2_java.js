

$(document).ready(function () { // makes page wait to run scripts until fully loaded. 

    $('#logBook').on("submit", function (event) {
        
        event.preventDefault();
        var table = $('#booksRead');
        
        var inputTitle = $('#title').val();
        var inputAuthor = $('#author').val();
        var tableVar = table.get(0);

        var row = $("<tr><td class=\"bottomBorder\">" + inputTitle + "</td><td class=\"bottomBorder\">" + inputAuthor + "</td></tr>");
        table.append(row);
        $('#logBook').trigger("reset");
    });
    });    

