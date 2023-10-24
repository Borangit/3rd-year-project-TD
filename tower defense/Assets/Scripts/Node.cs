
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public GameObject turret;

    

    private Color startColor;
    private Renderer rend;

    void Start(){
        rend = GetComponent<Renderer>();
        startColor = rend.materials[1].color;
    }


    void OnMouseDown(){
        if(turret != null){
            Debug.Log("Can't build there! - TODO: Display on screen");
            return;
        }
        //Build a turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        //spawn turret with y + 0.2
        turret = (GameObject)Instantiate(turretToBuild, transform.position + new Vector3(0,0.2f,0), transform.rotation);
    }
    void OnMouseEnter(){

        rend.materials[1].color = hoverColor;
        
    }

    void OnMouseExit(){
        rend.materials[1].color = startColor;
    }
}
