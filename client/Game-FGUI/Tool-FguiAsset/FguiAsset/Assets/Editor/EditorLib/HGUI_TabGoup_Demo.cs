using System;
using System.Collections.Generic;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      9/20/2017 10:31:41 AM
*  @Description:    
* ==============================================================================
*/
namespace Games
{
    public class HGUI_TabGoup_Demo
    {
        public enum TabType
        {
            [HelpAttribute("开发")]
            Develop,

            [HelpAttribute("App")]
            App,

            [HelpAttribute("补丁")]
            Patch,
        }

        static HGUI.TabGroupData<TabType> _tabGroupData;
        static HGUI.TabGroupData<TabType> tabGroupData
        {
            get
            {
                if (_tabGroupData == null)
                {
                    _tabGroupData = new HGUI.TabGroupData<TabType>();
                    _tabGroupData.AddTab("开发", TabType.Develop);
                    _tabGroupData.AddTab("App", TabType.App);
                    _tabGroupData.AddTab("补丁", TabType.Patch);

                    _tabGroupData.SetSelect(TabType.Develop);
                }
                return _tabGroupData;
            }
        }

        public static void Test()
        {

            TabType tabType = HGUI.TabGroup<TabType>(tabGroupData);
        }
    }
}
