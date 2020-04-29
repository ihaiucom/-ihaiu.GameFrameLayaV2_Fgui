/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import GMSubMenuBar from "../../Extends/GameGM/GMSubMenuBar";
import ButtonRect from "../../Extends/GameGM/ButtonRect";
import GMDebugPage from "../../Extends/GameGM/GMDebugPage";

export default class GMDebugPageStruct extends fgui.GComponent
{
	public m_list : fgui.GList;
	public m_subMenuBar : GMSubMenuBar;
	public m_clearButton : ButtonRect;
	public m_refreshButton : ButtonRect;

	
	public static URL:string = "ui://ujw583ypfbyi8";
	
	public static DependPackages:string[] = ["GameGM"];

	
	public static createInstance():GMDebugPage {
		return <GMDebugPage><any>(fgui.UIPackage.createObject("GameGM","GMDebugPage"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		

		
		this.m_list = <fgui.GList><any>(this.getChild("list"));
		this.m_subMenuBar = <GMSubMenuBar><any>(this.getChild("subMenuBar"));
		this.m_clearButton = <ButtonRect><any>(this.getChild("clearButton"));
		this.m_refreshButton = <ButtonRect><any>(this.getChild("refreshButton"));
		
		
	}
}