/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import Tree from "../../Extends/GameGM/Tree";

export default class TreeStruct extends fgui.GComponent
{

	
	public static URL:string = "ui://ujw583ypx6hop";
	
	public static DependPackages:string[] = ["GameGM"];

	
	public static createInstance():Tree {
		return <Tree><any>(fgui.UIPackage.createObject("GameGM","Tree"));
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