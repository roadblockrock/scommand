using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour {

    bool mouseOver = false;
    Selectable mySelectable;
    SelectionController selectionController;
    SpriteRenderer mySpriteRenderer;

    private void Awake()
    {
        mySelectable = gameObject.GetComponent<Selectable>();
        selectionController = (SelectionController)Object.FindObjectOfType<SelectionController>();
    }

    // Use this for initialization
    void Start () {
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        // Lock to grid
        Vector3 myPos = transform.position;
        transform.position = new Vector3(Mathf.Round(myPos.x) + 0.5f , Mathf.Round(myPos.y) + 0.5f , myPos.z);
    }
	
	// Update is called once per frame
	void Update () {

        // If Object is selected...
        if (this.mySelectable.getSelected())
        {
            

            // Move the slime
            float xMove = 0;
            float yMove = 0;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                yMove = 1;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                yMove = -1;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                xMove = -1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                xMove = 1;
            }
            transform.position += new Vector3(xMove, yMove, 0.0f);
        }
       

        
           

            


        

    }

    // Object was clicked
    void OnMouseDown()
    {
        print("Clicked!");
        selectionController.setSelected(gameObject);
    }


    private void Selected()
    {
        // Set Selected Color
        mySpriteRenderer.color = Color.red;
    }

    private void Deselected()
    {
        // Not selected so make color normal
        mySpriteRenderer.color = Color.white;
    }


}
