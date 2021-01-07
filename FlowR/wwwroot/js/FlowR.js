var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
var FlowR = /** @class */ (function () {
    function FlowR(conn) {
        this.connection = conn;
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
        document.getElementById(uuid).addEventListener(event_name, function (event) { return __awaiter(_this, void 0, void 0, function () {
            var err_1;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        _a.trys.push([0, 2, , 3]);
                        return [4 /*yield*/, this.connection.invoke("ClientEventTriggered", [
                                uuid,
                                event_name,
                                event.target
                            ])];
                    case 1:
                        _a.sent();
                        return [3 /*break*/, 3];
                    case 2:
                        err_1 = _a.sent();
                        return [2 /*return*/, console.error(err_1.toString())];
                    case 3: return [2 /*return*/];
                }
            });
        }); });
    };
    FlowR.prototype.StopListenEvent = function (uuid, event_name) {
    };
    FlowR.prototype.SetText = function (uuid, text) {
        document.getElementById(uuid).innerHTML = text;
    };
    return FlowR;
}());
//# sourceMappingURL=../../Typescript/wwwroot/js/FlowR.js.map