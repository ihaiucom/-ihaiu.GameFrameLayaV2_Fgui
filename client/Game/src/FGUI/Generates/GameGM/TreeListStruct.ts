/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import TreeList from "../../Extends/GameGM/TreeList";

export default class TreeListStruct extends fgui.GComponent
{

	
	public static URL:string = "ui://ujw583ypx6hoz";
	
	public static DependPackages:string[] = ["GameGM"];

	
	public static createInstance():TreeList {
		return <TreeList><any>(fgui.UIPackage.createObject("GameGM","TreeList"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		

		
		
		
	}
}