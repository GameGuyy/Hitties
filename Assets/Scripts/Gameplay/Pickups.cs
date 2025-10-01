using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        var target = collision.gameObject;
        if (target.tag == "Player")
        {
            
            CoinManager.instance.AddCoin(1000);
            Destroy(this.gameObject);
        }
        var character = target.gameObject.GetComponent<Characters>();
        if (character)
        {
            if (character.level < 2)
            {
                
                CoinManager.instance.AddCoin(1000);
                Destroy(this.gameObject);

            }
            else
            {
                //Black Animation
            }

        }

        GameCanvasManager.instance.starCount++;


    }
}
