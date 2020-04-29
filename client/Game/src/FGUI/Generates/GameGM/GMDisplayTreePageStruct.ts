/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import Tree from "../../Extends/GameGM/Tree";
import ButtonRect from "../../Extends/GameGM/ButtonRect";
import GMDisplayTreePage from "../../Extends/GameGM/GMDisplayTreePage";

export default class GMDisplayTreePageStruct extends fgui.GComponent
{
	public m_tree : Tree;
	public m_refreshButton : ButtonRect;
	public m_showSelectButton : ButtonRect;
	public m_hideSelectButton : ButtonRect;
	public m_noSelectButton : ButtonRect;
	public m_parentLayerButton : ButtonRect;
	public m_setLayerButton : ButtonRect;

	
	public static URL:string = "ui://ujw583ypx6hov";
	
	public static DependPackages:string[] = ["GameGM"];

	
	public static createInstance():GMDisplayTreePage {
		return <GMDisplayTreePage><any>(fgui.UIPackage.createObject("GameGM","GMDisplayTreePage"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		

		
		this.m_tree = <Tree><any>(this.getChild("tree"));
		this.m_refreshButton = <ButtonRect><any>(this.getChild("refreshButton"));
		this.m_showSelectButton = <ButtonRect><any>(this.getChild("showSelectButton"));
		this.m_hideSelectButton = <ButtonRect><any>(this.getChild("hideSelectButton"));
		this.m_noSelectButton = <ButtonRect><any>(this.getChild("noSelectButton"));
		this.m_parentLayerButton = <ButtonRect><any>(this.getChild("parentLayerButton"));
		this.m_setLayerButton = <ButtonRect><any>(this.getChild("setLayerButton"));
		
		
	}
}