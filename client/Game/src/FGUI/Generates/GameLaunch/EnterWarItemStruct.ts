/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import EnterWarItem from "../../Extends/GameLaunch/EnterWarItem";

export default class EnterWarItemStruct extends fgui.GComponent
{
	public m_imgHero : fgui.GLoader;
	public m_labName : fgui.GTextField;
	public m_labLevel : fgui.GTextField;
	public m_labProgess : fgui.GTextField;
	public m_playerIcon : fgui.GObject;
	public m_btnTalent : fgui.GObject;

	
	public static URL:string = "ui://47qsdr42kpvww2f";
	
	public static DependPackages:string[] = ["GameLaunch"];

	
	public static createInstance():EnterWarItem {
		return <EnterWarItem><any>(fgui.UIPackage.createObject("GameLaunch","EnterWarItem"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		

		
		this.m_imgHero = <fgui.GLoader><any>(this.getChild("imgHero"));
		this.m_labName = <fgui.GTextField><any>(this.getChild("labName"));
		this.m_labLevel = <fgui.GTextField><any>(this.getChild("labLevel"));
		this.m_labProgess = <fgui.GTextField><any>(this.getChild("labProgess"));
		this.m_playerIcon = <fgui.GObject><any>(this.getChild("playerIcon"));
		this.m_btnTalent = <fgui.GObject><any>(this.getChild("btnTalent"));
		
		
	}
}