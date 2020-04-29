/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import ScreenBG from "../../Extends/GameLaunch/ScreenBG";
import EnterWarLoader from "../../Extends/GameLaunch/EnterWarLoader";

export default class EnterWarLoaderStruct extends fgui.GComponent
{
	public m_View : fgui.Controller;
	public m_listTeam : fgui.GList;
	public m_listEnemy : fgui.GList;
	public m_pvpProgress1 : fgui.GTextField;
	public m_pvpProgress2 : fgui.GTextField;
	public m_screenBG : ScreenBG;

	
	public static URL:string = "ui://47qsdr42kpvww2b";
	
	public static DependPackages:string[] = ["GameLaunch"];

	
	public static createInstance():EnterWarLoader {
		return <EnterWarLoader><any>(fgui.UIPackage.createObject("GameLaunch","EnterWarLoader"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		
		this.m_View = this.getController("View");

		
		this.m_listTeam = <fgui.GList><any>(this.getChild("listTeam"));
		this.m_listEnemy = <fgui.GList><any>(this.getChild("listEnemy"));
		this.m_pvpProgress1 = <fgui.GTextField><any>(this.getChild("pvpProgress1"));
		this.m_pvpProgress2 = <fgui.GTextField><any>(this.getChild("pvpProgress2"));
		this.m_screenBG = <ScreenBG><any>(this.getChild("screenBG"));
		
		
	}
}