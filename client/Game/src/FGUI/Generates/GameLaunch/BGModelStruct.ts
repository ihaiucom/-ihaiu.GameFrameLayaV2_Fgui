/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import BGModel from "../../Extends/GameLaunch/BGModel";

export default class BGModelStruct extends fgui.GComponent
{

	
	public static URL:string = "ui://47qsdr42ae8aw2h";
	
	public static DependPackages:string[] = ["GameLaunch"];

	
	public static createInstance():BGModel {
		return <BGModel><any>(fgui.UIPackage.createObject("GameLaunch","BGModel"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		

		
		
		
	}
}