import GuiResPackageConfig from "./GuiResPackageConfig";
import GuiSetting from "./GuiSetting";
import Handler = Laya.Handler;
export default class FguiAssetManager
{
    
    // 加载fgui包
    loadFguiByPackagename(packageName: string, caller?: any, method?: Function)
    {
        let packageConfig: GuiResPackageConfig = GuiSetting.guiRes.getconfig(packageName);
        this.loadFgui(packageConfig, caller, method);
    }

    async loadFguiByPackagenameAsync(packageName: string):Promise<GuiResPackageConfig>
    {
        return new Promise<GuiResPackageConfig>((resolve)=>{
            this.loadFguiByPackagename(packageName, this, (packageConfig: GuiResPackageConfig)=>
            {
                resolve(packageConfig);
            })
		});
    }


    
    loadFgui(packageConfig: GuiResPackageConfig, caller?: any, method?: Function)
    {
        if(!packageConfig)
        {
            console.error(`AssetManager loadFgui: packageConfig=${packageConfig}`);
            return;
        }

        let callback = {
            apply: () =>
            {

                GuiSetting.addPackage(packageConfig.packagePath, packageConfig);

                if (method)
                {
                    if (caller)
                    {
                        return method.apply(caller, [packageConfig]);
                    }
                    else
                    {
                        method(packageConfig);
                    }
                }
            }
        };

        GuiSetting.addPackageReferenceNum(packageConfig.packagePath);
        if (GuiSetting.hasLoadPackage(packageConfig.packagePath))
        {
            callback.apply();
            return;
        }

        Laya.loader.load(<any>packageConfig.loadList, Handler.create(callback, callback.apply));
    }

    unloadFgui(packageName: string, forceDispose?: boolean)
    {
        if (forceDispose === undefined)
            forceDispose = false;


        let packageConfig: GuiResPackageConfig = GuiSetting.guiRes.getconfig(packageName);
        if (!packageConfig)
            packageConfig = GuiSetting.spriteRes.getconfig(packageName);

        if (packageConfig)
        {
            let referenceNum = GuiSetting.removePackageReferenceNum(packageConfig.packagePath);
            if (!forceDispose)
            {
                if (referenceNum > 0)
                {
                    return;
                }
            }

            GuiSetting.removePackage(packageConfig.packagePath, packageConfig);
            let list = packageConfig.loadList;
            for (let i = 0; i < list.length; i++)
            {
                // console.log("==clearRes:" + list[i].url);
                Laya.loader.clearRes(list[i].url);
            }
        }
    }
}