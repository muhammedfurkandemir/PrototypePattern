using UnityEditor; //https://docs.unity3d.com/ScriptReference/Editor.html
using UnityEngine;
using System.IO;

[CustomEditor(typeof(AstroidSpawner))]
public class AstroidSpawnerEditor : Editor
{
    string path;
    string assetPath;
    string fileName;

    private void OnEnable()
    {
        path = Application.dataPath + "/Astroid";
        assetPath = "Assets/Astroid/";
        fileName = "astroid_" + System.DateTime.Now.Ticks.ToString();
    }
    public override void OnInspectorGUI()
    {
        AstroidSpawner astSpawner = (AstroidSpawner)target;
        DrawDefaultInspector();
        if (GUILayout.Button("Create Astroid"))
        {
            astSpawner.CreateAstroid();
        }
        if (GUILayout.Button("Save Astroid"))
        {
            System.IO.Directory.CreateDirectory(path);
            Mesh mesh = astSpawner.astroid.GetComponent<MeshFilter>().sharedMesh;
            AssetDatabase.CreateAsset(mesh, assetPath + mesh.name + ".asset");
            AssetDatabase.SaveAssets();
            //https://docs.unity3d.com/ScriptReference/AssetDatabase.html

            PrefabUtility.SaveAsPrefabAsset(astSpawner.astroid, assetPath + fileName + ".prefab");
            //https://docs.unity3d.com/ScriptReference/PrefabUtility.html
        }
    }
}
