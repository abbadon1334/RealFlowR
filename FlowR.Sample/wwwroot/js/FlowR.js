class FlowR {
    /** @ts-ignore*/
    constructor(signalR, uri_path) {
        /** @ts-ignore */
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl(uri_path)
            //.withAutomaticReconnect()
            //.configureLogging(signalR.LogLevel.Debug)
            .build();
        this.connection.on("OnInit", this.OnInit.bind(this));
        this.connection.on("OnDisconnect", this.OnDisconnect.bind(this));
        this.connection.on("CreateElement", this.CreateElement.bind(this));
        this.connection.on("RemoveElement", this.RemoveElement.bind(this));
        this.connection.on("SetAttribute", this.SetAttribute.bind(this));
        this.connection.on("RemoveAttribute", this.RemoveAttribute.bind(this));
        this.connection.on("StartListenEvent", this.StartListenEvent.bind(this));
        this.connection.on("StopListenEvent", this.StopListenEvent.bind(this));
        this.connection.on("SetText", this.SetText.bind(this));
        this.connection.on("SetProperty", this.SetProperty.bind(this));
        this.connection.on("SetGlobalProperty", this.SetGlobalProperty.bind(this));
        this.connection.on("GetProperty", this.GetProperty.bind(this));
        this.connection.on("GetGlobalProperty", this.GetGlobalProperty.bind(this));
        this.connection.on("CallElementMethod", this.CallMethod.bind(this));
        this.connection.on("CallElementMethodGetResponse", this.CallMethodGetResponse.bind(this));
        this.connection.on("CallGlobalMethod", this.CallGlobalMethod.bind(this));
        this.connection.on("CallGlobalMethodGetResponse", this.CallGlobalMethodGetResponse.bind(this));
    }
    TryConnect() {
        this.connection.start().catch(err => {
            console.error(err.toString());
        });
    }
    OnInit(rootId) {
        console.log('init :' + rootId);
        this.rootId = rootId;
    }
    OnDisconnect() {
        console.log('disconnect');
    }
    CreateElement(parent_id, tag_name, attributes = [], text) {
        console.log('CreateElement', parent_id, tag_name, attributes, text);
        let el = document.createElement(tag_name);
        Object.keys(attributes).forEach(function (key) {
            el.setAttribute(key, attributes[key]);
        });
        el.innerText = text;
        document.getElementById(parent_id).appendChild(el);
    }
    RemoveElement(uuid) {
        console.log('DestroyElement', uuid);
        document.getElementById(uuid).remove();
    }
    SetAttribute(uuid, name, value) {
        console.log('setAttribute', uuid, name, value);
        document.getElementById(uuid).setAttribute(name, value);
    }
    RemoveAttribute(uuid, name) {
        console.log('removeAttribute', uuid, name);
        document.getElementById(uuid).removeAttribute(name);
    }
    StartListenEvent(uuid, event_name) {
        console.log('startListenEvent', uuid, event_name);
        var handler = (uuid, event_name) => {
            /** @ts-ignore */
            this.connection.invoke("ClientEventTriggered", JSON.stringify({ Uuid: uuid, EventName: event_name, EventArgs: { /*event: event*/} })).catch(err => {
                return console.error(err.toString());
            });
        };
        document.getElementById(uuid).addEventListener(event_name, handler.bind(this, uuid, event_name));
    }
    StopListenEvent(uuid, event_name) {
    }
    SetText(uuid, text) {
        document.getElementById(uuid).innerHTML = text;
    }
    SetProperty(uuid, property_path, value) {
        FlowR.ObjectPathBuilder(document.getElementById(uuid), property_path).Set(value);
    }
    GetProperty(message_uuid, uuid, property_path) {
        try {
            this.Invoke(message_uuid, FlowR.ObjectPathBuilder(document.getElementById(uuid), property_path).Get());
        }
        catch (e) {
            console.log(e);
        }
    }
    Invoke(message_uuid, response) {
        this.connection.invoke("ClientMessageResponse", JSON.stringify({ Uuid: message_uuid, Response: response })).catch(err => {
            return console.error(err.toString());
        });
    }
    CallMethod(uuid, method, ...args) {
        try {
            FlowR.ObjectPathBuilder(document.getElementById(uuid), method).Call(...args);
        }
        catch (e) {
            console.log(e);
        }
    }
    CallMethodGetResponse(message_uuid, uuid, method, ...args) {
        try {
            this.Invoke(message_uuid, this.CallMethod(uuid, method, ...args));
        }
        catch (e) {
            console.log(e);
        }
    }
    CallGlobalMethod(method, ...args) {
        try {
            FlowR.ObjectPathBuilder(window, method).Call(...args);
        }
        catch (e) {
            console.log(e);
        }
    }
    CallGlobalMethodGetResponse(message_uuid, path, ...args) {
        try {
            this.Invoke(message_uuid, FlowR.ObjectPathBuilder(window, path).Call(...args));
        }
        catch (e) {
            console.log(e);
        }
    }
    GetGlobalProperty(message_uuid, property_path) {
        try {
            this.Invoke(message_uuid, FlowR.ObjectPathBuilder(window, property_path).Get());
        }
        catch (e) {
            console.log(e);
        }
    }
    SetGlobalProperty(property_path, value) {
        try {
            FlowR.ObjectPathBuilder(window, property_path).Set(value);
        }
        catch (e) {
            console.log(e);
        }
    }
    static AssertNotEmpty(str) {
        FlowR.AssertNotUndefinedNotNull(str);
        if (typeof (str) === "string" && str.length === 0) {
            throw "Not a string or Empty";
        }
    }
    static AssertIsObject(obj) {
        if (typeof (obj) !== "object") {
            throw "Not an object";
        }
    }
    static AssertIsFunction(obj) {
        if (typeof (obj) !== "function") {
            throw "Not an object";
        }
    }
    static AssertNotUndefinedNotNull(obj) {
        if (obj === undefined || obj === null) {
            throw "Undefined or null";
        }
    }
    static ObjectPathBuilder(obj, path) {
        // validate obj
        FlowR.AssertIsObject(obj);
        // validate path
        FlowR.AssertNotEmpty(path);
        // split the string by separator
        let path_chunks = path.split('.');
        // traverse object
        // stop before last
        while (path_chunks.length > 1) {
            obj = obj[path_chunks.shift()];
            FlowR.AssertIsObject(obj);
        }
        // get last path
        // !!! value attribution - without last chunk - will replace the left side var
        let last_path_chunk = path_chunks[0];
        // check if last chunk is consistent
        FlowR.AssertNotEmpty(last_path_chunk);
        return {
            Set(value) {
                // don't check for undefined or null
                // it will set it and retrieve later, can be a feature :D 
                obj[last_path_chunk] = value;
            },
            Get() {
                // don't check for undefined or null
                // let it return undefined @todo check if is ok
                return obj[last_path_chunk];
            },
            Call(...args) {
                // if undefined will throw exception better check before call
                FlowR.AssertNotUndefinedNotNull(obj[last_path_chunk]);
                // if not a function will throw a error
                FlowR.AssertIsFunction(obj[last_path_chunk]);
                return obj[last_path_chunk](...args);
            }
        };
    }
}
//# sourceMappingURL=../../Typescript/wwwroot/js/FlowR.js.map