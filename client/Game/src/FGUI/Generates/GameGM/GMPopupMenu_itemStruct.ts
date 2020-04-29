/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import GMPopupMenu_item from "../../Extends/GameGM/GMPopupMenu_item";

export default class GMPopupMenu_itemStruct extends fgui.GButton
{
	public m_button : fgui.Controller;
	public m_checked : fgui.Controller;
	public m_title : fgui.GTextField;

	
	public static URL:string = "ui://ujw583ypm23g3";
	
	public static DependPackages:string[] = ["GameGM"];

	
	public static createInstance():GMPopupMenu_item {
		return <GMPopupMenu_item><any>(fgui.UIPackage.createObject("GameGM","GMPopupMenu_item"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		
		this.m_button = this.getController("button");
		this.m_checked = this.getController("checked");

		
		this.m_title = <fgui.GTextField><any>(this.getChild("title"));
		
		
	}
}