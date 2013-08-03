
$(function () {
    var chat = $.connection.chat;

    // Declare a function on the chat hub so the server can invoke it          
    chat.client.addMessage = function (message) {
        $('#messages').empty();
        $('#messages').append('<li>' + message + '</li>');
    };

    // Start the connection
    $.connection.hub.start().done(function() {
        chat.server.sayHello();
    });

});