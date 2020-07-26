$(document).ready(function () {

    var graph = new CanvasJS.Chart("AthleteStats", {

    });

});



function plotAthlete(data) {
    console.log(data);

    var trace = {
        x: data.xdate,
        y: data.y,
        mode: 'lines',
        type: 'scatter'
    };
}

function errorOnAjax() {
    console.log('whoops');
}