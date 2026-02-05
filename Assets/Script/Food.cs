using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;
    Score score;
    private void Start()
    {
        score = FindObjectOfType<Score>();
        RandomPos();
    }
    
        private void RandomPos()
            {
                Bounds bounds = this.gridArea.bounds;
                float x = Random.Range(bounds.min.x,bounds.max.x);
                float y = Random.Range(bounds.min.y,bounds.max.y);
                this.transform.position = new Vector3(Mathf.Round(x),Mathf.Round(y),0);
            }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            RandomPos();
            score.AddScore(1);


        }
    }
}
