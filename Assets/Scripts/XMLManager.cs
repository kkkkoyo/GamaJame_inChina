using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml;

public class XMLManager : MonoBehaviour
{

    void Awake()
    {
        //if the floder is not exist
        //create the floder and Xml List
        if (!File.Exists(Application.persistentDataPath + "//Test.xml"))
        {
            CreatXml();
            for (int i = 0; i < 5; i++)
            {
                CreateLevel((i + 1).ToString(), "0", "False");
            }
            XMLManager.UpdateIsPass(1, true);
            XMLManager.UpdateIsPass(2, true);
            XMLManager.UpdateBestScore(1, 20);
            XMLManager.UpdateBestScore(2, 430);
        }

    }

    //if don't have XmlList before,then create a new one.
    private static void CreatXml()
    {
        //Save path of Xml List
        if (!File.Exists(Application.persistentDataPath + "//Test.xml"))
        {
            //create root node
            XmlDocument xmlDoc = new XmlDocument();            
            XmlElement root = xmlDoc.CreateElement("List");
            xmlDoc.AppendChild(root);            
            xmlDoc.Save(Application.persistentDataPath + "//Test.xml");
        }
    }

    //create a whole Information of a chapter
    public static void CreateLevel(string LevelName, string BestScore, string IsPass)
    {
        if (File.Exists(Application.persistentDataPath + "//Test.xml"))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Application.persistentDataPath + "//Test.xml");
            XmlNode saveList = xmlDoc.SelectSingleNode("List");
            XmlElement levelInf = xmlDoc.CreateElement("LevelInformation");
            XmlElement levelName = xmlDoc.CreateElement("LevelName");
            levelName.InnerText = LevelName;
            XmlElement bestScore = xmlDoc.CreateElement("BestScore");
            bestScore.InnerText = BestScore;
            XmlElement isPass = xmlDoc.CreateElement("IsPass");
            isPass.InnerText = IsPass;

            levelInf.AppendChild(levelName);
            levelInf.AppendChild(bestScore);
            levelInf.AppendChild(isPass);
            saveList.AppendChild(levelInf);
            xmlDoc.Save(Application.persistentDataPath + "//Test.xml");
        }
    }

    //get the chapter's best score by it's number
    public static int getBestScore(int Levelnum)
    {
        int a = 0;
        if (File.Exists(Application.persistentDataPath + "//Test.xml"))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Application.persistentDataPath + "//Test.xml");
            XmlNode saveList = xmlDoc.SelectSingleNode("List");
            XmlNodeList checkList = saveList.ChildNodes;
            if (checkList.Count != 0)
            {
                bool isBreak = true;
                while (isBreak)
                {
                    bool isRemove = false;
                    foreach (XmlNode level in checkList)
                    {
                        XmlNode name = level.SelectSingleNode("LevelName");
                        if (name.InnerText.Equals(Levelnum.ToString()))
                        {
                            XmlNode score = level.SelectSingleNode("BestScore");
                            a = int.Parse(score.InnerText);
                            isRemove = true;
                            isBreak = false;
                            break;
                        }
                    }
                    if (!isRemove)
                        isBreak = false;
                }
                xmlDoc.Save(Application.persistentDataPath + "//Test.xml");
            }
        }
        return a;
    }

    //get the chapter's is Pass or not.
    public static bool getIsPass(int Levelnum)
    {
        bool a = true;
        if (File.Exists(Application.persistentDataPath + "//Test.xml"))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Application.persistentDataPath + "//Test.xml");
            XmlNode saveList = xmlDoc.SelectSingleNode("List");
            XmlNodeList checkList = saveList.ChildNodes;
            if (checkList.Count != 0)
            {
                bool isBreak = true;
                while (isBreak)
                {
                    bool isRemove = false;
                    foreach (XmlNode level in checkList)
                    {
                        XmlNode name = level.SelectSingleNode("LevelName");
                        if (name.InnerText.Equals(Levelnum.ToString()))
                        {
                            XmlNode isPas = level.SelectSingleNode("IsPass");
                            a = (isPas.InnerText.Equals("True"))?true:false;
                            isRemove = true;
                            isBreak = false;
                            break;
                        }
                    }
                    if (!isRemove)
                        isBreak = false;
                }
                xmlDoc.Save(Application.persistentDataPath + "//Test.xml");
            }
        }
        return a;
    }

    //Update the Levelnum's isPass.
    public static void UpdateIsPass(int Levelnum,bool IsPass)
    {
        if (File.Exists(Application.persistentDataPath + "//Test.xml"))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Application.persistentDataPath + "//Test.xml");
            XmlNodeList checkList = xmlDoc.SelectSingleNode("List").ChildNodes;
            foreach (XmlElement level in checkList)
            {
                XmlNode name = level.SelectSingleNode("LevelName");
                if (name.InnerText.Equals(Levelnum.ToString()))
                {
                    XmlNode changePass = name.ParentNode.SelectSingleNode("IsPass");
                    changePass.InnerText = IsPass.ToString();
                }
            }
            xmlDoc.Save(Application.persistentDataPath + "//Test.xml");
        }
    }

    //Update the Levelnum's BestScore.
    public static void UpdateBestScore(int Levelnum, int BestScore)
    {
        if (File.Exists(Application.persistentDataPath + "//Test.xml"))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Application.persistentDataPath + "//Test.xml");
            XmlNodeList checkList = xmlDoc.SelectSingleNode("List").ChildNodes;
            foreach (XmlElement level in checkList)
            {
                XmlNode name = level.SelectSingleNode("LevelName");
                if (name.InnerText.Equals((Levelnum).ToString()))
                {
                    XmlNode changeScore = name.ParentNode.SelectSingleNode("BestScore");
                    changeScore.InnerText = BestScore.ToString();
                }
            }
            xmlDoc.Save(Application.persistentDataPath + "//Test.xml");
        }
    }

    //compara the score with the best one that save in xmlList.
    public static void CompareScore(int Levelnum, int Score)
    {
        if (Score > getBestScore(Levelnum))
        {
            UpdateBestScore(Levelnum, Score);
        }
    }

}
