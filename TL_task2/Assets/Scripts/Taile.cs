using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Taile : MonoBehaviour
{
    // Start is called before the first frame update
    public int type = 0;
    //0 = not dymand 1 = dymand
    void Start()
    {
        // Debug.Log("start");
       // SetType(Random.Range(0,2));

    }

    public void SetType(int _type)
    {
        Debug.Log("settype called by main ###########");
        type = _type;

        //set top tile color to random
        this.transform.GetComponent<Image>().color = new Color(Random.Range(0f, 1f), 1, 1);

        if (type == 1)
        {
            //this.transform.parent.GetComponent<Image>().color = new Color(0, 1, 0);
            this.transform.parent.GetComponent<Image>().sprite = GameManager.instance.dimongsprite;
             

        }
        else
        {
            this.transform.parent.GetComponent<Image>().color = new Color(1, 0, 0);
        }
    }

    public void ResetType()
    {
        type = 0;
        this.transform.parent.GetComponent<Image>().color = new Color(1, 1, 1);
        this.transform.parent.GetComponent<Image>().sprite = null;
    }

    // Update is called once per frame
      

    
     

    private void OnMouseDown()
    {
         
       // Debug.Log("i click the object " + type);
        GameManager.instance.updateClickcount(type);

        this.gameObject.SetActive(false);
        

    }
}
