using UnityEngine;
using UnityEditor;
using System.Collections;

public class RoarObjectFactory : Editor
{
	[MenuItem("GameObject/Create Other/Roar/Scene Object", false, 2000)]
	public static void CreateRoarSceneObject()
	{
		if (ExistingComponentTypeExists(typeof(DefaultRoar)))
		{
			EditorUtility.DisplayDialog("Sorry!", "A DefaultRoar component is already located in this scene.", "OK");
		}
		else
		{
			GameObject go = RoarObjectFactory.CreateGameObjectInScene("Roar");
			go.AddComponent<DefaultRoar>();
			go.transform.parent = null;
			
			GameObject ui = new GameObject("RoarUI");
			ui.transform.parent = go.transform;
			RoarModuleController uiController = ui.AddComponent<RoarModuleController>();			
			uiController.ResetToDefaultConfiguration();
			
			Selection.activeGameObject = go;
		}
	}

	public static bool ExistingComponentTypeExists(System.Type type)
	{
		Component c = FindObjectOfType(type) as Component;
		return c != null;
	}
	
	public static GameObject CreateGameObjectInScene(string name)
	{
		string realName = name;
		int counter = 0;
		while (GameObject.Find(realName) != null)
		{
			realName = name + counter++;
		}
		
        GameObject go = new GameObject(realName);
		if (Selection.activeGameObject != null)
		{
			string assetPath = AssetDatabase.GetAssetPath(Selection.activeGameObject);
			if (assetPath.Length == 0) go.transform.parent = Selection.activeGameObject.transform;
		}
        go.transform.localPosition = Vector3.zero;
        go.transform.localRotation = Quaternion.identity;
        go.transform.localScale = Vector3.one;	
        return go;
	}
	
}
