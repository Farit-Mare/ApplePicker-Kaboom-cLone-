using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Basket : MonoBehaviour
{
    public Text scoreGT;
    void Start()
    {
        //Take the url on gameObj Scorecoubeter
        GameObject scoreGO = GameObject.Find("Score Counter");
        //Use component Text this obj
        scoreGT = scoreGO.GetComponent<Text>();
        //set start value "0"
        scoreGT.text = "0";

    }
    void Update()
    {
        //put mouse's pos in "mousePos2d"
        Vector3 mousePos2d = Input.mousePosition;
        //put Camera's Z pos value in mousePos2d Z pos with "-" 
        mousePos2d.z = -Camera.main.transform.position.z;
        //STWP take mousePos2d's value and put BASKET in this value distance from camera  
        Vector3 mousePos3d = Camera.main.ScreenToWorldPoint(mousePos2d);
        //move BASKET on X axis with mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3d.x;
        this.transform.position = pos;
    }
    //Destroy Apples when they touch Basket 
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collideWith = collision.gameObject;
        if (collideWith.tag == "Apple")
        {
            Destroy(collideWith);

            //custom textnumber in scoreGT to integer
            int score = int.Parse(scoreGT.text);
            //Give 100 point for 1 catcher apple
            score += 100;
            //custom integer to textnimber
            scoreGT.text = score.ToString();

            if (score > HighScore.score)
                HighScore.score = score;
        }
    }
}
