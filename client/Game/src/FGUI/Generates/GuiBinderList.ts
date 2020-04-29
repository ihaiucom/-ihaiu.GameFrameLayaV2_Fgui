/////////////////////////////////////
// ihaiu.ExportFairyGUICode生成
// http://blog.ihaiu.com
/////////////////////////////////////

import GameGMBinder from "./GameGM/GameGMBinder";
import GameLaunchBinder from "./GameLaunch/GameLaunchBinder";

export default class GuiBinderList
{
	static fguiBinderAll()
	{
		GameGMBinder.bindAll()
		GameLaunchBinder.bindAll()
	}
}