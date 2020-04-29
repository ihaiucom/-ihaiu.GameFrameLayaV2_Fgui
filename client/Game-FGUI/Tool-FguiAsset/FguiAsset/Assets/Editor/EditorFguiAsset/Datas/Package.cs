using ETModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace EditorFguiAssets
{
    public class Package
    {
        // 包文件夹名
        public string folderName;
        public string rootPath;
        public string pathForFull;
        public XmlDocument xmlDocument;


        public string id;
        // 包名
        public string name;
        public bool genCode;

        public List<AssetData> resourcesList = new List<AssetData>();
        QueueDictionary<string, AssetData> resources = new QueueDictionary<string, AssetData>();
        List<AssetData> components = new List<AssetData>();
        List<AssetData> exportComponents = new List<AssetData>();
        public List<AssetData> sounds = new List<AssetData>();
        public List<AssetData> images = new List<AssetData>();

        public List<AssetData> ComponentList
        {
            get
            {
                return components;
            }
        }

        public void SetImageExport(AssetData assetData, bool export)
        {
            XmlNodeList xnList = xmlDocument.SelectNodes("/packageDescription/resources/image[@id='" + assetData.id + "']");
            foreach (XmlElement xn in xnList)
            {
                if(export)
                {
                    xn.SetAttribute("exported", "true");
                }
                else if(xn.HasAttribute("exported"))
                {
                    xn.RemoveAttribute("exported");
                }
            }
            assetData.exported = export;

            xmlDocument.Save(pathForFull);
        }

        public XmlNode RemoveImageXml(AssetData assetData, bool isSave = true)
        {
            XmlNode resources = xmlDocument.SelectSingleNode("/packageDescription/resources");
            XmlNode node = xmlDocument.SelectSingleNode("/packageDescription/resources/image[@id='" + assetData.id + "']");
            if (node != null)
            {
                resources.RemoveChild(node);
            }

            if(isSave)
            {
                xmlDocument.Save(pathForFull);
            }
            return node;
        }

        public void AddImageXml(XmlElement node)
        {
            XmlElement element = xmlDocument.CreateElement(node.Name);
            foreach(XmlAttribute a in node.Attributes)
            {
                element.SetAttribute(a.Name, a.Value);
            }
            element.SetAttribute("exported", "true");

            XmlNode resources = xmlDocument.SelectSingleNode("/packageDescription/resources");
            resources.AppendChild(element);

            xmlDocument.Save(pathForFull);
        }


        public void RemoveResource(AssetData res)
        {
            resources.Remove(res.id);
            resourcesList.Remove(res);


            switch (res.type)
            {
                case ResourceComponentType.component:
                    components.Remove(res);
                    if (res.exported)
                    {
                        exportComponents.Remove(res);
                    }
                    break;
                case ResourceComponentType.sound:
                    sounds.Remove(res);
                    break;
                case ResourceComponentType.image:
                    images.Remove(res);
                    break;

            }

        }


        public void AddResource(AssetData res)
        {
            res.package = this;

            resources.Enqueue(res.id, res);
            resourcesList.Add(res);

            switch (res.type)
            {
                case ResourceComponentType.component:
                    components.Add(res);
                    if (res.exported)
                    {
                        exportComponents.Add(res);
                    }
                    break;
                case ResourceComponentType.sound:
                    sounds.Add(res);
                    break;
                case ResourceComponentType.image:
                    images.Add(res);
                    break;

            }
        }

        public AssetData GetResource(string resId)
        {
            if (resources.ContainsKey(resId))
                return resources[resId];
            return null;
        }


        // 代码文件夹名称
        private string _codeFolderName;
        public string codeFolderName
        {
            get
            {
                if (string.IsNullOrEmpty(_codeFolderName))
                {
                    _codeFolderName = Regex.Replace(name, @"[^A-Za-z0-9_]", @"_");
                }
                return _codeFolderName;
            }


            set
            {
                _codeFolderName = value;
            }
        }


        // 命名空间
        private string _nameSpace;
        public string nameSpace
        {
            get
            {
                if (string.IsNullOrEmpty(_nameSpace))
                {
                    _nameSpace = codeFolderName;
                    if (!string.IsNullOrEmpty(Setting.Options.codeNamespace))
                        _nameSpace = Setting.Options.codeNamespace + "." + _nameSpace;
                }
                return _nameSpace;
            }


            set
            {
                _nameSpace = value;
            }
        }

        private string _classNameBinder;
        public string classNameBinder
        {

            get
            {
                if (string.IsNullOrEmpty(_classNameBinder))
                {
                    _classNameBinder = codeFolderName.FirstUpper() + "Binder";
                }
                return _classNameBinder;
            }
        }

    }
}