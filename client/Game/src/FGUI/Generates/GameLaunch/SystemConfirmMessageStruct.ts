/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import DialogCloseWindow from "../../Extends/GameLaunch/DialogCloseWindow";
import SystemConfirmMessage from "../../Extends/GameLaunch/SystemConfirmMessage";

export default class SystemConfirmMessageStruct extends fgui.GComponent
{
	public m_content : fgui.GTextField;
	public m_title : fgui.GTextField;
	public m_dialog : DialogCloseWindow;
	public m_okBtn : fgui.GButton;
	public m_cancleBtn : fgui.GButton;

	
	public static URL:string = "ui://47qsdr42nk8t2";
	
	public static DependPackages:string[] = ["GameLaunch"];

	
	public static createInstance():SystemConfirmMessage {
		return <SystemConfirmMessage><any>(fgui.UIPackage.createObject("GameLaunch","SystemConfirmMessage"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		

		
		this.m_content = <fgui.GTextField><any>(this.getChild("content"));
		this.m_title = <fgui.GTextField><any>(this.getChild("title"));
		this.m_dialog = <DialogCloseWindow><any>(this.getChild("dialog"));
		this.m_okBtn = <fgui.GButton><any>(this.getChild("okBtn"));
		this.m_cancleBtn = <fgui.GButton><any>(this.getChild("cancleBtn"));
		
		
	}
}