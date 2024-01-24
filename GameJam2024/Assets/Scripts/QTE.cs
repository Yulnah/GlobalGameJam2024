using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class QTE : MonoBehaviour
{

    public float QTEspeed;
    public string QTE_letter;

    public GameManager gameManager; // Get health points
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * QTEspeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DetectZone1") // tag note
        {
            GameManager.sliderBarJ1 -= 1;

            if (GameManager.sliderBarJ1 == 0)
            {
                GameManager.healthJ1 -= 1;
                GameManager.sliderBarJ1 = 3;
                //Debug.Log("Detected Zone 1 true !");
            }
            
            
        }

        if (collision.gameObject.tag == "DetectZone2") // tag note
        {
            GameManager.sliderBarJ2 -= 1;

            if (GameManager.sliderBarJ2 == 0)
            {
                GameManager.healthJ2 -= 1;
                GameManager.sliderBarJ2 = 3;
                //Debug.Log("Detected Zone 2 true !");
            }
        }


        if (collision.gameObject.tag == "DeadZone")
        {
            //Debug.Log("OnCollisionEnter2D with DeadZone");
            Destroy(gameObject);
        }
    }


}
