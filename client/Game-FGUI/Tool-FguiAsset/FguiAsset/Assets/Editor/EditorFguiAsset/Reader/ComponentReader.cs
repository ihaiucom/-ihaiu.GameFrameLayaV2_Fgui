using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EditorFguiAssets
{
    public class ComponentReader
    {
        public static void Load(string path, AssetData resourceComponent)
        {
            Console.WriteLine("ComponentReader:" + path);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            resourceComponent.xmlDocument = xmlDocument;


            XmlNode component = xmlDocument.SelectSingleNode(@"component");

            // 继承
            string extention = fairygui.ExtendType.Component;
            if (component.Attributes["extention"] != null)
            {
                extention = component.Attributes.GetNamedItem("extention").InnerText;
            }
            resourceComponent.extention = extention;


            XmlNodeList xmlNodeList = component.ChildNodes;

            foreach (XmlNode node in xmlNodeList)
            {

                switch (node.Name)
                {
                    // 控制器
                    case fairygui.NodeName.controller:
                        resourceComponent.controllerList.Add(new Node() { name = node.Attributes.GetNamedItem("name").InnerText, type = fairygui.CommonName.Controller });
                        break;
                    // 动效
                    case fairygui.NodeName.transition:
                        resourceComponent.transitionList.Add(new Node() { name = node.Attributes.GetNamedItem("name").InnerText, type = fairygui.CommonName.Transition });
                        break;

                    case fairygui.NodeName.displayList:
                        XmlNodeList displayNodeList = node.ChildNodes;
                        foreach (XmlNode displayNode in displayNodeList)
                        {

                            Node fguiNode = null;
                            string pkg = null;
                            string src = null;
                            string nodeName = displayNode.Attributes.GetNamedItem("name").InnerText;
                            switch (displayNode.Name)
                            {
                                // 图片
                                case fairygui.NodeName.image:

                                    pkg = null;
                                    if (displayNode.Attributes["pkg"] != null)
                                    {
                                        pkg = displayNode.Attributes.GetNamedItem("pkg").InnerText;
                                    }

                                    src = null;
                                    if (displayNode.Attributes["src"] != null)
                                    {
                                        src = displayNode.Attributes.GetNamedItem("src").InnerText;
                                    }
                                    fguiNode = new Node() { name = nodeName, type = fairygui.CommonName.GImage, pkg = pkg, src = src };
                                    resourceComponent.AddNode(fguiNode);
                                    break;
                                // 文本
                                case fairygui.NodeName.text:
                                    bool input = false;
                                    if (displayNode.Attributes["input"] != null)
                                    {
                                        input = displayNode.Attributes.GetNamedItem("input").InnerText == "true";
                                    }

                                    if (input)
                                    {
                                        fguiNode = new Node() { name = nodeName, type = fairygui.CommonName.GTextInput };
                                    }
                                    else
                                    {
                                        fguiNode = new Node() { name = nodeName, type = fairygui.CommonName.GTextField };
                                    }
                                    resourceComponent.AddNode(fguiNode);
                                    break;

                                // 富文本
                                case fairygui.NodeName.richtext:
                                    fguiNode = new Node() { name = nodeName, type = fairygui.CommonName.GRichTextField };
                                    resourceComponent.AddNode(fguiNode);
                                    break;

                                // 图形
                                case fairygui.NodeName.graph:
                                    fguiNode = new Node() { name = nodeName, type = fairygui.CommonName.GGraph };
                                    resourceComponent.AddNode(fguiNode);
                                    break;

                                // 组
                                case fairygui.NodeName.group:
                                    bool advanced = false;
                                    if (displayNode.Attributes["advanced"] != null)
                                    {
                                        advanced = displayNode.Attributes.GetNamedItem("advanced").InnerText == "true";
                                    }

                                    if (advanced)
                                    {
                                        fguiNode = new Node() { name = nodeName, type = fairygui.CommonName.GGroup };
                                        resourceComponent.AddNode(fguiNode);
                                    }
                                    break;

                                // 装载器
                                case fairygui.NodeName.loader:

                                    string url = null;
                                    if (displayNode.Attributes["url"] != null)
                                    {
                                        url = displayNode.Attributes.GetNamedItem("url").InnerText;
                                    }
                                    fguiNode = new Node() { name = nodeName, type = fairygui.CommonName.GLoader, url = url };
                                    resourceComponent.AddNode(fguiNode);


                                    break;

                                // 列表
                                case fairygui.NodeName.list:
                                    string defaultItem = null;
                                    if (displayNode.Attributes["defaultItem"] != null)
                                    {
                                        defaultItem = displayNode.Attributes.GetNamedItem("defaultItem").InnerText;
                                    }
                                    fguiNode = new Node() { name = nodeName, type = fairygui.CommonName.GList, defaultItem = defaultItem };
                                    resourceComponent.AddNode(fguiNode);
                                    break;

                                // 序列帧动画
                                case fairygui.NodeName.movieclip:


                                    pkg = null;
                                    if (displayNode.Attributes["pkg"] != null)
                                    {
                                        pkg = displayNode.Attributes.GetNamedItem("pkg").InnerText;
                                    }

                                    src = null;
                                    if (displayNode.Attributes["src"] != null)
                                    {
                                        src = displayNode.Attributes.GetNamedItem("src").InnerText;
                                    }

                                    fguiNode = new Node() { name = nodeName, type = fairygui.CommonName.GMovieClip, pkg = pkg, src = src };
                                    resourceComponent.AddNode(fguiNode);
                                    break;

                                // 自定义组件
                                case fairygui.NodeName.component:
                                    pkg = null;
                                    if (displayNode.Attributes["pkg"] != null)
                                    {
                                        pkg = displayNode.Attributes.GetNamedItem("pkg").InnerText;
                                    }
                                    fguiNode = new Node()
                                    {
                                        name = nodeName,
                                        type = fairygui.CommonName.GComponent,
                                        pkg = pkg,
                                        src = displayNode.Attributes.GetNamedItem("src").InnerText
                                    };

                                    XmlElement label = (XmlElement) displayNode.SelectSingleNode("Label");
                                    if(label != null)
                                    {
                                        if (label.HasAttribute("icon"))
                                            fguiNode.labelIcon = label.GetAttribute("icon");
                                    }

                                    XmlElement button = (XmlElement)displayNode.SelectSingleNode("Button");
                                    if (button != null)
                                    {
                                        if(button.HasAttribute("icon"))
                                            fguiNode.buttonIcon = button.GetAttribute("icon");

                                        if(button.HasAttribute("selectedIcon"))
                                            fguiNode.buttonSelectIcon = button.GetAttribute("selectedIcon");
                                    }


                                    resourceComponent.AddNode(fguiNode);
                                    break;

                            }

                            if(fguiNode != null)
                            {
                                XmlElement gearIcon = (XmlElement)displayNode.SelectSingleNode("gearIcon");
                                if (gearIcon != null)
                                {
                                    if (gearIcon.HasAttribute("values"))
                                        fguiNode.gearIconUrls = gearIcon.GetAttribute("values");

                                    if (gearIcon.HasAttribute("default"))
                                        fguiNode.gearDefault = gearIcon.GetAttribute("default");
                                }
                            }

                        }
                        break;
                }
            }

        }
    }
}