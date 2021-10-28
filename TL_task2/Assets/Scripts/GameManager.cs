using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance;
    public int dimandcount = 5;
    public Sprite dimongsprite;
    public int Clickcounts = 5;
    public int[] randomlist = new int[25];
    [SerializeField] GameObject levelpanle;

    int wincount = 0;

    //UI
    [SerializeField] Text clickcounttext;
    [SerializeField] GameObject menupanale;

 
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

        menupanale.SetActive(true);


        clickcounttext.text = "Click:" + Clickcounts.ToString();

        
    }   


    public void Setdimondcount(int _dimondcount )
    {
        print("button click");
        dimandcount = _dimondcount;

        if(dimandcount == 10)
        {
            //easy llevel
            Clickcounts = 5;

        }
        else if(dimandcount == 5)
        {
            //medium llevel
            Clickcounts = 3;
        }
        else if(dimandcount == 1)
        {
            //hard llevel
            Clickcounts = 1;
        }

        clickcounttext.text = "Click:" + Clickcounts.ToString();


        menupanale.SetActive(false);
        for (int i = 0; i < randomlist.Length; i++)
        {
            randomlist[i] = 0;
        }

        List<int> X = new List<int>();

        for (int i = 0; i < dimandcount; i++)
        {
            int rindex = Random.Range(0, randomlist.Length);

            while (true)
            {
                if (!X.Contains(rindex))
                {
                    break;
                }
                rindex = Random.Range(0, randomlist.Length);
            }

            X.Add(rindex);
            randomlist[rindex] = 1;

        }


        Invoke("SetLeve", 0.5f);

    }




    public void SetLeve()
    {
        
        for (int i = 0; i < 25; i++)
        {
            //Debug.Log("runing$$$$$$");
            levelpanle.transform.GetChild(i).transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            levelpanle.transform.GetChild(i).transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Taile>().ResetType();

            levelpanle.transform.GetChild(i).transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Taile>().SetType(randomlist[i]);

        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

     

    public void updateClickcount(int _wincount)
    {

        wincount += _wincount;

        if (Clickcounts == 1)
        {
            //gameover
           GameOver();
           
            Debug.Log("Game over");
        }
        else
        {

        Clickcounts--;
        clickcounttext.text = "Click:"+Clickcounts.ToString();
        }
    }

    public void GameOver()
    {
        Clickcounts = 5;

        if(wincount != 0)
        {
            
            menupanale.GetComponent<Image>().color = new Color(0, 1, 0);
            menupanale.SetActive(true);
            menupanale.transform.GetChild(0).GetComponent<Text>().text = "You win play again \n diamond : " + wincount.ToString();
            wincount = 0;
        }
        else
        {
            menupanale.GetComponent<Image>().color = new Color(1, 0, 0);
            menupanale.SetActive(true);
            menupanale.transform.GetChild(0).GetComponent<Text>().text = "You lose play again";
        }
        
    }


}
