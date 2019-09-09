using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughtMoneyColor;
    public Vector3 offsetPosition;

    [Header("Optionnal")]
    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if(!buildManager.CanBuild)
        {
            return;
        }

        if(turret != null)
        {
            Debug.Log("Can't build there !");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + offsetPosition;
    }

    void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
        {
            return;
        }

        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughtMoneyColor;
        }
        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
