using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour {

    private List<Selectable> selectableObjects;
    private Selectable selectedObject;


    public void registerSelectable(GameObject toRegister)
    {
        this.selectableObjects.Add((Selectable)toRegister.GetComponent(typeof(Selectable)));
    }

    public void removeSelectable(GameObject toRemove)
    {
        this.selectableObjects.Remove((Selectable)toRemove.GetComponent(typeof(Selectable)));
    }

    public void setSelected(GameObject toSetSelected)
    {
        Selectable toSetSelectedComponent = (Selectable)toSetSelected.GetComponent(typeof(Selectable));
        if (!(toSetSelectedComponent == selectedObject))
        {
            foreach(Selectable s in selectableObjects)
            {
                s.setSelected(false);
            }
            toSetSelectedComponent.setSelected(true);
        }
    }

    public GameObject getSelected()
    {
        return this.selectedObject.gameObject;
    }

	// Use this for initialization
	void Awake () {
        selectableObjects = new List<Selectable>();		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
