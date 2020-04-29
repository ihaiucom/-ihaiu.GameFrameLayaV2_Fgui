/////////////////////////////////////
// ihaiu.GenerateFguiResPackageConfig生成
// http://blog.ihaiu.com
/////////////////////////////////////

import GuiResPackageConfig from "./GuiResPackageConfig";

// =====================
// fgui包资源配置列表
// ---------------------
export default class GuiResPackageConfigReader
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

		
		config = new GuiResPackageConfig();
            config.resDir = "fgui";
            config.packageName = "Effect_1001_Dianguanglongqi_Skin1__Skill4_13";
            config.resBin = "Effect_1001_Dianguanglongqi_Skin1__Skill4_13.bin";
            config.resAtlas.push("Effect_1001_Dianguanglongqi_Skin1__Skill4_13_atlas0.png");
            this.addconfig(config)




		config = new GuiResPackageConfig();
            config.resDir = "fgui";
            config.packageName = "GameGM";
            config.resBin = "GameGM.bin";
            this.addconfig(config)




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
            this.addconfig(config)





    }
}