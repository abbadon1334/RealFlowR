interface HubConnection {
} // @todo find TS type signalr 

class FlowR {

    protected connection;
    protected rootId: string;

    constructor(conn: HubConnection) {

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

    TryConnect() {
        this.connection.start().then(() => {
            console.log('connected');
        }).catch(err => console.error(err.toString()));
    }

    OnInit(rootId: string) {
        console.log('init :' + rootId);
        this.rootId = rootId;
    }

    OnDisconnect() {
        console.log('disconnect');
    }
    
    CallWindowMethod(method: string, args: string[]) {
        console.log('CallWindowMethod', 'window', method, args);
        window[method].apply(null, args);
    }

    CallDocumentMethod(method: string, args: string[]) {
        console.log('CallDocumentMethod', method, args);
        document[method].apply(null, args);
    }

    CreateElement(parent_id: string, tag_name: string, attributes = [], text: string) {

        console.log('CreateElement', parent_id, tag_name, attributes, text);

        let el = document.createElement(tag_name);

        Object.keys(attributes).forEach(function (key) {
            el.setAttribute(key, attributes[key]);
        })

        el.innerText = text;

        document.getElementById(parent_id).appendChild(el);
    }

    RemoveElement(uuid: string) {

        console.log('DestroyElement', uuid);

        document.getElementById(uuid).remove();
    }

    SetAttribute(uuid: string, name: string, value: string) {

        console.log('setAttribute', uuid, name, value);

        document.getElementById(uuid).setAttribute(name, value);
    }

    RemoveAttribute(uuid: string, name: string) {

        console.log('removeAttribute', uuid, name);

        document.getElementById(uuid).removeAttribute(name);
    }

    StartListenEvent(uuid: string, event_name: string) {

        console.log('startListenEvent', uuid, event_name);
        
        document.getElementById(uuid).addEventListener(event_name, (event) => {
                this.connection.invoke("ClientEventTriggered", [
                    uuid,
                    event_name,
                    event.target
                ])
                .catch(function (err) {
                    return console.error(err.toString());
                });
            }
        );
    }

    StopListenEvent(uuid: string, event_name: string) {

    }
}