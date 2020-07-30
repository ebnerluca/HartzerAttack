using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public bool isLevelStart = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (GameManager.instance.SetRespawnPoint(transform))
            {
                Debug.Log("[RespawnPoint]: Checkpoint reached!");
            }
        }
    }

}
