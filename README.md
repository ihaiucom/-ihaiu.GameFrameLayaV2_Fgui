# ihaiu.GameFrameLayaV2
Laya游戏框架基于Laya2.6版本



## 目录结构

client 客户端目录

​	|-- Game 游戏项目

design 策划目录和配置文件目录

​	|-- Config 配置目录

​		|-- Common 客户端和服务器公用l配置文件目录

​	    |-- ExportSetting.xlsx 配置扩展结构体配置

​		|-- tools 导出配置文件工具目录

​			|--parseExcel_Client-NoPB.bat 导出配置文件工具

## 配置

##### 配置工具导出环境搭建

###### 1.安装nodejs

http://nodejs.cn/

###### 2.安装npm相关命令

```
cnpm install -g protobufjs@6.8.8
cnpm install -g pbjs@0.0.14

cnpm install -g zffile
```

###### 3.安装python 2.7, 设置好环境变量

https://www.python.org/

###### 4.安装dotnet

https://dotnet.microsoft.com/



##### 项目配置依赖文件

Game/bin/index.js 下添加代码

```javascript
loadLib("libs/game/GameCommonLib.js");
loadLib("libs/AntFrame/Net/protobuf.js")
loadLib("libs/pbconfig/excelconfig.js");
```



##### 项目配置测试代码

```typescript
    // 加载配置
	async initConfig()
	{ 
		var configManager = ConfigManager.Instance;
		await configManager.loadAllAsync();
		window['configManager'] = configManager;
		console.log(configManager);
	}
```





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







