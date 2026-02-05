using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeControl : MonoBehaviour
{
    public float moveTime = 0.4f; 
    private float moveTimer; 
    private Vector2Int gridPos; 
    private Vector2Int direction = Vector2Int.right;
    private Vector2Int nextDirection; 
    private Vector3 targetPosition;


    private List<Transform> _segment;
    public Transform segmentPrefeb;

    void Start()
    {
        gridPos = new Vector2Int(0, 0); 
        nextDirection = direction; 
        targetPosition = transform.position; 
        moveTimer = moveTime; 

        _segment = new List<Transform>();
        _segment.Add(this.transform);
    }

    void Update()
    {
        moveTimer -= Time.deltaTime; 

        movement();

        if (moveTimer <= 0f)
        {
            direction = nextDirection; 
            gridPos += direction; 

          
            targetPosition = new Vector3(gridPos.x * 0.5f, gridPos.y * 0.5f, 0);
            moveTimer = moveTime; 
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime / moveTime);
    }

    private void FixedUpdate()
    {
        for(int i = _segment.Count - 1; i > 0; i--)
        {
            _segment[i].position = _segment[i - 1].position;
        }
    }

    public void movement()
    {

        if (Input.GetKeyDown(KeyCode.W) && direction != Vector2Int.down)
        {
            nextDirection = Vector2Int.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && direction != Vector2Int.up)
        {
            nextDirection = Vector2Int.down;
        }
        else if (Input.GetKeyDown(KeyCode.A) && direction != Vector2Int.right)
        {
            nextDirection = Vector2Int.left;
        }
        else if (Input.GetKeyDown(KeyCode.D) && direction != Vector2Int.left)
        {
            nextDirection = Vector2Int.right;
        }
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefeb);
        segment.position = _segment[_segment.Count - 1].position;
        _segment.Add(segment);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Food")
        {
            Grow();
        }
    }
}
