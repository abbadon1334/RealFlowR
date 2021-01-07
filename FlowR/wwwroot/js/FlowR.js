var FlowR = /** @class */ (function () {
    /** @ts-ignore*/
    function FlowR(signalR, uri_path) {
        /** @ts-ignore */
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl(uri_path)
            //.withAutomaticReconnect()
            .configureLogging(signalR.LogLevel.Debug)
            .build();
        this.connection.on("OnInit", this.OnInit);
        this.connection.on("OnDisconnect", this.OnDisconnect);
        this.connection.on("CreateElement", this.CreateElement);
        this.connection.on("RemoveElement", this.RemoveElement);
        this.connection.on("SetAttribute", this.SetAttribute);
        this.connection.on("RemoveAttribute", this.RemoveAttribute);
        this.connection.on("StartListenEvent", this.StartListenEvent);
        this.connection.on("StopListenEvent", this.StopListenEvent);
        this.connection.on("SetText", this.SetText);
    }
    FlowR.prototype.TryConnect = function () {
        this.connection.start().catch(function (err) {
            console.error(err.toString());
        });
    };
    FlowR.prototype.OnInit = function (rootId) {
        console.log('init :' + rootId);
        this.rootId = rootId;
    };
    FlowR.prototype.OnDisconnect = function () {
        console.log('disconnect');
    };
    FlowR.prototype.CreateElement = function (parent_id, tag_name, attributes, text) {
        if (attributes === void 0) { attributes = []; }
        console.log('CreateElement', parent_id, tag_name, attributes, text);
        var el = document.createElement(tag_name);
        Object.keys(attributes).forEach(function (key) {
            el.setAttribute(key, attributes[key]);
        });
        el.innerText = text;
        document.getElementById(parent_id).appendChild(el);
    };
    FlowR.prototype.RemoveElement = function (uuid) {
        console.log('DestroyElement', uuid);
        document.getElementById(uuid).remove();
    };
    FlowR.prototype.SetAttribute = function (uuid, name, value) {
        console.log('setAttribute', uuid, name, value);
        document.getElementById(uuid).setAttribute(name, value);
    };
    FlowR.prototype.RemoveAttribute = function (uuid, name) {
        console.log('removeAttribute', uuid, name);
        document.getElementById(uuid).removeAttribute(name);
    };
    FlowR.prototype.StartListenEvent = function (uuid, event_name) {
        console.log('startListenEvent', uuid, event_name);
        document.getElementById(uuid).addEventListener(event_name, (function (event) {
            console.log(this.connection);
            this.connection.invoke("ClientEventTriggered", [
                uuid,
                event_name,
                event.target
            ]).catch(function (err) {
                return console.error(err.toString());
            });
        }).bind(this, false));
    };
    FlowR.prototype.StopListenEvent = function (uuid, event_name) {
    };
    FlowR.prototype.SetText = function (uuid, text) {
        document.getElementById(uuid).innerHTML = text;
    };
    return FlowR;
}());
//# sourceMappingURL=../../Typescript/wwwroot/js/FlowR.js.map