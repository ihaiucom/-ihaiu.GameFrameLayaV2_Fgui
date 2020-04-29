/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import ButtonRect from "../../Extends/GameGM/ButtonRect";
import GMTimeLoopPage from "../../Extends/GameGM/GMTimeLoopPage";

export default class GMTimeLoopPageStruct extends fgui.GComponent
{
	public m_list : fgui.GList;
	public m_refreshButton : ButtonRect;
	public m_clearButton : ButtonRect;
	public m_sortCostTimeToalButton : ButtonRect;
	public m_sorteEvaluateButton : ButtonRect;
	public m_sorteCallNumButton : ButtonRect;
	public m_sorteCostTimeButton : ButtonRect;

	
	public static URL:string = "ui://ujw583yp7h8s10";
	
	public static DependPackages:string[] = ["GameGM"];

	
	public static createInstance():GMTimeLoopPage {
		return <GMTimeLoopPage><any>(fgui.UIPackage.createObject("GameGM","GMTimeLoopPage"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		

		
		this.m_list = <fgui.GList><any>(this.getChild("list"));
		this.m_refreshButton = <ButtonRect><any>(this.getChild("refreshButton"));
		this.m_clearButton = <ButtonRect><any>(this.getChild("clearButton"));
		this.m_sortCostTimeToalButton = <ButtonRect><any>(this.getChild("sortCostTimeToalButton"));
		this.m_sorteEvaluateButton = <ButtonRect><any>(this.getChild("sorteEvaluateButton"));
		this.m_sorteCallNumButton = <ButtonRect><any>(this.getChild("sorteCallNumButton"));
		this.m_sorteCostTimeButton = <ButtonRect><any>(this.getChild("sorteCostTimeButton"));
		
		
	}
}