/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import ButtonCorner from "../../Extends/GameGM/ButtonCorner";

export default class ButtonCornerStruct extends fgui.GButton
{
	public m_button : fgui.Controller;
	public m_title : fgui.GTextField;

	
	public static URL:string = "ui://ujw583ypfv0td";
	
	public static DependPackages:string[] = ["GameGM"];

	
	public static createInstance():ButtonCorner {
		return <ButtonCorner><any>(fgui.UIPackage.createObject("GameGM","ButtonCorner"));
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