/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import ScreenBG from "../../Extends/GameLaunch/ScreenBG";

export default class ScreenBGStruct extends fgui.GLabel
{
	public m_icon : fgui.GLoader;

	
	public static URL:string = "ui://47qsdr42f84s1";
	
	public static DependPackages:string[] = ["GameLaunch"];

	
	public static createInstance():ScreenBG {
		return <ScreenBG><any>(fgui.UIPackage.createObject("GameLaunch","ScreenBG"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		

		
		this.m_icon = <fgui.GLoader><any>(this.getChild("icon"));
		
		
	}
}