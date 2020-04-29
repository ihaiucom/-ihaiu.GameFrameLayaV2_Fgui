/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import GlobalModalWaiting from "../../Extends/GameLaunch/GlobalModalWaiting";

export default class GlobalModalWaitingStruct extends fgui.GComponent
{
	public m_rotation : fgui.Transition;
	public m_circle : fgui.GImage;

	
	public static URL:string = "ui://47qsdr42x6asw2i";
	
	public static DependPackages:string[] = ["GameLaunch"];

	
	public static createInstance():GlobalModalWaiting {
		return <GlobalModalWaiting><any>(fgui.UIPackage.createObject("GameLaunch","GlobalModalWaiting"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		

		
		this.m_circle = <fgui.GImage><any>(this.getChild("circle"));
		
		
		this.m_rotation =  this.getTransition("rotation");
	}
}