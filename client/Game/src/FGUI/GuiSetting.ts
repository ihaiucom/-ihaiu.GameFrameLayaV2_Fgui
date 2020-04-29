
import GuiResPackageConfig from "./GuiResPackageConfig";
import GuiResPackageConfigReader from "./GuiResPackageConfigReader";
import SpriteResPackageConfigReader from "./SpriteResPackageConfigReader";
import FGLoader from "./FGLoader";
import GuiBinderList from "./Generates/GuiBinderList";
import FguiAssetManager from "./FguiAssetManager";

// =====================
// fgui 设置
// ---------------------
export default class GuiSetting
{
    // 资源根目录
    static resRoot: string = "res/";

    // 后缀
    static packageFileExtension: string = "bin";

    // ui资源配置
    static guiRes: GuiResPackageConfigReader ;
    // sprite动态资源配置
    static spriteRes: SpriteResPackageConfigReader ;

    static asset: FguiAssetManager;

    static init()
    {
        if(!fgui.GRoot.inst.displayObject.parent)
        {
            // 根容器
            Laya.stage.addChild(fgui.GRoot.inst.displayObject);
        }

        // ui资源配置
        this.guiRes = new GuiResPackageConfigReader();
        this.guiRes.install();

        // sprite动态资源配置
        this.spriteRes = new SpriteResPackageConfigReader();
        this.spriteRes.install();

        this.asset = new FguiAssetManager();
        
		// 设置fgui文件后缀
		fgui.UIConfig.packageFileExtension = GuiSetting.packageFileExtension;
		// 注册Loader类
		fgui.UIObjectFactory.setLoaderExtension(FGLoader);
		// 绑定组件
		GuiBinderList.fguiBinderAll();
		// 设置按钮声音
		// fgui.UIConfig.buttonSound = SoundKey.getUrl(SoundKey.MM01_Button);
		//设置字体
		fgui.UIConfig.defaultFont = "_sans";
    }

    static getResPackagePath(packageName: string, dir: string)
    {
        if (isNullOrEmpty(dir))
        {
            return `${GuiSetting.resRoot}${packageName}`;
        }
        else
        {
            return `${GuiSetting.resRoot}${dir}/${packageName}`;
        }
    }

    static getResPath(filename: string, dir: string)
    {
        if (isNullOrEmpty(dir))
        {
            return `${GuiSetting.resRoot}${filename}`;
        }
        else
        {
            return `${GuiSetting.resRoot}${dir}/${filename}`;
        }
    }

    // 地图
    static getMapPath(filename: string)
    {
        return this.getResPath(filename, "map");
    }

    


    // 包        
    private static _uiPackageDict = new Dictionary<string, fgui.UIPackage>();
    // 包 引用次数
    private static _uiPackageDictForReferenceNum = new Dictionary<string, number>();

    public static addPackage(resKey: string, packageConfig?: GuiResPackageConfig): fgui.UIPackage
    {
        if (GuiSetting._uiPackageDict.hasKey(resKey))
        {
            return GuiSetting._uiPackageDict.getValue(resKey);
        }
        else
        {
            let pkg = fgui.UIPackage.addPackage(resKey);
            GuiSetting._uiPackageDict.add(resKey, pkg);
            return pkg;
        }
    }

    public static removePackage(resKey: string, packageConfig?: GuiResPackageConfig)
    {
        let pkg = GuiSetting._uiPackageDict.getValue(resKey);
        if (pkg)
        {
            fgui.UIPackage.removePackage(pkg.id);
            pkg.dispose();
            GuiSetting._uiPackageDict.remove(resKey);
        }
        GuiSetting._uiPackageDictForReferenceNum.remove(resKey);
    }

    public static hasLoadPackage(resKey: string): boolean
    {
        return GuiSetting._uiPackageDict.hasKey(resKey);
    }

    public static addPackageReferenceNum(resKey: string): number
    {
        let num = GuiSetting.getPackageReferenceNum(resKey) + 1;
        if (num == 0)
        {
            num = 1;
        }
        console.log("~~addPackageReferenceNum:  " + num + "  " + resKey);
        GuiSetting._uiPackageDictForReferenceNum.add(resKey, num);
        return num;
    }

    public static removePackageReferenceNum(resKey: string): number
    {
        let num = GuiSetting.getPackageReferenceNum(resKey) - 1;
        if (num < 0)
        {
            num = 0;
        }

        console.log("~~removePackageReferenceNum:  " + num + "  " + resKey);
        GuiSetting._uiPackageDictForReferenceNum.add(resKey, num);
        return num;
    }

    public static getPackageReferenceNum(resKey: string): number
    {
        return GuiSetting._uiPackageDictForReferenceNum.hasKey(resKey) ? GuiSetting._uiPackageDictForReferenceNum.getValue(resKey) : 0;
    }



}