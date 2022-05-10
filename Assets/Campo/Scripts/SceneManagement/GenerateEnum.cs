#if UNITY_EDITOR
using UnityEditor;
using System.IO;

public class GenerateEnum
{
    public static void Go(string _enumName, string[] _enumEntries)
    {
        string enumName = _enumName;
        string[] enumEntries = _enumEntries;
        string filePathAndName = "Assets/Campo/Scripts/Enums/" + enumName + ".cs";

        using (StreamWriter streamWriter = new StreamWriter(filePathAndName))
        {
            streamWriter.WriteLine("public enum " + enumName);
            streamWriter.WriteLine("{");
            for (int i = 0; i < enumEntries.Length; i++)
            {
                streamWriter.WriteLine("\t" + enumEntries[i] + ",");
            }
            streamWriter.WriteLine("}");
        }
        AssetDatabase.Refresh();
    }
}
#endif