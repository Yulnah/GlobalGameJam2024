using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE : MonoBehaviour
{

    public float QTEspeed;
    public string QTE_letter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * QTEspeed);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeadZone")
        {
            //Debug.Log("OnCollisionEnter2D with DeadZone");
            Destroy(gameObject);
        }
    }

}
