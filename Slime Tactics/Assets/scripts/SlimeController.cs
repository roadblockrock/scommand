using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour {

    bool isSelected;
    bool mouseOver = false;
    SpriteRenderer mySpriteRenderer;

	// Use this for initialization
	void Start () {
		isSelected = false;
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        // Lock to grid
        Vector3 myPos = transform.position;
        transform.position = new Vector3(Mathf.Round(myPos.x) , Mathf.Round(myPos.y) , myPos.z);
    }
	
	// Update is called once per frame
	void Update () {

        // Check if object has been deselected
        if (Input.GetMouseButton(0))
            if (!mouseOver)
            {
                this.isSelected = false;
            }

        // If Object is selected...
        if (this.isSelected)
        {
            // Set Selected Color
            mySpriteRenderer.color = Color.red;

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
        else
        {
            // Not selected so make color normal
            mySpriteRenderer.color = Color.white;
        }

        
           

            


        

    }

    // Object was clicked
    void OnMouseDown()
    {
        print("Clicked!");
        this.isSelected = true;
    }

    private void OnMouseOver()
    {
        this.mouseOver = true;
    }

    private void OnMouseExit()
    {
        this.mouseOver = false;
    }


}
