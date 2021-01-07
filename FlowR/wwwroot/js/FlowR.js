var FlowR = /** @class */ (function () {
    function FlowR(conn) {
        this.connection = conn;
        this.connection.on("OnInit", this.OnInit);
        this.connection.on("OnDisconnect", this.OnDisconnect);
        this.connection.on("CallWindowMethod", this.CallWindowMethod);
        this.connection.on("CallDocumentMethod", this.CallDocumentMethod);
        this.connection.on("CreateElement", this.CreateElement);
        this.connection.on("RemoveElement", this.RemoveElement);
        this.connection.on("SetAttribute", this.SetAttribute);
        this.connection.on("RemoveAttribute", this.RemoveAttribute);
        this.connection.on("StartListenEvent", this.StartListenEvent);
        this.connection.on("StopListenEvent", this.StopListenEvent);
    }
    FlowR.prototype.GetConnection = function () { return this.connection; };
    FlowR.prototype.TryConnect = function () {
        this.connection.start().then(function () {
            console.log('connected');
        }).catch(function (err) { return console.error(err.toString()); });
    };
    FlowR.prototype.OnInit = function (rootId) {
        console.log('init :' + rootId);
        this.rootId = rootId;
    };
    FlowR.prototype.OnDisconnect = function () {
        console.log('disconnect');
    };
    /*
        OnTimer(timer: string, data = []) {
            console.log('OnTimerEnd', timer, data);
        }
    */
    FlowR.prototype.CallWindowMethod = function (method, args) {
        console.log('CallWindowMethod', 'window', method, args);
        window[method].apply(null, args);
    };
    FlowR.prototype.CallDocumentMethod = function (method, args) {
        console.log('CallDocumentMethod', method, args);
        document[method].apply(null, args);
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
        var _this = this;
        console.log('startListenEvent', uuid, event_name);
        document.getElementById(uuid).addEventListener(event_name, function (event) {
            _this.GetConnection().invoke("ClientEventTriggered", [
                uuid,
                event_name,
                event.target
            ])
                .catch(function (err) {
                return console.error(err.toString());
            });
        });
    };
    FlowR.prototype.StopListenEvent = function (uuid, event_name) {
    };
    return FlowR;
}());
//# sourceMappingURL=FlowR.js.map