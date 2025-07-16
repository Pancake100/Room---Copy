using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleSignController : MonoBehaviour
{
    public GameObject ruleSign;
    public void ToggleRuleSign()
    {
        ruleSign.SetActive(!ruleSign.activeSelf);
    }
}
