/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import ButtonCorner from "../../Extends/GameGM/ButtonCorner";
import GMCmdItem from "../../Extends/GameGM/GMCmdItem";

export default class GMCmdItemStruct extends fgui.GComponent
{
	public m_title : fgui.GTextInput;
	public m_name : fgui.GRichTextField;
	public m_button : ButtonCorner;

	
	public static URL:string = "ui://ujw583ypket7n";
	
	public static DependPackages:string[] = ["GameGM"];

	
	public static createInstance():GMCmdItem {
		return <GMCmdItem><any>(fgui.UIPackage.createObject("GameGM","GMCmdItem"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		

		
		this.m_title = <fgui.GTextInput><any>(this.getChild("title"));
		this.m_name = <fgui.GRichTextField><any>(this.getChild("name"));
		this.m_button = <ButtonCorner><any>(this.getChild("button"));
		
		
	}
}