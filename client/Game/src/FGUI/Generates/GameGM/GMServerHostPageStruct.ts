/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import TextArea from "../../Extends/GameGM/TextArea";
import ButtonRect from "../../Extends/GameGM/ButtonRect";
import Checkbox from "../../Extends/GameGM/Checkbox";
import GMServerHostPage from "../../Extends/GameGM/GMServerHostPage";

export default class GMServerHostPageStruct extends fgui.GComponent
{
	public m_ipIput : TextArea;
	public m_addButton : ButtonRect;
	public m_portInput : TextArea;
	public m_isHttpCheckbox : Checkbox;

	
	public static URL:string = "ui://ujw583ypi8be13";
	
	public static DependPackages:string[] = ["GameGM"];

	
	public static createInstance():GMServerHostPage {
		return <GMServerHostPage><any>(fgui.UIPackage.createObject("GameGM","GMServerHostPage"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		

		
		this.m_ipIput = <TextArea><any>(this.getChild("ipIput"));
		this.m_addButton = <ButtonRect><any>(this.getChild("addButton"));
		this.m_portInput = <TextArea><any>(this.getChild("portInput"));
		this.m_isHttpCheckbox = <Checkbox><any>(this.getChild("isHttpCheckbox"));
		
		
	}
}