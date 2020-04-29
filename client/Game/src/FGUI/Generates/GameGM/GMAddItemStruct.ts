/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import ButtonCorner from "../../Extends/GameGM/ButtonCorner";
import NumberInput from "../../Extends/GameGM/NumberInput";
import GMAddItem from "../../Extends/GameGM/GMAddItem";

export default class GMAddItemStruct extends fgui.GComponent
{
	public m_id : fgui.GRichTextField;
	public m_title : fgui.GRichTextField;
	public m_describe : fgui.GRichTextField;
	public m_icon : fgui.GLoader;
	public m_num : fgui.GRichTextField;
	public m_button : ButtonCorner;
	public m_numberInput : NumberInput;

	
	public static URL:string = "ui://ujw583ypfv0tc";
	
	public static DependPackages:string[] = ["GameGM"];

	
	public static createInstance():GMAddItem {
		return <GMAddItem><any>(fgui.UIPackage.createObject("GameGM","GMAddItem"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		

		
		this.m_id = <fgui.GRichTextField><any>(this.getChild("id"));
		this.m_title = <fgui.GRichTextField><any>(this.getChild("title"));
		this.m_describe = <fgui.GRichTextField><any>(this.getChild("describe"));
		this.m_icon = <fgui.GLoader><any>(this.getChild("icon"));
		this.m_num = <fgui.GRichTextField><any>(this.getChild("num"));
		this.m_button = <ButtonCorner><any>(this.getChild("button"));
		this.m_numberInput = <NumberInput><any>(this.getChild("numberInput"));
		
		
	}
}