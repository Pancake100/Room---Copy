using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeDiseaseController : MonoBehaviour
{
    public GameObject amdFilter;
    public GameObject amdSolution;
    public GameObject glaucomaFilter;
    public GameObject glaucomaSolution;
    void Start()
    {
        amdSolution = amdFilter.transform.Find("Canvas")?.gameObject;
        glaucomaSolution = glaucomaFilter.transform.Find("OutsideView")?.gameObject;

        if (amdSolution == null || glaucomaSolution == null)
        {
            Debug.LogWarning("One or more solution Gameobject could not be found under the disease filter.");
        }
    }
    public void ToggleAMD()
    {
        bool newState = !amdFilter.activeSelf;
        amdFilter.SetActive(newState);
    }
    public void ToggleAMDSolution()
    {
        if (amdSolution != null)
        {
            amdSolution.SetActive(!amdSolution.activeSelf);
        }
    }
    public void ToggleGlaucoma()
    {
        bool newState = !glaucomaFilter.activeSelf;
        glaucomaFilter.SetActive(newState);
    }
    public void ToggleGlaucomaSolution()
    {
        if (glaucomaSolution != null)
        {
            glaucomaSolution.SetActive(!glaucomaSolution.activeSelf);
        }
    }
}
