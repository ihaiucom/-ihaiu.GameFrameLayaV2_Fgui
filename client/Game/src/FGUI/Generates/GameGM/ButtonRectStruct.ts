/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import ButtonRect from "../../Extends/GameGM/ButtonRect";

export default class ButtonRectStruct extends fgui.GButton
{
	public m_button : fgui.Controller;
	public m_title : fgui.GTextField;

	
	public static URL:string = "ui://ujw583ypc3i0h";
	
	public static DependPackages:string[] = ["GameGM"];

	
	public static createInstance():ButtonRect {
		return <ButtonRect><any>(fgui.UIPackage.createObject("GameGM","ButtonRect"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		
		this.m_button = this.getController("button");

		
		this.m_title = <fgui.GTextField><any>(this.getChild("title"));
		
		
	}
}