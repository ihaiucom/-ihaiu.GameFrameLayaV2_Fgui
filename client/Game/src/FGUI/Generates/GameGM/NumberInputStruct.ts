/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import NumberInput from "../../Extends/GameGM/NumberInput";

export default class NumberInputStruct extends fgui.GComponent
{
	public m_title : fgui.GTextInput;
	public m_downButton : fgui.GButton;
	public m_upButton : fgui.GButton;

	
	public static URL:string = "ui://ujw583ypfv0tf";
	
	public static DependPackages:string[] = ["GameGM"];

	
	public static createInstance():NumberInput {
		return <NumberInput><any>(fgui.UIPackage.createObject("GameGM","NumberInput"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		

		
		this.m_title = <fgui.GTextInput><any>(this.getChild("title"));
		this.m_downButton = <fgui.GButton><any>(this.getChild("downButton"));
		this.m_upButton = <fgui.GButton><any>(this.getChild("upButton"));
		
		
	}
}