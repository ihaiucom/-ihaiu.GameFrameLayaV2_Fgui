/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import TreeItemCheckbox from "../../Extends/GameGM/TreeItemCheckbox";
import GMTimeLoopItem from "../../Extends/GameGM/GMTimeLoopItem";

export default class GMTimeLoopItemStruct extends fgui.GComponent
{
	public m_title : fgui.GTextField;
	public m_visiable : TreeItemCheckbox;

	
	public static URL:string = "ui://ujw583yp7h8s11";
	
	public static DependPackages:string[] = ["GameGM"];

	
	public static createInstance():GMTimeLoopItem {
		return <GMTimeLoopItem><any>(fgui.UIPackage.createObject("GameGM","GMTimeLoopItem"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		

		
		this.m_title = <fgui.GTextField><any>(this.getChild("title"));
		this.m_visiable = <TreeItemCheckbox><any>(this.getChild("visiable"));
		
		
	}
}