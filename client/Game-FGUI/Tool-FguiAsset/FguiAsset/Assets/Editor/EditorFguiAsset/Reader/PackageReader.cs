using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
namespace EditorFguiAssets
{
    public class PackageReader
    {
        public static Package Load(string path)
        {
            Console.WriteLine("PackageReader:" + path);

            Package package = new Package();
            package.rootPath = Path.GetDirectoryName(path);
            package.folderName = Path.GetFileName(package.rootPath);
            package.pathForFull = path;


            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            package.xmlDocument = xmlDocument;

            XmlNode packageDescription = xmlDocument.SelectSingleNode(@"packageDescription");
            XmlNode publish = xmlDocument.SelectSingleNode(@"packageDescription/publish");


            package.genCode = false;
            package.id = packageDescription.Attributes.GetNamedItem("id").InnerText;
            if (publish != null)
            {
                package.name = publish.Attributes.GetNamedItem("name").InnerText;

                if (publish.Attributes["genCode"] != null)
                    package.genCode = publish.Attributes.GetNamedItem("genCode").InnerText == "true";
            }
            else
            {
                package.name = Path.GetFileNameWithoutExtension(Path.GetDirectoryName(path));
            }


            XmlNodeList xmlNodeList = xmlDocument.SelectSingleNode("packageDescription/resources").ChildNodes;

            foreach (XmlNode node in xmlNodeList)
            {
                bool exported = false;
                if (node.Attributes["exported"] != null)
                {
                    exported = node.Attributes.GetNamedItem("exported").InnerText == "true";
                }

                AssetData item = new AssetData()
                {
                    id = node.Attributes.GetNamedItem("id").InnerText,
                    name = node.Attributes.GetNamedItem("name").InnerText,
                    path = node.Attributes.GetNamedItem("path").InnerText,
                    exported = exported,
                    type = node.Name.GetResourceComponentTypeByName()
                };

                item.pathForPackage = item.path + item.name;
                item.fileNameForPackage = item.pathForPackage.Substring(1, item.pathForPackage.Length - 1);
                item.pathForAssets = "assets/" + package.folderName + item.path + item.name;
                item.pathForAssetsData = package.folderName + item.path + item.name;
                item.pathForFull = package.rootPath + item.path + item.name;


                if (File.Exists(item.pathForFull))
                {
                    package.AddResource(item);
                }

            }

            return package;
        }
    }
}