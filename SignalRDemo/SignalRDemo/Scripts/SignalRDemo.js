
$(function () {
    var timeQuery = $.connection.timeQuery;

    // Declare a function on the chat hub so the server can invoke it          
    timeQuery.client.addMessage = function (message) {
        $('#messages').empty();
        $('#messages').append('<li>' + message + '</li>');
    };

    // Start the connection
    $.connection.hub.start().done(function() {
        timeQuery.server.startTimer();
    });
});