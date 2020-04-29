using ETModel;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using UnityEditor;

namespace EditorFguiAssets
{
    public class FairyManager
    {
        private static FairyManager _Instance;
        public static FairyManager Instance
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new FairyManager();
                }
                return _Instance;
            }
        }

        // 忽略的包名
        public Dictionary<string, bool> ignorePackageDict = new Dictionary<string, bool>();
        private string _ignorePackageStr;
        public string ignorePackageStr
        {
            set{
                if(_ignorePackageStr !=  value)
                {
                    ignorePackageDict.Clear();
                    string[] arr = value.Replace("\r\n", "\n").Split('\n');
                    foreach(string item in arr)
                    {
                        if (string.IsNullOrEmpty(item.Trim()))
                            continue;
                        if (!ignorePackageDict.ContainsKey(item))
                            ignorePackageDict.Add(item, true);
                    }
                }
                _ignorePackageStr = value;
            }
        }

        // 代码使用的资源
        public Dictionary<string, bool> codeUseDict = new Dictionary<string, bool>();
        private string _codeUsesStr;
        public string codeUsesStr
        {
            set
            {
                if (_codeUsesStr != value)
                {
                    codeUseDict.Clear();
                    string[] arr = value.Replace("\r\n", "\n").Split('\n');
                    foreach (string item in arr)
                    {
                        if (string.IsNullOrEmpty(item.Trim()))
                            continue;

                        if (!codeUseDict.ContainsKey(item))
                            codeUseDict.Add(item, true);
                    }
                }
                _codeUsesStr = value;
            }
        }


        List<Package> packageList = new List<Package>();
        QueueDictionary<string, Package> packages = new QueueDictionary<string, Package>();
        Dictionary<string, Package> packagesByName = new Dictionary<string, Package>();


        public void AddPackage(Package package)
        {
            packageList.Add(package);
            packages.Enqueue(package.id, package);
            packagesByName.Add(package.name, package);
        }

        public Package GetPackage(string packageId)
        {
            if (string.IsNullOrEmpty(packageId))
                return null;

            if (packages.ContainsKey(packageId))
            {
                return packages[packageId];
            }
            return null;
        }

        public Package GetPackageByName(string packageName)
        {
            if (packagesByName.ContainsKey(packageName))
            {
                return packagesByName[packageName];
            }
            return null;
        }

        public AssetData GetRescoureComponent(string packageId, string resId)
        {
            Package package = GetPackage(packageId);
            if (package != null)
            {
                package.GetResource(resId);
            }
            return null;
        }

        public List<AssetData> GetAssetDataForGearIcon(string icons)
        {
            if (!string.IsNullOrEmpty(icons))
            {
                List<AssetData> list = new List<AssetData>();
                string[] arr = icons.Split('|');
                for(int i = 0; i < arr.Length; i ++)
                {
                    list.Add(GetAssetDataByUrl(arr[i]));
                }
                return list;

            }
            return null;
        }

        public AssetData GetAssetDataByUrl(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                string pkg = url.Substring(5, 8);
                string src = url.Substring(5 + 8, url.Length - 5 - 8);

                Package package = GetPackage(pkg);
                if (package != null)
                {
                    return package.GetResource(src);
                }
            }
            return null;
        }


        public AssetData GetRescoureComponent(Node node)
        {
            string pkg = null;
            string src = null;

            switch (node.type)
            {
                case fairygui.CommonName.GLoader:
                    if(!string.IsNullOrEmpty(node.url))
                    {
                        pkg = node.url.Substring(5, 8);
                        src = node.url.Substring(5 + 8, node.url.Length - 5 - 8);
                        node.pkg = pkg;
                        node.src = src;
                    }
                    break;
                case fairygui.CommonName.GList:
                    if (!string.IsNullOrEmpty(node.defaultItem))
                    {
                        pkg = node.defaultItem.Substring(5, 8);
                        src = node.defaultItem.Substring(5 + 8, node.defaultItem.Length - 5 - 8);

                        node.pkg = pkg;
                        node.src = src;
                    }
                    break;

                case fairygui.CommonName.GImage:
                case fairygui.CommonName.GMovieClip:
                case fairygui.CommonName.GComponent:
                    pkg = node.pkg;
                    src = node.src;
                    break;
            }

            if (string.IsNullOrEmpty(pkg) && node.parent != null && src != null)
            {
                return node.parent.package.GetResource(src);
            }

            Package package = GetPackage(pkg);
            if (package != null)
            {
                return package.GetResource(src);
            }

            return null;
        }

        public void Clearn()
        {
            packageList.Clear();
            packages.Clear();
            packagesByName.Clear();

            md5Dict.Clear();
            simpleMD5List.Clear();
        }

        /// <summary>
        /// 加载Fgui项目资源信息
        /// </summary>
        public void LoadProject(string projectPath)
        {
            Clearn();
            string root = projectPath + "/assets";
            string[] dirs = Directory.GetDirectories(root);

            for (int i = 0; i < dirs.Length; i++)
            {

                string packageXmlPath = dirs[i] + "/package.xml";
                if (File.Exists(packageXmlPath))
                {
                    if (i % 10 == 0)
                        EditorUtility.DisplayProgressBar("读取包", packageXmlPath, i * 1f / dirs.Length);
                    Package package = PackageReader.Load(packageXmlPath);
                    AddPackage(package);
                }
            }

            EditorUtility.ClearProgressBar();

            LoadComponent();
            SetComponentNode();

            EditorUtility.ClearProgressBar();
        }

        private void LoadComponent()
        {
            int i = 0;
            int count = packageList.Count;
            foreach (Package package in packageList)
            {
                EditorUtility.DisplayProgressBar("读取包组件", package.folderName, i * 1f / count);
                i++;
                foreach (AssetData component in package.ComponentList)
                {
                    string path = package.rootPath + component.path + component.name;
                    ComponentReader.Load(path, component);
                }
            }

            EditorUtility.ClearProgressBar();
        }

        private void SetComponentNode()
        {
            foreach (Package package in packageList)
            {
                foreach (AssetData component in package.resourcesList)
                {
                    foreach (Node node in component.assetDisplayList)
                    {
                        node.assetData = GetRescoureComponent(node);
                        if (node.assetData == null)
                        {
                            UnityEngine.Debug.LogWarningFormat("没有找到 resourceComponent packagename= {0} comname= {1} nodename={2}", node.parent.package.name, node.parent.name, node.name);
                        }
                        else
                        {
                            // 添加被依赖
                            node.assetData.beDependList.Add(component);
                            if (component.exported)
                            {
                                node.assetData.hasBeDependForExtported = true;
                            }

                            if(node.type == fairygui.CommonName.GComponent)
                            {

                                if (!string.IsNullOrEmpty(node.labelIcon))
                                {
                                    node.labelIconAssetData = GetAssetDataByUrl(node.labelIcon);
                                    if(node.labelIconAssetData != null) node.labelIconAssetData.beDependList.Add(component);
                                }


                                if (!string.IsNullOrEmpty(node.buttonIcon))
                                {
                                    node.buttonIconAssetData = GetAssetDataByUrl(node.buttonIcon);
                                    if (node.buttonIconAssetData != null) node.buttonIconAssetData.beDependList.Add(component);
                                }

                                if (!string.IsNullOrEmpty(node.buttonSelectIcon))
                                {
                                    node.buttonSelectIconAssetData = GetAssetDataByUrl(node.buttonSelectIcon);
                                    if (node.buttonSelectIconAssetData != null)  node.buttonSelectIconAssetData.beDependList.Add(component);
                                }
                            }

                            // 控制器中依赖的资源
                            if(!string.IsNullOrEmpty(node.gearIconUrls))
                            {
                                node.gearIconAssetDatas = GetAssetDataForGearIcon(node.gearIconUrls);
                                if(node.gearIconAssetDatas != null)
                                {
                                    for (int ii = 0; ii < node.gearIconAssetDatas.Count; ii++)
                                    {
                                        AssetData gearIcon = node.gearIconAssetDatas[ii];
                                        if (gearIcon != null)
                                            gearIcon.beDependList.Add(component);
                                    }
                                }
                            }

                            if (!string.IsNullOrEmpty(node.gearDefault))
                            {

                                node.gearDefaultAssetData = GetAssetDataByUrl(node.gearDefault);
                                if (node.gearDefaultAssetData != null) node.gearDefaultAssetData.beDependList.Add(component);

                            }
                        }
                    }
                }
            }

            int i = 0;
            int count = packageList.Count;
            // 生成依赖的包列表
            foreach (Package package in packageList)
            {

                if(i % 10 == 0)
                    EditorUtility.DisplayProgressBar("生成依赖的包列表", package.folderName, i * 1f / count);
                i++;
                foreach (AssetData component in package.resourcesList)
                {
                    component.AddDependPackage(package);
                    TraverseDependPackage(component, component);


                    foreach (Node node in component.displayList)
                    {
                        if (node.pkg != null)
                        {
                            Package pkg = GetPackage(node.pkg);
                            if (pkg != null)
                            {
                                component.AddDependPackage(pkg);
                            }
                        }
                    }
                }
            }

            EditorUtility.ClearProgressBar();

        }

        void TraverseDependPackage(AssetData component, AssetData root)
        {

            foreach (Node node in component.assetDisplayList)
            {
                if (node.assetData != null)
                {
                    root.AddDependPackage(node.assetData.package);
                    TraverseDependPackage(node.assetData, root);
                }

                if(node.labelIconAssetData != null)
                {
                    root.AddDependPackage(node.labelIconAssetData.package);
                }

                if (node.buttonIconAssetData != null)
                {
                    root.AddDependPackage(node.buttonIconAssetData.package);
                }

                if (node.buttonSelectIconAssetData != null)
                {
                    root.AddDependPackage(node.buttonSelectIconAssetData.package);
                }


                if (node.gearIconAssetDatas != null)
                {
                    for (int ii = 0; ii < node.gearIconAssetDatas.Count; ii++)
                    {
                        AssetData gearIcon = node.gearIconAssetDatas[ii];
                        if (gearIcon != null)
                            root.AddDependPackage(gearIcon.package);
                    }
                }


                if (node.gearDefaultAssetData != null)
                {
                    root.AddDependPackage(node.gearDefaultAssetData.package);
                }
            }
        }

        // MD5码字典
        Dictionary<string, List<AssetData>> md5Dict = new Dictionary<string, List<AssetData>>();
        // 相同资源列表
        public List<List<AssetData>> simpleMD5List = new List<List<AssetData>>();

        // 没使用的资源
        public List<AssetData> nouseList = new List<AssetData>();

        // 使用了的资源
        public List<AssetData> useList = new List<AssetData>();

        /// <summary>
        /// 生成MD5码
        /// </summary>
        public void GenerateMD5()
        {
            md5Dict.Clear();

            foreach (Package package in packageList)
            {
                if (ignorePackageDict.ContainsKey(package.folderName))
                {
                    continue;
                }

                int i = 0;
                int count = package.resourcesList.Count;
                foreach (AssetData asset in package.resourcesList)
                {
                    if(i % 10 == 0)
                        EditorUtility.DisplayProgressBar("查找相同的文件 " + package.folderName, asset.pathForAssets, i * 1f / count);
                    i++;

                    if (asset.type == ResourceComponentType.component)
                        continue;

                    asset.md5 = PathUtil.md5file(asset.pathForFull);
                    List<AssetData> list = null;
                    if (md5Dict.ContainsKey(asset.md5))
                    {
                        list = md5Dict[asset.md5];
                    }
                    else
                    {
                        list = md5Dict[asset.md5] = new List<AssetData>();
                    }

                    list.Add(asset);
                }
            }


            simpleMD5List.Clear();

            foreach (var kvp in md5Dict)
            {
                if (kvp.Value.Count > 1)
                {
                    simpleMD5List.Add(kvp.Value);
                }
            }

            nouseList.Clear();
            useList.Clear();
            foreach (Package package in packageList)
            {
                foreach (AssetData asset in package.resourcesList)
                {
                    if(asset.beDependCount == 0 && !codeUseDict.ContainsKey(asset.pathForAssetsData) && (asset.type == ResourceComponentType.image || asset.type == ResourceComponentType.movieclip))
                    {
                        nouseList.Add(asset);
                    }
                    else
                    {
                        useList.Add(asset);
                    }
                }
            }


            EditorUtility.ClearProgressBar();
        }

    }
}