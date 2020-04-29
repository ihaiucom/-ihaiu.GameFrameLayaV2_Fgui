declare module excelconfig {
	 interface IDTItemNum {
	    ItemId?: (number|null);
	    ItemNum?: (number|null);
	}
	 class DTItemNum implements IDTItemNum {
	    constructor(properties?: IDTItemNum);
	    public ItemId: number;
	    public ItemNum: number;
	    public static create(properties?: IDTItemNum): DTItemNum;
	    public static encode(message: IDTItemNum, writer?: $protobuf.Writer): $protobuf.Writer;
	    public static encodeDelimited(message: IDTItemNum, writer?: $protobuf.Writer): $protobuf.Writer;
	    public static decode(reader: ($protobuf.Reader|Uint8Array), length?: number): DTItemNum;
	    public static decodeDelimited(reader: ($protobuf.Reader|Uint8Array)): DTItemNum;
	    public static verify(message: { [k: string]: any }): (string|null);
	    public static fromObject(object: { [k: string]: any }): DTItemNum;
	    public static toObject(message: DTItemNum, options?: $protobuf.IConversionOptions): { [k: string]: any };
	    public toJSON(): { [k: string]: any };
	}
	 interface IDTVector2 {
	    X?: (number|null);
	    Y?: (number|null);
	}
	 class DTVector2 implements IDTVector2 {
	    constructor(properties?: IDTVector2);
	    public X: number;
	    public Y: number;
	    public static create(properties?: IDTVector2): DTVector2;
	    public static encode(message: IDTVector2, writer?: $protobuf.Writer): $protobuf.Writer;
	    public static encodeDelimited(message: IDTVector2, writer?: $protobuf.Writer): $protobuf.Writer;
	    public static decode(reader: ($protobuf.Reader|Uint8Array), length?: number): DTVector2;
	    public static decodeDelimited(reader: ($protobuf.Reader|Uint8Array)): DTVector2;
	    public static verify(message: { [k: string]: any }): (string|null);
	    public static fromObject(object: { [k: string]: any }): DTVector2;
	    public static toObject(message: DTVector2, options?: $protobuf.IConversionOptions): { [k: string]: any };
	    public toJSON(): { [k: string]: any };
	}
	 interface IGlobal {
	    everydayUpdateTime?: (number|null);
	    roleNameAutoGen?: (string|null);
	    roleNameMaxLength?: (number|null);
	    roleNameMinLength?: (number|null);
	    superAccountSwitch?: (boolean|null);
	    roleNameRepated?: (boolean|null);
	    friendReqMaxCnt?: (number|null);
	    friendMaxCnt?: (number|null);
	    chatGamerMaxCnt?: (number|null);
	    chatWorldMaxCnt?: (number|null);
	    gamerMailMaxCnt?: (number|null);
	    worldMailMaxCnt?: (number|null);
	    wordCheck?: (boolean|null);
	}
	 class Global implements IGlobal {
	    constructor(properties?: IGlobal);
	    public everydayUpdateTime: number;
	    public roleNameAutoGen: string;
	    public roleNameMaxLength: number;
	    public roleNameMinLength: number;
	    public superAccountSwitch: boolean;
	    public roleNameRepated: boolean;
	    public friendReqMaxCnt: number;
	    public friendMaxCnt: number;
	    public chatGamerMaxCnt: number;
	    public chatWorldMaxCnt: number;
	    public gamerMailMaxCnt: number;
	    public worldMailMaxCnt: number;
	    public wordCheck: boolean;
	    public static create(properties?: IGlobal): Global;
	    public static encode(message: IGlobal, writer?: $protobuf.Writer): $protobuf.Writer;
	    public static encodeDelimited(message: IGlobal, writer?: $protobuf.Writer): $protobuf.Writer;
	    public static decode(reader: ($protobuf.Reader|Uint8Array), length?: number): Global;
	    public static decodeDelimited(reader: ($protobuf.Reader|Uint8Array)): Global;
	    public static verify(message: { [k: string]: any }): (string|null);
	    public static fromObject(object: { [k: string]: any }): Global;
	    public static toObject(message: Global, options?: $protobuf.IConversionOptions): { [k: string]: any };
	    public toJSON(): { [k: string]: any };
	}
	 interface ILoader {
	    id?: (number|null);
	    name?: (string|null);
	    isShowCircle?: (boolean|null);
	}
	 class Loader implements ILoader {
	    constructor(properties?: ILoader);
	    public id: number;
	    public name: string;
	    public isShowCircle: boolean;
	    public static create(properties?: ILoader): Loader;
	    public static encode(message: ILoader, writer?: $protobuf.Writer): $protobuf.Writer;
	    public static encodeDelimited(message: ILoader, writer?: $protobuf.Writer): $protobuf.Writer;
	    public static decode(reader: ($protobuf.Reader|Uint8Array), length?: number): Loader;
	    public static decodeDelimited(reader: ($protobuf.Reader|Uint8Array)): Loader;
	    public static verify(message: { [k: string]: any }): (string|null);
	    public static fromObject(object: { [k: string]: any }): Loader;
	    public static toObject(message: Loader, options?: $protobuf.IConversionOptions): { [k: string]: any };
	    public toJSON(): { [k: string]: any };
	}
	 interface IMenu {
	    id?: (number|null);
	    zhCnName?: (string|null);
	    icon?: (string|null);
	    moduleNameIcon?: (string|null);
	    moduleName?: (string|null);
	    layer?: (number|null);
	    topInformation?: (number[]|null);
	    closeOtherType?: (number|null);
	    closeHomeWindow?: (boolean|null);
	    isAutoOpenHomeWindow?: (boolean|null);
	    cacheTime?: (number|null);
	    loaderId?: (number|null);
	    barType?: (number|null);
	    barIndex?: (number|null);
	    openAnimation?: (number|null);
	    closeAnimation?: (number|null);
	    redType?: (number|null);
	}
	 class Menu implements IMenu {
	    constructor(properties?: IMenu);
	    public id: number;
	    public zhCnName: string;
	    public icon: string;
	    public moduleNameIcon: string;
	    public moduleName: string;
	    public layer: number;
	    public topInformation: number[];
	    public closeOtherType: number;
	    public closeHomeWindow: boolean;
	    public isAutoOpenHomeWindow: boolean;
	    public cacheTime: number;
	    public loaderId: number;
	    public barType: number;
	    public barIndex: number;
	    public openAnimation: number;
	    public closeAnimation: number;
	    public redType: number;
	    public static create(properties?: IMenu): Menu;
	    public static encode(message: IMenu, writer?: $protobuf.Writer): $protobuf.Writer;
	    public static encodeDelimited(message: IMenu, writer?: $protobuf.Writer): $protobuf.Writer;
	    public static decode(reader: ($protobuf.Reader|Uint8Array), length?: number): Menu;
	    public static decodeDelimited(reader: ($protobuf.Reader|Uint8Array)): Menu;
	    public static verify(message: { [k: string]: any }): (string|null);
	    public static fromObject(object: { [k: string]: any }): Menu;
	    public static toObject(message: Menu, options?: $protobuf.IConversionOptions): { [k: string]: any };
	    public toJSON(): { [k: string]: any };
	}
	 interface IMsg {
	    id?: (number|null);
	    key?: (string|null);
	    module?: (string|null);
	    name?: (string|null);
	    zhCnNotice?: (string|null);
	    enNotice?: (string|null);
	}
	 class Msg implements IMsg {
	    constructor(properties?: IMsg);
	    public id: number;
	    public key: string;
	    public module: string;
	    public name: string;
	    public zhCnNotice: string;
	    public enNotice: string;
	    public static create(properties?: IMsg): Msg;
	    public static encode(message: IMsg, writer?: $protobuf.Writer): $protobuf.Writer;
	    public static encodeDelimited(message: IMsg, writer?: $protobuf.Writer): $protobuf.Writer;
	    public static decode(reader: ($protobuf.Reader|Uint8Array), length?: number): Msg;
	    public static decodeDelimited(reader: ($protobuf.Reader|Uint8Array)): Msg;
	    public static verify(message: { [k: string]: any }): (string|null);
	    public static fromObject(object: { [k: string]: any }): Msg;
	    public static toObject(message: Msg, options?: $protobuf.IConversionOptions): { [k: string]: any };
	    public toJSON(): { [k: string]: any };
	}
	 interface IUnlock {
	    id?: (number|null);
	    zhCnName?: (string|null);
	    menuId?: (number|null);
	    menuIndexId?: (number|null);
	    showType?: (number|null);
	    showLevel?: (number|null);
	    openLevel?: (number|null);
	    checkPoint?: (number|null);
	    openShow?: (number|null);
	    showIcon?: (number|null);
	}
	 class Unlock implements IUnlock {
	    constructor(properties?: IUnlock);
	    public id: number;
	    public zhCnName: string;
	    public menuId: number;
	    public menuIndexId: number;
	    public showType: number;
	    public showLevel: number;
	    public openLevel: number;
	    public checkPoint: number;
	    public openShow: number;
	    public showIcon: number;
	    public static create(properties?: IUnlock): Unlock;
	    public static encode(message: IUnlock, writer?: $protobuf.Writer): $protobuf.Writer;
	    public static encodeDelimited(message: IUnlock, writer?: $protobuf.Writer): $protobuf.Writer;
	    public static decode(reader: ($protobuf.Reader|Uint8Array), length?: number): Unlock;
	    public static decodeDelimited(reader: ($protobuf.Reader|Uint8Array)): Unlock;
	    public static verify(message: { [k: string]: any }): (string|null);
	    public static fromObject(object: { [k: string]: any }): Unlock;
	    public static toObject(message: Unlock, options?: $protobuf.IConversionOptions): { [k: string]: any };
	    public toJSON(): { [k: string]: any };
	}
	 interface IConfigMng {
	    Global?: (IGlobal|null);
	    Loader?: ({ [k: string]: ILoader }|null);
	    Menu?: ({ [k: string]: IMenu }|null);
	    Msg?: ({ [k: string]: IMsg }|null);
	    Unlock?: ({ [k: string]: IUnlock }|null);
	}
	 class ConfigMng implements IConfigMng {
	    constructor(properties?: IConfigMng);
	    public Global?: (IGlobal|null);
	    public Loader: { [k: string]: ILoader };
	    public Menu: { [k: string]: IMenu };
	    public Msg: { [k: string]: IMsg };
	    public Unlock: { [k: string]: IUnlock };
	    public static create(properties?: IConfigMng): ConfigMng;
	    public static encode(message: IConfigMng, writer?: $protobuf.Writer): $protobuf.Writer;
	    public static encodeDelimited(message: IConfigMng, writer?: $protobuf.Writer): $protobuf.Writer;
	    public static decode(reader: ($protobuf.Reader|Uint8Array), length?: number): ConfigMng;
	    public static decodeDelimited(reader: ($protobuf.Reader|Uint8Array)): ConfigMng;
	    public static verify(message: { [k: string]: any }): (string|null);
	    public static fromObject(object: { [k: string]: any }): ConfigMng;
	    public static toObject(message: ConfigMng, options?: $protobuf.IConversionOptions): { [k: string]: any };
	    public toJSON(): { [k: string]: any };
	}
}
