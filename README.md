# ihaiu.GameFrameLayaV2
Laya游戏框架基于Laya2.6版本



## 目录结构

client 客户端目录

​	|-- Game 游戏项目

​	|--Game-FGUI 游戏FairyGUI项目

​			|--Tool-ExportCode  生成FairyGUI代码工具目录



## FairyGUI

##### 工具导出环境搭建

###### 1. 安装dotnet

https://dotnet.microsoft.com/

###### 2.配置导出路径

​	client\Game-FGUI\Tool-ExportCode\CopyClientSetting.json

```json
{
  "enableoverwrites": [
  	{
  		"src":"../../../_gen/FairyGUICode/TS/Generates", 
		  "dst":"../../Game/src/FGUI/Generates"
  	}
  ],
  "disableoverwrites": [
  	{
      "src":"../../../_gen/FairyGUICode/TS/Extends", 
      "dst":"../../Game/src/FGUI/Extends"
    }
  ]
}
```

###### 3.执行导出

client\Game-FGUI\Tool-ExportCode\生成FGUI代码.bat





##### 项目配置依赖文件

Game/bin/index.js 下添加代码

```javascript
loadLib("libs/game/GameCommonLib.js");
// fgui
loadLib("libs/fairygui/rawinflate.min.js");
loadLib("libs/fairygui/fairygui.js");
```



##### 项目配置测试代码

```typescript
    
	// 设置FGUI
	async initFguiSetting()
	{

		GuiSetting.init();

		
		let packageConfig: GuiResPackageConfig = await GuiSetting.asset.loadFguiByPackagenameAsync(GuiPackageNames.GameLaunch);
		GuiSetting.addPackage(packageConfig.packagePath);
		
		// 初始化转圈
		fgui.UIConfig.globalModalWaiting = fgui.UIPackage.getItemURL(packageConfig.packageName, "GlobalModalWaiting");
		fgui.UIConfig.windowModalWaiting = fgui.UIPackage.getItemURL(packageConfig.packageName, "WindowModalWaiting");

		var enterLoginLoader =  EnterLoginLoader.createInstance();


		fgui.GRoot.inst.addChild(enterLoginLoader);
		
	}
```







