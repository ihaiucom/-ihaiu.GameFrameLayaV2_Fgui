using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace EditorFguiAssets
{
    public class Node
    {
        // 节点名称
        public string name;
        // 节点类型
        public string type;


        // 资源所在包ID
        public string pkg;
        // 资源ID
        public string src;

        // 装置器使用的资源
        public string url;
        // 装载器中控制器使用的资源列表
        public string gearIconUrls;
        public List<AssetData> gearIconAssetDatas = new List<AssetData>();
        public string gearDefault;
        public AssetData gearDefaultAssetData;
        // 列表使用的资源
        public string defaultItem;

        // 如果是组件，扩展是 Label
        public string labelIcon;
        public AssetData labelIconAssetData;

        // 如果是组件，扩展是Button
        public string buttonIcon;
        public string buttonSelectIcon;
        public AssetData buttonIconAssetData;
        public AssetData buttonSelectIconAssetData;


        // 生成代码时， 字段名
        private string _fieldName;
        public string fieldName
        {
            get
            {
                if (string.IsNullOrEmpty(_fieldName))
                {
                    _fieldName = Setting.Options.codeMemberNamePrefix + name;
                }
                return _fieldName;
            }
        }

        // 生成代码时，是否忽略生成该字段
        static Regex IngoreRegex = new Regex("^n[0-9]+$");
        public bool isIngore
        {
            get
            {
                if (Setting.Options.codeIgnoreNoname)
                {
                    if (name.StartsWith("_"))
                        return true;

                    return IngoreRegex.IsMatch(name);
                }
                else
                    return false;
            }
        }

        // 节点所在组件资源
        public AssetData parent;
        // 节点使用的节点资源
        public AssetData assetData;

        // 生成代码时，该节点字段类型
        public string GetType(AssetData com)
        {
            if (assetData == null)
            {
                return fairygui.CommonName.GObject;
            }

            if (assetData.isIngore)
            {
                return assetData.extendClassName;
            }

            if (com.package == assetData.package)
            {
                return assetData.classNameExtend;
            }
            else
            {
                if (Setting.Options.codeUseOtherPkgType)
                {
                    return assetData.classNameFull;
                }
                else
                {
                    return assetData.extendClassName;
                }
            }
        }



    }
}

