"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/flowr").build();

// Application Events
connection.on("OnInit", function (rootId) {
    console.log('ElementRootID : ' + rootId);    
});

connection.on("OnDisconnect", function (rootId) {
    console.log('disconnect' + rootId);
});

connection.on("window", function (action, data) {

});

connection.on("document", function (action, data) {

});

connection.on("CallElementAction", function (action, data) {
    switch(action) {
        case "create":
            data = {
                parent_id : data[0],
                tag : data[1],
                attributes : data[2],
                text : data[3]
            }
            let el = document.createElement(data.tag);
            Object.keys(data.attributes).forEach(function(key) {
                el.setAttribute(key,data.attributes[key]);
            })
            el.innerText = data.text;
            document.getElementById(data.parent_id).appendChild(el);
            break;
        case "setAttribute":
            document.getElementById(data[0]).setAttribute(data[1], data[2]);
            break;
        case "removeAttribute":
            document.getElementById(parent_id).removeAttribute(data[0]);
            break;
        case "setText":
            document.getElementById(data[0]).innerText = data[1];
            break;
        case "remove":
            document.getElementById(data[0]).remove();
            break;
        case "eventOn":
            document.getElementById(data[0]).addEventListener(data[1], (event) => {
                connection
                    .invoke("ClientEventTriggered", [
                        data[0],
                        data[1],
                        event.target
                    ])
                    .catch(function (err) {
                        return console.error(err.toString());
                    });

                event.preventDefault();
            })
            break;
    }
});

connection.on("OnTimer", function (data) {
    console.log(data);
});

connection.start().then(function () {
    
}).catch(function (err) {
    return console.error(err.toString());
});