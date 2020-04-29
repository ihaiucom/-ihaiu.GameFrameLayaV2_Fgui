(function () {
    'use strict';

    var REG = Laya.ClassUtils.regClass;
    var ui;
    (function (ui) {
        var test;
        (function (test) {
            class TestSceneUI extends Laya.Scene {
                constructor() { super(); }
                createChildren() {
                    super.createChildren();
                    this.loadScene("test/TestScene");
                }
            }
            test.TestSceneUI = TestSceneUI;
            REG("ui.test.TestSceneUI", TestSceneUI);
        })(test = ui.test || (ui.test = {}));
    })(ui || (ui = {}));

    class GameUI extends ui.test.TestSceneUI {
        constructor() {
            super();
            var scene = Laya.stage.addChild(new Laya.Scene3D());
            var camera = (scene.addChild(new Laya.Camera(0, 0.1, 100)));
            camera.transform.translate(new Laya.Vector3(0, 3, 3));
            camera.transform.rotate(new Laya.Vector3(-30, 0, 0), true, false);
            var directionLight = scene.addChild(new Laya.DirectionLight());
            directionLight.color = new Laya.Vector3(0.6, 0.6, 0.6);
            directionLight.transform.worldMatrix.setForward(new Laya.Vector3(1, -1, 0));
            var box = scene.addChild(new Laya.MeshSprite3D(Laya.PrimitiveMesh.createBox(1, 1, 1)));
            box.transform.rotate(new Laya.Vector3(0, 45, 0), false, false);
            var material = new Laya.BlinnPhongMaterial();
            Laya.Texture2D.load("res/layabox.png", Laya.Handler.create(null, function (tex) {
                material.albedoTexture = tex;
            }));
            box.meshRenderer.material = material;
        }
    }

    class GameConfig {
        constructor() {
        }
        static init() {
            var reg = Laya.ClassUtils.regClass;
            reg("script/GameUI.ts", GameUI);
        }
    }
    GameConfig.width = 640;
    GameConfig.height = 1136;
    GameConfig.scaleMode = "fixedwidth";
    GameConfig.screenMode = "none";
    GameConfig.alignV = "top";
    GameConfig.alignH = "left";
    GameConfig.startScene = "test/TestScene.scene";
    GameConfig.sceneRoot = "";
    GameConfig.debug = false;
    GameConfig.stat = false;
    GameConfig.physicsDebug = false;
    GameConfig.exportSceneToJson = true;
    GameConfig.init();

    var Loader = Laya.Loader;
    class GuiResPackageConfig {
        constructor() {
            this.resAtlas = [];
            this.sounds = [];
        }
        get loadList() {
            if (!this._loadList) {
                let list = [];
                list.push({ url: GuiSetting.getResPath(this.resBin, this.resDir), type: Loader.BUFFER });
                if (this.resAtlas) {
                    for (let i = 0; i < this.resAtlas.length; i++) {
                        list.push({ url: GuiSetting.getResPath(this.resAtlas[i], this.resDir), type: Loader.IMAGE });
                    }
                }
                if (this.sounds) {
                    for (let i = 0; i < this.sounds.length; i++) {
                        list.push({ url: GuiSetting.getResPath(this.sounds[i], this.resDir), type: Loader.SOUND });
                    }
                }
                this._loadList = list;
            }
            return this._loadList;
        }
        get packagePath() {
            return GuiSetting.getResPackagePath(this.packageName, this.resDir);
        }
    }

    class GuiResPackageConfigReader {
        constructor() {
            this.dict = new Map();
        }
        addconfig(config) {
            this.dict.set(config.packageName, config);
        }
        getconfig(packageName) {
            return this.dict.get(packageName);
        }
        install() {
            let config;
            config = new GuiResPackageConfig();
            config.resDir = "fgui";
            config.packageName = "Effect_1001_Dianguanglongqi_Skin1__Skill4_13";
            config.resBin = "Effect_1001_Dianguanglongqi_Skin1__Skill4_13.bin";
            config.resAtlas.push("Effect_1001_Dianguanglongqi_Skin1__Skill4_13_atlas0.png");
            this.addconfig(config);
            config = new GuiResPackageConfig();
            config.resDir = "fgui";
            config.packageName = "GameGM";
            config.resBin = "GameGM.bin";
            this.addconfig(config);
            config = new GuiResPackageConfig();
            config.resDir = "fgui";
            config.packageName = "GameLaunch";
            config.resBin = "GameLaunch.bin";
            config.resAtlas.push("GameLaunch_atlas0.png");
            config.resAtlas.push("GameLaunch_atlas_9wtpw2k.png");
            config.resAtlas.push("GameLaunch_atlas_qyvzw2s.png");
            config.resAtlas.push("GameLaunch_atlas_tilsw3o.png");
            config.resAtlas.push("GameLaunch_atlas_tnlhw30.png");
            config.resAtlas.push("GameLaunch_atlas_tnlhw32.png");
            config.resAtlas.push("GameLaunch_atlas_tnlhw34.png");
            config.resAtlas.push("GameLaunch_atlas_tnlhw35.png");
            config.resAtlas.push("GameLaunch_atlas_tnlhw3c.png");
            config.resAtlas.push("GameLaunch_atlas_tnlhw3m.png");
            this.addconfig(config);
        }
    }

    class SpriteResPackageConfigReader {
        constructor() {
            this.dict = new Map();
        }
        addconfig(config) {
            this.dict.set(config.packageName, config);
        }
        getconfig(packageName) {
            return this.dict.get(packageName);
        }
        install() {
            let config;
        }
    }

    class FGLoader extends fgui.GLoader {
        static get freeList() {
            if (FGLoader._freeList.length > 0) {
                FGLoader._freeList.length = 0;
            }
            FGLoader.freeDictForNum.forEach((val, url) => {
                if (FGLoader.freeDictForNum.get(url) <= 0) {
                    FGLoader._freeList.push(url);
                }
            });
            return FGLoader._freeList;
        }
        static setUse(url) {
            let num = FGLoader.freeDictForNum.has(url) ? FGLoader.freeDictForNum.get(url) + 1 : 1;
            FGLoader.freeDictForNum.set(url, num);
        }
        static setFree(url) {
            if (url.indexOf("/MenuIcon/") != -1)
                return;
            FGLoader.freeDictForTime.set(url, Date.now());
            let num = FGLoader.freeDictForNum.has(url) ? FGLoader.freeDictForNum.get(url) - 1 : 0;
            if (num < 0)
                num = 0;
            FGLoader.freeDictForNum.set(url, num);
        }
        static removeFree(url) {
            FGLoader.freeDictForTime.delete(url);
            FGLoader.freeDictForNum.delete(url);
        }
        static clearAllFree(list) {
            if (!list)
                list = FGLoader.freeList;
            while (list.length > 0) {
                let url = list.pop();
                FGLoader.removeFree(url);
                Laya.loader.clearRes(url);
            }
        }
        static clearFreeLong() {
            if (FGLoader.freeDictForNum.size <= this.fguiLoaderCacheNum)
                return;
            FGLoader._freeLongList.length = 0;
            FGLoader.freeDictForNum.forEach((val, url) => {
                if (FGLoader.freeDictForNum.get(url) <= 0) {
                    let time = Date.now() - (FGLoader.freeDictForTime.has(url) ? FGLoader.freeDictForTime.get(url) : 0);
                    if (time > this.fguiLoaderCacheTime)
                        FGLoader._freeLongList.push(url);
                }
            });
            FGLoader.clearAllFree(FGLoader._freeLongList);
        }
        loadContent() {
            super.loadContent();
        }
        getPackagenameByUrl(url) {
            return url.replace("ui://", "").split("/")[0];
        }
        loadFromPackage(itemURL) {
            let packageItem = fgui.UIPackage.getItemByURL(itemURL);
            if (packageItem) {
                super.loadFromPackage(itemURL);
            }
            else {
                let packagename = this.getPackagenameByUrl(itemURL);
                let config = GuiSetting.spriteRes.getconfig(packagename);
                if (!config) {
                    config = GuiSetting.guiRes.getconfig(packagename);
                }
                if (config) {
                    GuiSetting.asset.loadFgui(config, this, this.onLoadPackage);
                }
            }
        }
        onLoadPackage() {
            super.loadFromPackage(this.url);
        }
        loadExternal() {
            FGLoader.setUse(this.url);
            super.loadExternal();
        }
        freeExternal(texture) {
            super.freeExternal(texture);
            if (!isNullOrEmpty(texture.url)) {
                FGLoader.setFree(texture.url);
                texture.url = "";
            }
        }
        onExternalLoadSuccess(texture) {
            super.onExternalLoadSuccess(texture);
        }
        onExternalLoadFailed() {
            super.onExternalLoadFailed();
        }
    }
    FGLoader.fguiLoaderCacheNum = 100;
    FGLoader.fguiLoaderCacheTime = 100;
    FGLoader.freeDictForTime = new Map();
    FGLoader.freeDictForNum = new Map();
    FGLoader._freeList = [];
    FGLoader._freeLongList = [];

    class GMMainStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "GMMain"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_mainMenu = (this.getChild("mainMenu"));
            this.m_debugPage = (this.getChild("debugPage"));
            this.m_addPage = (this.getChild("addPage"));
            this.m_selectServerPage = (this.getChild("selectServerPage"));
            this.m_closeButton = (this.getChild("closeButton"));
            this.m_cmdPage = (this.getChild("cmdPage"));
            this.m_displayTreePage = (this.getChild("displayTreePage"));
            this.m_timeLoopPage = (this.getChild("timeLoopPage"));
            this.m_tickPage = (this.getChild("tickPage"));
            this.m_serverHostPage = (this.getChild("serverHostPage"));
        }
    }
    GMMainStruct.URL = "ui://ujw583yp9nrl0";
    GMMainStruct.DependPackages = ["GameGM"];

    class GMMain extends GMMainStruct {
    }

    class GMMenuBarStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "GMMenuBar"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_menuBar = (this.getChild("menuBar"));
            this.m_menuList = (this.getChild("menuList"));
        }
    }
    GMMenuBarStruct.URL = "ui://ujw583ypwl2t1";
    GMMenuBarStruct.DependPackages = ["GameGM"];

    class GMMenuBar extends GMMenuBarStruct {
    }

    class GMPopupMenu_itemStruct extends fgui.GButton {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "GMPopupMenu_item"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_button = this.getController("button");
            this.m_checked = this.getController("checked");
            this.m_title = (this.getChild("title"));
        }
    }
    GMPopupMenu_itemStruct.URL = "ui://ujw583ypm23g3";
    GMPopupMenu_itemStruct.DependPackages = ["GameGM"];

    class GMPopupMenu_item extends GMPopupMenu_itemStruct {
    }

    class GMPopupMenuStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "GMPopupMenu"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_list = (this.getChild("list"));
        }
    }
    GMPopupMenuStruct.URL = "ui://ujw583ypm23g4";
    GMPopupMenuStruct.DependPackages = ["GameGM"];

    class GMPopupMenu extends GMPopupMenuStruct {
    }

    class GMPopupButtonStruct extends fgui.GButton {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "GMPopupButton"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_button = this.getController("button");
            this.m_title = (this.getChild("title"));
        }
    }
    GMPopupButtonStruct.URL = "ui://ujw583ypm23g5";
    GMPopupButtonStruct.DependPackages = ["GameGM"];

    class GMPopupButton extends GMPopupButtonStruct {
    }

    class GMSubMenuBarStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "GMSubMenuBar"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_menuBar = (this.getChild("menuBar"));
            this.m_subMenu = (this.getChild("subMenu"));
        }
    }
    GMSubMenuBarStruct.URL = "ui://ujw583ypfbyi6";
    GMSubMenuBarStruct.DependPackages = ["GameGM"];

    class GMSubMenuBar extends GMSubMenuBarStruct {
    }

    class GMDebugPageStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "GMDebugPage"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_list = (this.getChild("list"));
            this.m_subMenuBar = (this.getChild("subMenuBar"));
            this.m_clearButton = (this.getChild("clearButton"));
            this.m_refreshButton = (this.getChild("refreshButton"));
        }
    }
    GMDebugPageStruct.URL = "ui://ujw583ypfbyi8";
    GMDebugPageStruct.DependPackages = ["GameGM"];

    class GMDebugPage extends GMDebugPageStruct {
    }

    class GMAddPageStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "GMAddPage"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_list = (this.getChild("list"));
            this.m_popupButton = (this.getChild("popupButton"));
            this.m_filterInput = (this.getChild("filterInput"));
            this.m_filterCheckbox = (this.getChild("filterCheckbox"));
            this.m_listTopButton = (this.getChild("listTopButton"));
            this.m_listBottomButton = (this.getChild("listBottomButton"));
        }
    }
    GMAddPageStruct.URL = "ui://ujw583ypfbyi9";
    GMAddPageStruct.DependPackages = ["GameGM"];

    class GMAddPage extends GMAddPageStruct {
    }

    class CheckboxStruct extends fgui.GButton {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "Checkbox"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_button = this.getController("button");
            this.m_title = (this.getChild("title"));
        }
    }
    CheckboxStruct.URL = "ui://ujw583ypnb4ea";
    CheckboxStruct.DependPackages = ["GameGM"];

    class Checkbox extends CheckboxStruct {
    }

    class TextInputStruct extends fgui.GButton {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "TextInput"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_title = (this.getChild("title"));
        }
    }
    TextInputStruct.URL = "ui://ujw583ypfv0tb";
    TextInputStruct.DependPackages = ["GameGM"];

    class TextInput extends TextInputStruct {
    }

    class GMAddItemStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "GMAddItem"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_id = (this.getChild("id"));
            this.m_title = (this.getChild("title"));
            this.m_describe = (this.getChild("describe"));
            this.m_icon = (this.getChild("icon"));
            this.m_num = (this.getChild("num"));
            this.m_button = (this.getChild("button"));
            this.m_numberInput = (this.getChild("numberInput"));
        }
    }
    GMAddItemStruct.URL = "ui://ujw583ypfv0tc";
    GMAddItemStruct.DependPackages = ["GameGM"];

    class GMAddItem extends GMAddItemStruct {
    }

    class ButtonCornerStruct extends fgui.GButton {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "ButtonCorner"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_button = this.getController("button");
            this.m_title = (this.getChild("title"));
        }
    }
    ButtonCornerStruct.URL = "ui://ujw583ypfv0td";
    ButtonCornerStruct.DependPackages = ["GameGM"];

    class ButtonCorner extends ButtonCornerStruct {
    }

    class NumberInputStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "NumberInput"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_title = (this.getChild("title"));
            this.m_downButton = (this.getChild("downButton"));
            this.m_upButton = (this.getChild("upButton"));
        }
    }
    NumberInputStruct.URL = "ui://ujw583ypfv0tf";
    NumberInputStruct.DependPackages = ["GameGM"];

    class NumberInput extends NumberInputStruct {
    }

    class ButtonRectStruct extends fgui.GButton {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "ButtonRect"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_button = this.getController("button");
            this.m_title = (this.getChild("title"));
        }
    }
    ButtonRectStruct.URL = "ui://ujw583ypc3i0h";
    ButtonRectStruct.DependPackages = ["GameGM"];

    class ButtonRect extends ButtonRectStruct {
    }

    class GMSelectServerPageStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "GMSelectServerPage"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_list = (this.getChild("list"));
        }
    }
    GMSelectServerPageStruct.URL = "ui://ujw583ypket7j";
    GMSelectServerPageStruct.DependPackages = ["GameGM"];

    class GMSelectServerPage extends GMSelectServerPageStruct {
    }

    class GMCmdPageStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "GMCmdPage"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_list = (this.getChild("list"));
            this.m_subMenuBar = (this.getChild("subMenuBar"));
            this.m_input = (this.getChild("input"));
            this.m_sendButton = (this.getChild("sendButton"));
            this.m_clearButton = (this.getChild("clearButton"));
        }
    }
    GMCmdPageStruct.URL = "ui://ujw583ypket7k";
    GMCmdPageStruct.DependPackages = ["GameGM"];

    class GMCmdPage extends GMCmdPageStruct {
    }

    class GMSubMenuRadioBarStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "GMSubMenuRadioBar"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_menuBar = (this.getChild("menuBar"));
            this.m_subMenu = (this.getChild("subMenu"));
        }
    }
    GMSubMenuRadioBarStruct.URL = "ui://ujw583ypket7l";
    GMSubMenuRadioBarStruct.DependPackages = ["GameGM"];

    class GMSubMenuRadioBar extends GMSubMenuRadioBarStruct {
    }

    class TextAreaStruct extends fgui.GButton {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "TextArea"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_title = (this.getChild("title"));
        }
    }
    TextAreaStruct.URL = "ui://ujw583ypket7m";
    TextAreaStruct.DependPackages = ["GameGM"];

    class TextArea extends TextAreaStruct {
    }

    class GMCmdItemStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "GMCmdItem"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_title = (this.getChild("title"));
            this.m_name = (this.getChild("name"));
            this.m_button = (this.getChild("button"));
        }
    }
    GMCmdItemStruct.URL = "ui://ujw583ypket7n";
    GMCmdItemStruct.DependPackages = ["GameGM"];

    class GMCmdItem extends GMCmdItemStruct {
    }

    class GMLogItemStruct extends fgui.GLabel {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "GMLogItem"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_title = (this.getChild("title"));
        }
    }
    GMLogItemStruct.URL = "ui://ujw583ypsy3ro";
    GMLogItemStruct.DependPackages = ["GameGM"];

    class GMLogItem extends GMLogItemStruct {
    }

    class TreeStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "Tree"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
        }
    }
    TreeStruct.URL = "ui://ujw583ypx6hop";
    TreeStruct.DependPackages = ["GameGM"];

    class Tree extends TreeStruct {
    }

    class TreeItemStruct extends fgui.GButton {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "TreeItem"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_button = this.getController("button");
            this.m_title = (this.getChild("title"));
            this.m_visiable = (this.getChild("visiable"));
            this.m_openClose = (this.getChild("openClose"));
            this.m_list = (this.getChild("list"));
        }
    }
    TreeItemStruct.URL = "ui://ujw583ypx6hot";
    TreeItemStruct.DependPackages = ["GameGM"];

    class TreeItem extends TreeItemStruct {
    }

    class TreeItemCheckboxStruct extends fgui.GButton {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "TreeItemCheckbox"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_button = this.getController("button");
        }
    }
    TreeItemCheckboxStruct.URL = "ui://ujw583ypx6hou";
    TreeItemCheckboxStruct.DependPackages = ["GameGM"];

    class TreeItemCheckbox extends TreeItemCheckboxStruct {
    }

    class GMDisplayTreePageStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "GMDisplayTreePage"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_tree = (this.getChild("tree"));
            this.m_refreshButton = (this.getChild("refreshButton"));
            this.m_showSelectButton = (this.getChild("showSelectButton"));
            this.m_hideSelectButton = (this.getChild("hideSelectButton"));
            this.m_noSelectButton = (this.getChild("noSelectButton"));
            this.m_parentLayerButton = (this.getChild("parentLayerButton"));
            this.m_setLayerButton = (this.getChild("setLayerButton"));
        }
    }
    GMDisplayTreePageStruct.URL = "ui://ujw583ypx6hov";
    GMDisplayTreePageStruct.DependPackages = ["GameGM"];

    class GMDisplayTreePage extends GMDisplayTreePageStruct {
    }

    class TreeItemOpenCheckboxStruct extends fgui.GButton {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "TreeItemOpenCheckbox"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_button = this.getController("button");
            this.m_close = (this.getChild("close"));
            this.m_open = (this.getChild("open"));
        }
    }
    TreeItemOpenCheckboxStruct.URL = "ui://ujw583ypx6how";
    TreeItemOpenCheckboxStruct.DependPackages = ["GameGM"];

    class TreeItemOpenCheckbox extends TreeItemOpenCheckboxStruct {
    }

    class TreeListStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "TreeList"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
        }
    }
    TreeListStruct.URL = "ui://ujw583ypx6hoz";
    TreeListStruct.DependPackages = ["GameGM"];

    class TreeList extends TreeListStruct {
    }

    class GMTimeLoopPageStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "GMTimeLoopPage"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_list = (this.getChild("list"));
            this.m_refreshButton = (this.getChild("refreshButton"));
            this.m_clearButton = (this.getChild("clearButton"));
            this.m_sortCostTimeToalButton = (this.getChild("sortCostTimeToalButton"));
            this.m_sorteEvaluateButton = (this.getChild("sorteEvaluateButton"));
            this.m_sorteCallNumButton = (this.getChild("sorteCallNumButton"));
            this.m_sorteCostTimeButton = (this.getChild("sorteCostTimeButton"));
        }
    }
    GMTimeLoopPageStruct.URL = "ui://ujw583yp7h8s10";
    GMTimeLoopPageStruct.DependPackages = ["GameGM"];

    class GMTimeLoopPage extends GMTimeLoopPageStruct {
    }

    class GMTimeLoopItemStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "GMTimeLoopItem"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_title = (this.getChild("title"));
            this.m_visiable = (this.getChild("visiable"));
        }
    }
    GMTimeLoopItemStruct.URL = "ui://ujw583yp7h8s11";
    GMTimeLoopItemStruct.DependPackages = ["GameGM"];

    class GMTimeLoopItem extends GMTimeLoopItemStruct {
    }

    class GMTickPageStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "GMTickPage"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_list = (this.getChild("list"));
            this.m_refreshButton = (this.getChild("refreshButton"));
            this.m_clearButton = (this.getChild("clearButton"));
            this.m_sortCostTimeToalButton = (this.getChild("sortCostTimeToalButton"));
            this.m_sorteEvaluateButton = (this.getChild("sorteEvaluateButton"));
            this.m_sorteCallNumButton = (this.getChild("sorteCallNumButton"));
            this.m_sorteCostTimeButton = (this.getChild("sorteCostTimeButton"));
        }
    }
    GMTickPageStruct.URL = "ui://ujw583yp7h8s12";
    GMTickPageStruct.DependPackages = ["GameGM"];

    class GMTickPage extends GMTickPageStruct {
    }

    class GMServerHostPageStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameGM", "GMServerHostPage"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_ipIput = (this.getChild("ipIput"));
            this.m_addButton = (this.getChild("addButton"));
            this.m_portInput = (this.getChild("portInput"));
            this.m_isHttpCheckbox = (this.getChild("isHttpCheckbox"));
        }
    }
    GMServerHostPageStruct.URL = "ui://ujw583ypi8be13";
    GMServerHostPageStruct.DependPackages = ["GameGM"];

    class GMServerHostPage extends GMServerHostPageStruct {
    }

    class GameGMBinder {
        static bindAll() {
            let bind = fgui.UIObjectFactory.setPackageItemExtension;
            bind(GMMain.URL, GMMain);
            bind(GMMenuBar.URL, GMMenuBar);
            bind(GMPopupMenu_item.URL, GMPopupMenu_item);
            bind(GMPopupMenu.URL, GMPopupMenu);
            bind(GMPopupButton.URL, GMPopupButton);
            bind(GMSubMenuBar.URL, GMSubMenuBar);
            bind(GMDebugPage.URL, GMDebugPage);
            bind(GMAddPage.URL, GMAddPage);
            bind(Checkbox.URL, Checkbox);
            bind(TextInput.URL, TextInput);
            bind(GMAddItem.URL, GMAddItem);
            bind(ButtonCorner.URL, ButtonCorner);
            bind(NumberInput.URL, NumberInput);
            bind(ButtonRect.URL, ButtonRect);
            bind(GMSelectServerPage.URL, GMSelectServerPage);
            bind(GMCmdPage.URL, GMCmdPage);
            bind(GMSubMenuRadioBar.URL, GMSubMenuRadioBar);
            bind(TextArea.URL, TextArea);
            bind(GMCmdItem.URL, GMCmdItem);
            bind(GMLogItem.URL, GMLogItem);
            bind(Tree.URL, Tree);
            bind(TreeItem.URL, TreeItem);
            bind(TreeItemCheckbox.URL, TreeItemCheckbox);
            bind(GMDisplayTreePage.URL, GMDisplayTreePage);
            bind(TreeItemOpenCheckbox.URL, TreeItemOpenCheckbox);
            bind(TreeList.URL, TreeList);
            bind(GMTimeLoopPage.URL, GMTimeLoopPage);
            bind(GMTimeLoopItem.URL, GMTimeLoopItem);
            bind(GMTickPage.URL, GMTickPage);
            bind(GMServerHostPage.URL, GMServerHostPage);
        }
    }

    class EnterModuleLoaderStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameLaunch", "EnterModuleLoader"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_Reconnection = this.getController("Reconnection");
            this.m_title = (this.getChild("title"));
            this.m_help = (this.getChild("help"));
            this.m_txt_resVer = (this.getChild("txt_resVer"));
            this.m_txt_gamever = (this.getChild("txt_gamever"));
            this.m_screenBG = (this.getChild("screenBG"));
            this.m_progressBar = (this.getChild("progressBar"));
        }
    }
    EnterModuleLoaderStruct.URL = "ui://47qsdr42f84s0";
    EnterModuleLoaderStruct.DependPackages = ["GameLaunch"];

    class EnterModuleLoader extends EnterModuleLoaderStruct {
    }

    class ScreenBGStruct extends fgui.GLabel {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameLaunch", "ScreenBG"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_icon = (this.getChild("icon"));
        }
    }
    ScreenBGStruct.URL = "ui://47qsdr42f84s1";
    ScreenBGStruct.DependPackages = ["GameLaunch"];

    class ScreenBG extends ScreenBGStruct {
    }

    class DialogCloseWindowStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameLaunch", "DialogCloseWindow"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_closeButton = (this.getChild("closeButton"));
        }
    }
    DialogCloseWindowStruct.URL = "ui://47qsdr42f84sg";
    DialogCloseWindowStruct.DependPackages = ["GameLaunch"];

    class DialogCloseWindow extends DialogCloseWindowStruct {
    }

    class SystemAlertMessageStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameLaunch", "SystemAlertMessage"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_content = (this.getChild("content"));
            this.m_title = (this.getChild("title"));
            this.m_dialog = (this.getChild("dialog"));
            this.m_okBtn = (this.getChild("okBtn"));
        }
    }
    SystemAlertMessageStruct.URL = "ui://47qsdr42nk8t1";
    SystemAlertMessageStruct.DependPackages = ["GameLaunch"];

    class SystemAlertMessage extends SystemAlertMessageStruct {
    }

    class SystemConfirmMessageStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameLaunch", "SystemConfirmMessage"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_content = (this.getChild("content"));
            this.m_title = (this.getChild("title"));
            this.m_dialog = (this.getChild("dialog"));
            this.m_okBtn = (this.getChild("okBtn"));
            this.m_cancleBtn = (this.getChild("cancleBtn"));
        }
    }
    SystemConfirmMessageStruct.URL = "ui://47qsdr42nk8t2";
    SystemConfirmMessageStruct.DependPackages = ["GameLaunch"];

    class SystemConfirmMessage extends SystemConfirmMessageStruct {
    }

    class SystemToastMessageStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameLaunch", "SystemToastMessage"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_title = (this.getChild("title"));
        }
    }
    SystemToastMessageStruct.URL = "ui://47qsdr42nk8t3";
    SystemToastMessageStruct.DependPackages = ["GameLaunch"];

    class SystemToastMessage extends SystemToastMessageStruct {
    }

    class GMButtonStruct extends fgui.GButton {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameLaunch", "GMButton"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
        }
    }
    GMButtonStruct.URL = "ui://47qsdr42uohx13";
    GMButtonStruct.DependPackages = ["GameLaunch"];

    class GMButton extends GMButtonStruct {
    }

    class EnterWarLoaderStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameLaunch", "EnterWarLoader"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_View = this.getController("View");
            this.m_listTeam = (this.getChild("listTeam"));
            this.m_listEnemy = (this.getChild("listEnemy"));
            this.m_pvpProgress1 = (this.getChild("pvpProgress1"));
            this.m_pvpProgress2 = (this.getChild("pvpProgress2"));
            this.m_screenBG = (this.getChild("screenBG"));
        }
    }
    EnterWarLoaderStruct.URL = "ui://47qsdr42kpvww2b";
    EnterWarLoaderStruct.DependPackages = ["GameLaunch"];

    class EnterWarLoader extends EnterWarLoaderStruct {
    }

    class EnterWarItemStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameLaunch", "EnterWarItem"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_imgHero = (this.getChild("imgHero"));
            this.m_labName = (this.getChild("labName"));
            this.m_labLevel = (this.getChild("labLevel"));
            this.m_labProgess = (this.getChild("labProgess"));
            this.m_playerIcon = (this.getChild("playerIcon"));
            this.m_btnTalent = (this.getChild("btnTalent"));
        }
    }
    EnterWarItemStruct.URL = "ui://47qsdr42kpvww2f";
    EnterWarItemStruct.DependPackages = ["GameLaunch"];

    class EnterWarItem extends EnterWarItemStruct {
    }

    class BGModelStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameLaunch", "BGModel"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
        }
    }
    BGModelStruct.URL = "ui://47qsdr42ae8aw2h";
    BGModelStruct.DependPackages = ["GameLaunch"];

    class BGModel extends BGModelStruct {
    }

    class GlobalModalWaitingStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameLaunch", "GlobalModalWaiting"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_circle = (this.getChild("circle"));
            this.m_rotation = this.getTransition("rotation");
        }
    }
    GlobalModalWaitingStruct.URL = "ui://47qsdr42x6asw2i";
    GlobalModalWaitingStruct.DependPackages = ["GameLaunch"];

    class GlobalModalWaiting extends GlobalModalWaitingStruct {
    }

    class WindowModalWaitingStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameLaunch", "WindowModalWaiting"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_circle = (this.getChild("circle"));
            this.m_rotation = this.getTransition("rotation");
        }
    }
    WindowModalWaitingStruct.URL = "ui://47qsdr42x6asw2j";
    WindowModalWaitingStruct.DependPackages = ["GameLaunch"];

    class WindowModalWaiting extends WindowModalWaitingStruct {
    }

    class EnterLoginLoaderStruct extends fgui.GComponent {
        constructor() {
            super();
        }
        static createInstance() {
            return (fgui.UIPackage.createObject("GameLaunch", "EnterLoginLoader"));
        }
        constructFromXML(xml) {
            super.constructFromXML(xml);
            this.m_Reconnection = this.getController("Reconnection");
            this.m_title = (this.getChild("title"));
            this.m_help = (this.getChild("help"));
            this.m_txt_resVer = (this.getChild("txt_resVer"));
            this.m_txt_gamever = (this.getChild("txt_gamever"));
            this.m_screenBG = (this.getChild("screenBG"));
            this.m_progressBar = (this.getChild("progressBar"));
            this.m_imgLogo = (this.getChild("imgLogo"));
            this.m_t0 = this.getTransition("t0");
        }
    }
    EnterLoginLoaderStruct.URL = "ui://47qsdr42mrzrw2o";
    EnterLoginLoaderStruct.DependPackages = ["GameLaunch"];

    class EnterLoginLoader extends EnterLoginLoaderStruct {
    }

    class GameLaunchBinder {
        static bindAll() {
            let bind = fgui.UIObjectFactory.setPackageItemExtension;
            bind(EnterModuleLoader.URL, EnterModuleLoader);
            bind(ScreenBG.URL, ScreenBG);
            bind(DialogCloseWindow.URL, DialogCloseWindow);
            bind(SystemAlertMessage.URL, SystemAlertMessage);
            bind(SystemConfirmMessage.URL, SystemConfirmMessage);
            bind(SystemToastMessage.URL, SystemToastMessage);
            bind(GMButton.URL, GMButton);
            bind(EnterWarLoader.URL, EnterWarLoader);
            bind(EnterWarItem.URL, EnterWarItem);
            bind(BGModel.URL, BGModel);
            bind(GlobalModalWaiting.URL, GlobalModalWaiting);
            bind(WindowModalWaiting.URL, WindowModalWaiting);
            bind(EnterLoginLoader.URL, EnterLoginLoader);
        }
    }

    class GuiBinderList {
        static fguiBinderAll() {
            GameGMBinder.bindAll();
            GameLaunchBinder.bindAll();
        }
    }

    var Handler = Laya.Handler;
    class FguiAssetManager {
        loadFguiByPackagename(packageName, caller, method) {
            let packageConfig = GuiSetting.guiRes.getconfig(packageName);
            this.loadFgui(packageConfig, caller, method);
        }
        async loadFguiByPackagenameAsync(packageName) {
            return new Promise((resolve) => {
                this.loadFguiByPackagename(packageName, this, (packageConfig) => {
                    resolve(packageConfig);
                });
            });
        }
        loadFgui(packageConfig, caller, method) {
            if (!packageConfig) {
                console.error(`AssetManager loadFgui: packageConfig=${packageConfig}`);
                return;
            }
            let callback = {
                apply: () => {
                    GuiSetting.addPackage(packageConfig.packagePath, packageConfig);
                    if (method) {
                        if (caller) {
                            return method.apply(caller, [packageConfig]);
                        }
                        else {
                            method(packageConfig);
                        }
                    }
                }
            };
            GuiSetting.addPackageReferenceNum(packageConfig.packagePath);
            if (GuiSetting.hasLoadPackage(packageConfig.packagePath)) {
                callback.apply();
                return;
            }
            Laya.loader.load(packageConfig.loadList, Handler.create(callback, callback.apply));
        }
        unloadFgui(packageName, forceDispose) {
            if (forceDispose === undefined)
                forceDispose = false;
            let packageConfig = GuiSetting.guiRes.getconfig(packageName);
            if (!packageConfig)
                packageConfig = GuiSetting.spriteRes.getconfig(packageName);
            if (packageConfig) {
                let referenceNum = GuiSetting.removePackageReferenceNum(packageConfig.packagePath);
                if (!forceDispose) {
                    if (referenceNum > 0) {
                        return;
                    }
                }
                GuiSetting.removePackage(packageConfig.packagePath, packageConfig);
                let list = packageConfig.loadList;
                for (let i = 0; i < list.length; i++) {
                    Laya.loader.clearRes(list[i].url);
                }
            }
        }
    }

    class GuiSetting {
        static init() {
            if (!fgui.GRoot.inst.displayObject.parent) {
                Laya.stage.addChild(fgui.GRoot.inst.displayObject);
            }
            this.guiRes = new GuiResPackageConfigReader();
            this.guiRes.install();
            this.spriteRes = new SpriteResPackageConfigReader();
            this.spriteRes.install();
            this.asset = new FguiAssetManager();
            fgui.UIConfig.packageFileExtension = GuiSetting.packageFileExtension;
            fgui.UIObjectFactory.setLoaderExtension(FGLoader);
            GuiBinderList.fguiBinderAll();
            fgui.UIConfig.defaultFont = "_sans";
        }
        static getResPackagePath(packageName, dir) {
            if (isNullOrEmpty(dir)) {
                return `${GuiSetting.resRoot}${packageName}`;
            }
            else {
                return `${GuiSetting.resRoot}${dir}/${packageName}`;
            }
        }
        static getResPath(filename, dir) {
            if (isNullOrEmpty(dir)) {
                return `${GuiSetting.resRoot}${filename}`;
            }
            else {
                return `${GuiSetting.resRoot}${dir}/${filename}`;
            }
        }
        static getMapPath(filename) {
            return this.getResPath(filename, "map");
        }
        static addPackage(resKey, packageConfig) {
            if (GuiSetting._uiPackageDict.hasKey(resKey)) {
                return GuiSetting._uiPackageDict.getValue(resKey);
            }
            else {
                let pkg = fgui.UIPackage.addPackage(resKey);
                GuiSetting._uiPackageDict.add(resKey, pkg);
                return pkg;
            }
        }
        static removePackage(resKey, packageConfig) {
            let pkg = GuiSetting._uiPackageDict.getValue(resKey);
            if (pkg) {
                fgui.UIPackage.removePackage(pkg.id);
                pkg.dispose();
                GuiSetting._uiPackageDict.remove(resKey);
            }
            GuiSetting._uiPackageDictForReferenceNum.remove(resKey);
        }
        static hasLoadPackage(resKey) {
            return GuiSetting._uiPackageDict.hasKey(resKey);
        }
        static addPackageReferenceNum(resKey) {
            let num = GuiSetting.getPackageReferenceNum(resKey) + 1;
            if (num == 0) {
                num = 1;
            }
            console.log("~~addPackageReferenceNum:  " + num + "  " + resKey);
            GuiSetting._uiPackageDictForReferenceNum.add(resKey, num);
            return num;
        }
        static removePackageReferenceNum(resKey) {
            let num = GuiSetting.getPackageReferenceNum(resKey) - 1;
            if (num < 0) {
                num = 0;
            }
            console.log("~~removePackageReferenceNum:  " + num + "  " + resKey);
            GuiSetting._uiPackageDictForReferenceNum.add(resKey, num);
            return num;
        }
        static getPackageReferenceNum(resKey) {
            return GuiSetting._uiPackageDictForReferenceNum.hasKey(resKey) ? GuiSetting._uiPackageDictForReferenceNum.getValue(resKey) : 0;
        }
    }
    GuiSetting.resRoot = "res/";
    GuiSetting.packageFileExtension = "bin";
    GuiSetting._uiPackageDict = new Dictionary();
    GuiSetting._uiPackageDictForReferenceNum = new Dictionary();

    class GuiPackageNames {
    }
    GuiPackageNames.GameGM = "GameGM";
    GuiPackageNames.GameLaunch = "GameLaunch";

    class Main {
        constructor() {
            if (window["Laya3D"])
                Laya3D.init(GameConfig.width, GameConfig.height);
            else
                Laya.init(GameConfig.width, GameConfig.height, Laya["WebGL"]);
            Laya["Physics"] && Laya["Physics"].enable();
            Laya["DebugPanel"] && Laya["DebugPanel"].enable();
            Laya.stage.scaleMode = GameConfig.scaleMode;
            Laya.stage.screenMode = GameConfig.screenMode;
            Laya.stage.alignV = GameConfig.alignV;
            Laya.stage.alignH = GameConfig.alignH;
            Laya.URL.exportSceneToJson = GameConfig.exportSceneToJson;
            if (GameConfig.debug || Laya.Utils.getQueryString("debug") == "true")
                Laya.enableDebugPanel();
            if (GameConfig.physicsDebug && Laya["PhysicsDebugDraw"])
                Laya["PhysicsDebugDraw"].enable();
            if (GameConfig.stat)
                Laya.Stat.show();
            Laya.alertGlobalError(true);
            console.log("aaa");
            this.initFguiSetting();
        }
        async initFguiSetting() {
            GuiSetting.init();
            let packageConfig = await GuiSetting.asset.loadFguiByPackagenameAsync(GuiPackageNames.GameLaunch);
            GuiSetting.addPackage(packageConfig.packagePath);
            fgui.UIConfig.globalModalWaiting = fgui.UIPackage.getItemURL(packageConfig.packageName, "GlobalModalWaiting");
            fgui.UIConfig.windowModalWaiting = fgui.UIPackage.getItemURL(packageConfig.packageName, "WindowModalWaiting");
            var enterLoginLoader = EnterLoginLoader.createInstance();
            fgui.GRoot.inst.addChild(enterLoginLoader);
        }
        onLoadConfigProgress() {
        }
        onVersionLoaded() {
            Laya.AtlasInfoManager.enable("fileconfig.json", Laya.Handler.create(this, this.onConfigLoaded));
        }
        onConfigLoaded() {
            GameConfig.startScene && Laya.Scene.open(GameConfig.startScene);
        }
    }
    new Main();

}());
//# sourceMappingURL=bundle.js.map
