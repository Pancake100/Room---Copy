using UnityEngine;
using UnityEngine.UI;
public class ObjectController : MonoBehaviour
{
    [System.Serializable]
    public class ObjectData
    {
        public string name;
        public GameObject objectImageInScene;
        public GameObject[] objectInstances;
    }
    public ObjectData[] allObjects;

    private GameObject activeInstance = null;
    private GameObject activeImage = null;

    public void OnButtonPressed()
    {
        if(activeInstance != null)
        {
            activeInstance.SetActive(false);
            activeInstance = null;
        }
        if(activeImage != null)
        {
            activeImage.SetActive(false);
            activeImage = null;
        }

        int objTypeIndex = Random.Range(0, allObjects.Length);
        ObjectData selectedObject = allObjects[objTypeIndex];

        if(selectedObject.objectImageInScene != null )
        {
            selectedObject.objectImageInScene.SetActive(true);
            activeImage = selectedObject.objectImageInScene;
        }

        if(selectedObject.objectInstances.Length > 0)
        {
            int instanceIndex = Random.Range(0, selectedObject.objectInstances.Length);
            activeInstance = selectedObject.objectInstances[instanceIndex];
            if (activeInstance != null)
            {
                activeInstance.SetActive(true);
                Debug.Log($"[Spawner] Activated object: {selectedObject.name}");
            }
        }
    }
}
