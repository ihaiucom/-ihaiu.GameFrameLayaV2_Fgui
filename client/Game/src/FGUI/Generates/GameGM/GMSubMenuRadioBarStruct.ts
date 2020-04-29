/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import GMSubMenuRadioBar from "../../Extends/GameGM/GMSubMenuRadioBar";

export default class GMSubMenuRadioBarStruct extends fgui.GComponent
{
	public m_menuBar : fgui.GGraph;
	public m_subMenu : fgui.GList;

	
	public static URL:string = "ui://ujw583ypket7l";
	
	public static DependPackages:string[] = ["GameGM"];

	
	public static createInstance():GMSubMenuRadioBar {
		return <GMSubMenuRadioBar><any>(fgui.UIPackage.createObject("GameGM","GMSubMenuRadioBar"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		

		
		this.m_menuBar = <fgui.GGraph><any>(this.getChild("menuBar"));
		this.m_subMenu = <fgui.GList><any>(this.getChild("subMenu"));
		
		
	}
}