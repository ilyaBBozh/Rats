using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public int addValue = 0;
    public int subtractValue = 0;
    public float dieTime = 3;

    private void Start()
    {
        StartCoroutine(Die());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            collision.gameObject.GetComponent<Player>().health -= subtractValue;
            Camera.main.GetComponent<Score>().score += addValue;

            if(subtractValue == 0)
            {
                collision.gameObject.GetComponent<Player>().pickupGoodObjectSource.Play();
            } 

            else
            {
                collision.gameObject.GetComponent<Player>().hurtSource.Play();
            }

            Destroy(gameObject);
        }
    }

    IEnumerator Die() 
    {
        yield return new WaitForSeconds(dieTime);

        Destroy(gameObject);
    }
}
