/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import WindowModalWaiting from "../../Extends/GameLaunch/WindowModalWaiting";

export default class WindowModalWaitingStruct extends fgui.GComponent
{
	public m_rotation : fgui.Transition;
	public m_circle : fgui.GImage;

	
	public static URL:string = "ui://47qsdr42x6asw2j";
	
	public static DependPackages:string[] = ["GameLaunch"];

	
	public static createInstance():WindowModalWaiting {
		return <WindowModalWaiting><any>(fgui.UIPackage.createObject("GameLaunch","WindowModalWaiting"));
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