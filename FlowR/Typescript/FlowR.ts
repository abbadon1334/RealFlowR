
class FlowR {

    /** @ts-ignore */
    public connection : HubConnection;
    protected rootId: string;

    /** @ts-ignore*/
    constructor(signalR:signalR, uri_path: string) {

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
        
        document.getElementById(uuid).addEventListener(event_name, (function (event) {

            console.log(this.connection);

            this.connection.invoke("ClientEventTriggered", [
                uuid,
                event_name,
                event.target
            ]).catch(err => {
                return console.error(err.toString());
            });

        }).bind(this,false));
    }

    StopListenEvent(uuid: string, event_name: string) {

    }

    SetText(uuid: string, text: string) {
        document.getElementById(uuid).innerHTML = text;
    }
}