/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import GMSelectServerPage from "../../Extends/GameGM/GMSelectServerPage";

export default class GMSelectServerPageStruct extends fgui.GComponent
{
	public m_list : fgui.GList;

	
	public static URL:string = "ui://ujw583ypket7j";
	
	public static DependPackages:string[] = ["GameGM"];

	
	public static createInstance():GMSelectServerPage {
		return <GMSelectServerPage><any>(fgui.UIPackage.createObject("GameGM","GMSelectServerPage"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		

		
		this.m_list = <fgui.GList><any>(this.getChild("list"));
		
		
	}
}