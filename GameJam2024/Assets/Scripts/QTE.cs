using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class QTE : MonoBehaviour
{

    public float BaseQTEspeed;
    public string QTE_letter;

    public GameManager gameManager; // Get health points

    // SCALE
    private Vector3 targetScale = new Vector3(2f, 2f, 2f);
    private float scaleSpeed = 0.5f; // Adjust this value to control the scaling speed



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * ( BaseQTEspeed ));
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

        if (collision.gameObject.tag == "DetectScale")
        {
            // Gradually scale up the object
            StartCoroutine(ScaleOverTime(targetScale, scaleSpeed));
        }
        IEnumerator ScaleOverTime(Vector3 targetScale, float speed)
    {
        Vector3 originalScale = transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime);
            elapsedTime += Time.deltaTime * speed;
            yield return null;
        }

        // Ensure the final scale is exactly the target scale
        transform.localScale = targetScale;
    }

        if (collision.gameObject.tag == "DeadZone")
        {
            //Debug.Log("OnCollisionEnter2D with DeadZone");
            Destroy(gameObject);
        }
    }


}
