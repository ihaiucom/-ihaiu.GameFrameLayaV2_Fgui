
import GuiResPackageConfig from "./GuiResPackageConfig";

/////////////////////////////////////
// ihaiu.GenerateFguiResPackageConfig生成
// http://blog.ihaiu.com
/////////////////////////////////////

// =====================
// fgui包资源配置列表
// ---------------------
export default class SpriteResPackageConfigReader
{
    // 字典
    dict:Map<string, GuiResPackageConfig> = new Map<string, GuiResPackageConfig>();

    // 添加配置
    addconfig(config: GuiResPackageConfig)
    {
        this.dict.set(config.packageName, config);
    }

    // 获取配置
    getconfig(packageName: string)
    {
        return this.dict.get(packageName);
    }



    // 初始化
    install()
    {
        let config:GuiResPackageConfig;

        
        // config = new GuiResPackageConfig();
        // config.resDir = "fsprite";
        // config.packageName = "ActivityIcon";
        // config.resBin = "ActivityIcon.bin";
        // config.resAtlas.push("ActivityIcon@atlas0.png");
        // this.addconfig(config)





    }
}