/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import GMSubMenuRadioBar from "../../Extends/GameGM/GMSubMenuRadioBar";
import TextArea from "../../Extends/GameGM/TextArea";
import ButtonRect from "../../Extends/GameGM/ButtonRect";
import GMCmdPage from "../../Extends/GameGM/GMCmdPage";

export default class GMCmdPageStruct extends fgui.GComponent
{
	public m_list : fgui.GList;
	public m_subMenuBar : GMSubMenuRadioBar;
	public m_input : TextArea;
	public m_sendButton : ButtonRect;
	public m_clearButton : ButtonRect;

	
	public static URL:string = "ui://ujw583ypket7k";
	
	public static DependPackages:string[] = ["GameGM"];

	
	public static createInstance():GMCmdPage {
		return <GMCmdPage><any>(fgui.UIPackage.createObject("GameGM","GMCmdPage"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		

		
		this.m_list = <fgui.GList><any>(this.getChild("list"));
		this.m_subMenuBar = <GMSubMenuRadioBar><any>(this.getChild("subMenuBar"));
		this.m_input = <TextArea><any>(this.getChild("input"));
		this.m_sendButton = <ButtonRect><any>(this.getChild("sendButton"));
		this.m_clearButton = <ButtonRect><any>(this.getChild("clearButton"));
		
		
	}
}