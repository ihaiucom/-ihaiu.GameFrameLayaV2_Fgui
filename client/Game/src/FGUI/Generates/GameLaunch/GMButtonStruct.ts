/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import GMButton from "../../Extends/GameLaunch/GMButton";

export default class GMButtonStruct extends fgui.GButton
{

	
	public static URL:string = "ui://47qsdr42uohx13";
	
	public static DependPackages:string[] = ["GameLaunch"];

	
	public static createInstance():GMButton {
		return <GMButton><any>(fgui.UIPackage.createObject("GameLaunch","GMButton"));
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