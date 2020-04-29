/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import Checkbox from "../../Extends/GameGM/Checkbox";

export default class CheckboxStruct extends fgui.GButton
{
	public m_button : fgui.Controller;
	public m_title : fgui.GTextField;

	
	public static URL:string = "ui://ujw583ypnb4ea";
	
	public static DependPackages:string[] = ["GameGM"];

	
	public static createInstance():Checkbox {
		return <Checkbox><any>(fgui.UIPackage.createObject("GameGM","Checkbox"));
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