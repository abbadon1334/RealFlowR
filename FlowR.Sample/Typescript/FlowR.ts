class FlowR {

    /** @ts-ignore */
    public connection: HubConnection;
    protected rootId: string;

    /** @ts-ignore*/
    constructor(signalR: signalR, uri_path: string) {

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

        this.connection.on("AddScriptWaitLoad", this.AddScriptWaitLoad.bind(this));
        this.connection.on("AddStylesheetWaitLoad", this.AddStylesheetWaitLoad.bind(this));

        this.connection.on("AddMethod", this.AddMethod.bind(this));
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

    public CreateElement(parent_id: string, tag_name: string, attributes = [], text: string) {

        console.log('CreateElement', parent_id, tag_name, attributes, text);

        let el = document.createElement(tag_name);
            el["flowr"] = this;

        Object.keys(attributes).forEach(function (key) {
            el.setAttribute(key, attributes[key]);
        })

        el.innerText = text;

        document.getElementById(parent_id).appendChild(el);
    }

    public RemoveElement(uuid: string) {

        console.log('DestroyElement', uuid);

        document.getElementById(uuid).remove();
    }

    public SetAttribute(uuid: string, name: string, value: string) {

        console.log('setAttribute', uuid, name, value);

        document.getElementById(uuid).setAttribute(name, value);
    }

    public RemoveAttribute(uuid: string, name: string) {

        console.log('removeAttribute', uuid, name);

        document.getElementById(uuid).removeAttribute(name);
    }

    public StartListenEvent(uuid: string, event_name: string) {

        console.log('startListenEvent', uuid, event_name);
        let handler = (uuid, event_name) => {
            /** @ts-ignore */
            this.connection.invoke(
                "ClientEventTriggered",
                JSON.stringify({Uuid: uuid, EventName: event_name, EventArgs: { /*event: event*/}})
            ).catch(err => {
                    return console.error(err.toString());
            });
        };

        document.getElementById(uuid).addEventListener(event_name, handler.bind(this, uuid, event_name));
    }

    public StopListenEvent(uuid: string, event_name: string) {
        // @todo
    }

    public SetText(uuid: string, text: string) {
        document.getElementById(uuid).innerHTML = text;
    }

    public SetProperty(uuid: string, property_path: string, value: string) {
        FlowR.ObjectPathBuilder(document.getElementById(uuid), property_path).Set(value);
    }

    public GetProperty(message_uuid: string, uuid: string, property_path: string): any {
        try {
            this.Invoke(
                message_uuid,
                FlowR.ObjectPathBuilder(document.getElementById(uuid), property_path).Get()
            );
        } catch (e) {
            console.log(e);
        }
    }

    private Invoke(message_uuid: string, response) {
        
        this.connection.invoke(
            "ClientMessageResponse",
            JSON.stringify({Uuid: message_uuid, Response: response})
        ).catch(err => {
            return console.error(err.toString());
        });
    }

    public CallMethod(uuid: string, method: string, ...args) {
        try {
            FlowR.ObjectPathBuilder(document.getElementById(uuid), method).Call(args);
        } catch (e) {
            console.log(e);
        }
    }

    public CallMethodGetResponse(message_uuid: string, uuid: string, method: string, ...args) {
        try {
            this.Invoke(
                message_uuid,
                this.CallMethod(uuid, method, ...args)
            );
        } catch (e) {
            console.log(e);
        }
    }

    public CallGlobalMethod(method: string, ...args) {
        try {
            FlowR.ObjectPathBuilder(window, method).Call(args)
        } catch (e) {
            console.log(e);
        }
    }

    public CallGlobalMethodGetResponse(message_uuid: string, path: string, ...args) {
        try {
            this.Invoke( message_uuid, FlowR.ObjectPathBuilder(window, path).Call(args));
        } catch (e) {
            console.log(e);
        }
    }
    /*
    this.connection.on("AddScriptWaitLoad", this.AddScriptWaitLoad.bind(this));
    this.connection.on("AddStylesheetWaitLoad", this.AddStylesheetWaitLoad.bind(this));
    */

    public AddScriptWaitLoad(message_uuid: string, url: string) {
        try {
            
            let s = document.createElement( 'script' );
            s.setAttribute( 'src', url );
            document.head.appendChild( s );
            
            this.Invoke( message_uuid, "done");
        } catch (e) {
            console.log(e);
        }
    }

    public AddStylesheetWaitLoad(message_uuid: string, url: string) {
        
        try {

            let s = document.createElement( 'link' );
            s.setAttribute( 'rel', 'stylesheet' );
            s.setAttribute( 'type', 'text/css' );
            s.setAttribute( 'href', url );
            document.head.appendChild( s );
            
            this.Invoke( message_uuid, "done");
        } catch (e) {
            console.log(e);
        }
    }

    public GetGlobalProperty(message_uuid: string, property_path: string): any {
        try {
            this.Invoke(message_uuid, FlowR.ObjectPathBuilder(window, property_path).Get());
        } catch (e) {
            console.log(e);
        }
    }

    public SetGlobalProperty(property_path: string, value: string) {
        try {
            FlowR.ObjectPathBuilder(window, property_path).Set(value);
        } catch (e) {
            console.log(e);
        }
    }

    public AddMethod(uuid:string, name:string, statement:string) {
        let obj = document.getElementById(uuid);
            obj[name] = new Function("return " + statement)();
    }

    public static AssertNotEmpty(str:string) {
        FlowR.AssertNotUndefinedNotNull(str);
        if (typeof(str) === "string" && str.length === 0) {
            throw "Not a string or Empty";
        }
    }

    public static AssertIsObject(obj) {
        if (typeof (obj) !== "object") {
            throw "Not an object";
        }
    }

    public static AssertIsFunction(obj) {
        if (typeof (obj) !== "function") {
            throw "Not an object";
        }
    }

    public static AssertNotUndefinedNotNull(obj) {
        if (obj === undefined || obj === null) {
            throw "Undefined or null";
        }
    }

    public static ObjectPathBuilder(obj: object, path: string) {

        // validate obj
        FlowR.AssertIsObject(obj);
        
        // validate path
        FlowR.AssertNotEmpty(path);

        // split the string by separator
        let path_chunks: string[] = path.split('.');

        // get last path
        // !!! value attribution - without last chunk - will replace the left side var
        let last_path_chunk: string = path_chunks.pop();

        // check if last chunk is consistent
        FlowR.AssertNotEmpty(last_path_chunk);

        let chunk : string;
        
        // traverse object
        while (chunk = path_chunks.shift()) {
            obj = obj[chunk];
            FlowR.AssertIsObject(obj);
        }
        
        return {
            Set(value): void {
                // don't check for undefined or null
                // it will set it and retrieve later, can be a feature :D 
                obj[last_path_chunk] = value;
            },
            Get(): string {
                // don't check for undefined or null
                // let it return null | undefined | "" | string @todo needs refactor
                return "" + obj[last_path_chunk];
            },
            Call(args) {
                // if undefined will throw exception better check before call
                FlowR.AssertNotUndefinedNotNull(obj[last_path_chunk]);
                // if not a function will throw a error
                FlowR.AssertIsFunction(obj[last_path_chunk]);
                return obj[last_path_chunk].apply(null, args);
            }
        }
    }
}