using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour {

    private bool selected = false;
    SelectionController selectionController;

    public bool getSelected()
    {
        return this.selected;
    }

    public void setSelected(bool selectedStatus)
    {
        this.selected = selectedStatus;
        if (selectedStatus)
        {
            gameObject.SendMessage("Selected");
        }
        else
        {
            gameObject.SendMessage("Deselected");
        }
    }

    private void Awake()
    {
        selectionController = (SelectionController) Object.FindObjectOfType<SelectionController>();
    }

    // Use this for initialization
    void Start () {
        // Register this object as selectable
        this.selectionController.registerSelectable(gameObject);
	}


}
