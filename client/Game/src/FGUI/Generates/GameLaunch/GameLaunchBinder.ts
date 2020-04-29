/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////


import EnterModuleLoader from "../../Extends/GameLaunch/EnterModuleLoader";
import ScreenBG from "../../Extends/GameLaunch/ScreenBG";
import DialogCloseWindow from "../../Extends/GameLaunch/DialogCloseWindow";
import SystemAlertMessage from "../../Extends/GameLaunch/SystemAlertMessage";
import SystemConfirmMessage from "../../Extends/GameLaunch/SystemConfirmMessage";
import SystemToastMessage from "../../Extends/GameLaunch/SystemToastMessage";
import GMButton from "../../Extends/GameLaunch/GMButton";
import EnterWarLoader from "../../Extends/GameLaunch/EnterWarLoader";
import EnterWarItem from "../../Extends/GameLaunch/EnterWarItem";
import BGModel from "../../Extends/GameLaunch/BGModel";
import GlobalModalWaiting from "../../Extends/GameLaunch/GlobalModalWaiting";
import WindowModalWaiting from "../../Extends/GameLaunch/WindowModalWaiting";
import EnterLoginLoader from "../../Extends/GameLaunch/EnterLoginLoader";

export default class GameLaunchBinder
{
	public static bindAll():void 
	{
		let bind = fgui.UIObjectFactory.setPackageItemExtension;
		bind(EnterModuleLoader.URL, EnterModuleLoader);
		bind(ScreenBG.URL, ScreenBG);
		bind(DialogCloseWindow.URL, DialogCloseWindow);
		bind(SystemAlertMessage.URL, SystemAlertMessage);
		bind(SystemConfirmMessage.URL, SystemConfirmMessage);
		bind(SystemToastMessage.URL, SystemToastMessage);
		bind(GMButton.URL, GMButton);
		bind(EnterWarLoader.URL, EnterWarLoader);
		bind(EnterWarItem.URL, EnterWarItem);
		bind(BGModel.URL, BGModel);
		bind(GlobalModalWaiting.URL, GlobalModalWaiting);
		bind(WindowModalWaiting.URL, WindowModalWaiting);
		bind(EnterLoginLoader.URL, EnterLoginLoader);
	}
}