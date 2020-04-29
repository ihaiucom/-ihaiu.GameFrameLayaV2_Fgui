/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import GMPopupButton from "../../Extends/GameGM/GMPopupButton";
import TextInput from "../../Extends/GameGM/TextInput";
import Checkbox from "../../Extends/GameGM/Checkbox";
import ButtonRect from "../../Extends/GameGM/ButtonRect";
import GMAddPage from "../../Extends/GameGM/GMAddPage";

export default class GMAddPageStruct extends fgui.GComponent
{
	public m_list : fgui.GList;
	public m_popupButton : GMPopupButton;
	public m_filterInput : TextInput;
	public m_filterCheckbox : Checkbox;
	public m_listTopButton : ButtonRect;
	public m_listBottomButton : ButtonRect;

	
	public static URL:string = "ui://ujw583ypfbyi9";
	
	public static DependPackages:string[] = ["GameGM"];

	
	public static createInstance():GMAddPage {
		return <GMAddPage><any>(fgui.UIPackage.createObject("GameGM","GMAddPage"));
	}

	

	public constructor() 
	{
		super();
	}

	protected constructFromXML(xml: any): void 
	{
		super.constructFromXML(xml);
		

		
		this.m_list = <fgui.GList><any>(this.getChild("list"));
		this.m_popupButton = <GMPopupButton><any>(this.getChild("popupButton"));
		this.m_filterInput = <TextInput><any>(this.getChild("filterInput"));
		this.m_filterCheckbox = <Checkbox><any>(this.getChild("filterCheckbox"));
		this.m_listTopButton = <ButtonRect><any>(this.getChild("listTopButton"));
		this.m_listBottomButton = <ButtonRect><any>(this.getChild("listBottomButton"));
		
		
	}
}