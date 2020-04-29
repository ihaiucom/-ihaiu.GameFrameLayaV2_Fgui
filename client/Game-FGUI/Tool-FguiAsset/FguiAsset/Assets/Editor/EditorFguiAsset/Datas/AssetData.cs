using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using UnityEngine;

namespace EditorFguiAssets
{
    public class AssetData
    {
        public Package package;

        public ResourceComponentType type;
        public string id;
        // 文件名
        public string name;
        // 包内 文件夹路径
        public string path;
        // 是否设置为导出
        public bool exported;


        // 相对包路径
        public string fileNameForPackage;
        // 相对包路径
        public string pathForPackage;
        // 相对assets路径
        public string pathForAssetsData;
        // 相对assets路径
        public string pathForAssets;
        // 完整路径
        public string pathForFull;
        // md5码
        public string md5;
        // 是否选中
        public bool isSelected;

        // 继承
        public string extention;

        // 控制器列表
        public List<Node> controllerList = new List<Node>();

        // 动效列表
        public List<Node> transitionList = new List<Node>();

        // 显示列表
        public List<Node> displayList = new List<Node>();

        // 显示列表--资源类型的
        public List<Node> assetDisplayList = new List<Node>();

        // 显示列表--Component
        public List<Node> componentList = new List<Node>();


        // 依赖的包列表
        public List<Package> dependPackageList = new List<Package>();

        // 被依赖的组件列表
        public List<AssetData> beDependList = new List<AssetData>();


        // 被依赖的次数
        public int beDependCount
        {
            get
            {
                return beDependList.Count;
            }
        }

        // 是否被导出组件依赖
        public bool hasBeDependForExtported = false;

        public void AddDependPackage(Package package)
        {
            if (!dependPackageList.Contains(package))
            {
                dependPackageList.Add(package);
            }
        }



        public void AddNode(Node node)
        {
            node.parent = this;
            displayList.Add(node);
            switch(node.type)
            {
                case fairygui.CommonName.GImage:
                case fairygui.CommonName.GMovieClip:
                case fairygui.CommonName.GComponent:
                case fairygui.CommonName.GLoader:
                case fairygui.CommonName.GList:
                    assetDisplayList.Add(node);
                    break;
            }


            switch (node.type)
            {
                case fairygui.CommonName.GComponent:
                    componentList.Add(node);
                    break;
            }

        }

        // URL
        public string URL
        {
            get
            {
                return string.Format("ui://{0}{1}", package.id, id); ;
            }
        }


        static Regex EnableRegex = new Regex("^[A-Za-z_]+[A-Za-z0-9_]*");

        public bool classNameIsEnable
        {
            get
            {
                return EnableRegex.IsMatch(className);
            }
        }

        public bool isIngore
        {
            get
            {
                if (package.genCode == false)
                {
                    return true;
                }

                if (name.StartsWith("_"))
                {
                    return true;
                }

                if (Setting.Options.codeIgnorNoExported)
                {
                    if (exported == false)
                    {
                        if (Setting.Options.codeExportDepend)
                        {
                            if (!hasBeDependForExtported)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                }

                if (Setting.Options.codeIgnorIllegalClassName)
                {
                    return !classNameIsEnable;
                }
                else
                    return false;
            }
        }

        // 类名
        private string _className;
        public string className
        {
            get
            {
                if (string.IsNullOrEmpty(_className))
                {
                    if (Setting.Options.codeIgnorIllegalClassName)
                    {
                        _className = Path.GetFileNameWithoutExtension(name).FirstUpper();
                    }
                    else
                    {
                        _className = Regex.Replace(Path.GetFileNameWithoutExtension(name), @"[^A-Za-z0-9_]", @"").FirstUpper();
                    }

                }
                return _className;
            }

            set
            {
                _className = value;
            }
        }


        // 继承类 名
        private string _extendClassName;
        public string extendClassName
        {
            get
            {
                if (string.IsNullOrEmpty(_extendClassName))
                {
                    _extendClassName = fairygui.ExtendType.GetExtendClass(extention);
                }
                return _extendClassName;
            }


            set
            {
                _extendClassName = value;
            }
        }

        // 包名
        public string packageName
        {
            get
            {
                return package.name;
            }
        }

        // 命名空间
        public string nameSpace
        {
            get
            {
                return package.nameSpace;
            }


        }


        // 继承类
        public string classNameFGUI
        {
            get
            {
                return extendClassName;
            }
        }



        // 扩展类名
        public string classNameExtend
        {
            get
            {
                return className;
            }
        }



        // 类全名,包含命名空间
        public string classNameFull
        {
            get
            {
                return nameSpace + "." + classNameExtend;
            }
        }


        // 结构类名
        private string _classNameStruct;
        public string classNameStruct
        {
            get
            {
                return className + "Struct";
            }
        }

        // 如果是图片
        private Texture2D _texture;

        public Texture2D texture
        {
            get
            {
                if(_texture == null)
                {
                    if(type == ResourceComponentType.image)
                    {
                        _texture = EditorTexture2D.Load(pathForFull);
                    }
                }
                return _texture;
            }
        }

        // 如果是组件
        public XmlDocument xmlDocument;

        // 被依赖的资源替换
        public void BeDependListReplace(AssetData dest)
        {

            foreach (AssetData refFile in beDependList)
            {
                refFile.ReplaceImage(this, dest);
            }
        }

        // 替换图片引用
        public void ReplaceImage(AssetData item, AssetData main)
        {
            //XmlNodeList xnList = xmlDocument.SelectNodes("/component/displayList/image[@src='" + item.id + "']");
            //foreach (XmlElement xn in xnList)
            //{
            //    xn.SetAttribute("src", main.id);
            //    xn.SetAttribute("pkg", main.package.id);
            //    xn.SetAttribute("fileName", main.fileNameForPackage);
            //}


            //xnList = xmlDocument.SelectNodes("/component/displayList/loader[@url='" + item.URL + "']");
            //foreach (XmlElement xn in xnList)
            //{
            //    xn.SetAttribute("url", main.URL);
            //}


            //xnList = xmlDocument.SelectNodes("/component/displayList/component/Label[@icon='" + item.URL + "']");
            //foreach (XmlElement xn in xnList)
            //{
            //    xn.SetAttribute("icon", main.URL);
            //}

            //xnList = xmlDocument.SelectNodes("/component/displayList/component/Button[@icon='" + item.URL + "']");
            //foreach (XmlElement xn in xnList)
            //{
            //    xn.SetAttribute("icon", main.URL);
            //}

            //xnList = xmlDocument.SelectNodes("/component/displayList/component/Button[@selectedIcon='" + item.URL + "']");
            //foreach (XmlElement xn in xnList)
            //{
            //    xn.SetAttribute("selectedIcon", main.URL);
            //}

            //xmlDocument.Save(pathForFull);

            ReplaceImage(item.URL, main.URL,
                item.id, main.id,
                item.package.id, main.package.id,
                item.fileNameForPackage, main.fileNameForPackage
                );


        }

        public void ReplaceImage(string srcUrl, string destUrl, 
            string srcId, string destId,
            string srcPkgId, string destPkgId,
            string srcFileName, string destFileName
            )
        {
            XmlNodeList xnList = xmlDocument.SelectNodes("/component/displayList/image[@src='" + srcId + "']");
            foreach (XmlElement xn in xnList)
            {
                xn.SetAttribute("src", destId);
                xn.SetAttribute("pkg", destPkgId);
                xn.SetAttribute("fileName", destFileName);
            }


            xnList = xmlDocument.SelectNodes("/component/displayList/loader[@url='" + srcUrl + "']");
            foreach (XmlElement xn in xnList)
            {
                xn.SetAttribute("url", destUrl);
            }


            xnList = xmlDocument.SelectNodes("/component/displayList/component/Label[@icon='" + srcUrl + "']");
            foreach (XmlElement xn in xnList)
            {
                xn.SetAttribute("icon", destUrl);
            }

            xnList = xmlDocument.SelectNodes("/component/displayList/component/Button[@icon='" + srcUrl + "']");
            foreach (XmlElement xn in xnList)
            {
                xn.SetAttribute("icon", destUrl);
            }

            xnList = xmlDocument.SelectNodes("/component/displayList/component/Button[@selectedIcon='" + srcUrl + "']");
            foreach (XmlElement xn in xnList)
            {
                xn.SetAttribute("selectedIcon", destUrl);
            }

            xnList = xmlDocument.SelectNodes("//gearIcon");
            foreach (XmlElement xn in xnList)
            {
                if(xn.HasAttribute("values"))
                {
                    if(xn.GetAttribute("values").IndexOf(srcUrl) != - 1)
                        xn.SetAttribute("values", xn.GetAttribute("values").Replace(srcUrl, destUrl));
                }

                if(xn.HasAttribute("default"))
                {
                    if (xn.GetAttribute("default") == srcUrl)
                        xn.SetAttribute("default", destUrl);
                }
            }

            xmlDocument.Save(pathForFull);
        }


        public void ShowInExplorerForCommon()
        {
            Package commonPackage = FairyManager.Instance.GetPackageByName("Common");

            if (package == commonPackage)
            {
                return;
            }

            string commonPathForFull = commonPackage.rootPath + path + name;

            Shell.ShowInExplorer(commonPathForFull);
        }


        // 移植到Common
        public void MoveToCommon()
        {
            if(FairyManager.Instance.ignorePackageDict.ContainsKey(package.folderName))
            {
                return;
            }

            Package commonPackage = FairyManager.Instance.GetPackageByName("Common");
            
            if(package == commonPackage)
            {
                return;
            }

            if(commonPackage.GetResource(id) != null)
            {
                UnityEngine.Debug.LogFormat("[警告] Common已经存在id= {0},  需要移植的{1}", id, pathForAssets);
                return;
            }



            Package oldPackage = package;
            string oldUrl = URL;
            string oldPathForFull = pathForFull;
            string commonPathForFull = commonPackage.rootPath + path + name;
            if (File.Exists(commonPathForFull))
            {
                UnityEngine.Debug.LogFormat("[警告] 已经存在 {0},  需要移植的{1}", commonPathForFull, oldPathForFull);
                return;
            }

            PathUtil.CheckPath(commonPathForFull);
            File.Move(oldPathForFull, commonPathForFull);


            XmlNode xmlNode = package.RemoveImageXml(this);
            commonPackage.AddImageXml((XmlElement) xmlNode);

            package.RemoveResource(this);
            commonPackage.AddResource(this);

            package = commonPackage;
            pathForPackage = path + name;
            fileNameForPackage = pathForPackage.Substring(1, pathForPackage.Length - 1);
            pathForAssets = "assets/" + commonPackage.folderName + path + name;
            pathForAssetsData = commonPackage.folderName + path + name;
            pathForFull = package.rootPath + path + name;




            foreach(AssetData item in beDependList)
            {
                item.ReplaceImage(oldUrl, URL, id, id, oldPackage.id, package.id, fileNameForPackage, fileNameForPackage);
            }



        }


    }
}