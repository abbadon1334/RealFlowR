
class FlowR {

    /** @ts-ignore */
    public connection: HubConnection;
    protected rootId: string;

    /** @ts-ignore*/
    constructor(signalR:signalR, uri_path: string) {

        /** @ts-ignore */
        this.connection = new signalR.HubConnectionBuilder()
            .withUrl(uri_path)
            //.withAutomaticReconnect()
            //.configureLogging(signalR.LogLevel.Debug)
            .build();


        this.connection.on("OnInit", this.OnInit);
        this.connection.on("OnDisconnect", this.OnDisconnect.bind(this));

        this.connection.on("CreateElement", this.CreateElement.bind(this));
        this.connection.on("RemoveElement", this.RemoveElement.bind(this));

        this.connection.on("SetAttribute", this.SetAttribute.bind(this));
        this.connection.on("RemoveAttribute", this.RemoveAttribute.bind(this));

        this.connection.on("StartListenEvent", this.StartListenEvent.bind(this));
        this.connection.on("StopListenEvent", this.StopListenEvent.bind(this));

        this.connection.on("SetText", this.SetText.bind(this));
    }

    GetConnection() {
        return this.connection;
    }

    TryConnect() {
        this.connection.start().catch(err => {
            console.error(err.toString())
        });
    }

    OnInit(rootId: string) {
        console.log('init :' + rootId);
        this.rootId = rootId;
    }

    OnDisconnect() {
        console.log('disconnect');
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
        var handler = (event, uuid, event_name) => {

            /** @ts-ignore */
            this.connection.invoke("ClientEventTriggered", JSON.stringify({ Uuid: uuid, EventName: event_name, EventArgs: { /*event: event*/ } })).catch(err => {
                return console.error(err.toString());
            });
        };

        document.getElementById(uuid).addEventListener(event_name, handler.bind(this, event, uuid, event_name));
    }

    StopListenEvent(uuid: string, event_name: string) {

    }

    SetText(uuid: string, text: string) {
        document.getElementById(uuid).innerHTML = text;
    }
}