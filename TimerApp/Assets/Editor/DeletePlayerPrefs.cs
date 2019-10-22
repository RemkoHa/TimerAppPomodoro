using UnityEngine;
using UnityEditor;

public class DisplayDlgComplexExample : EditorWindow
{
    // Lets you save, save and quit or quit without saving


    [MenuItem("Tools/Clear all Player Preferences")]
    static void DoDeselect()
    {
        if (EditorUtility.DisplayDialog("Delete all Player preferences?", "Are you sure you want to delete all the editor preferences?,this action cannot be undone.", "Yes", "No"))
            PlayerPrefs.DeleteAll();
    }
}
