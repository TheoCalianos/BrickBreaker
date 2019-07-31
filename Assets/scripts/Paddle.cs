using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float xMinClamp = 1f;
    [SerializeField] float xMaxClamp = 15f;
    [SerializeField] float screenWidthUnits = 16f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float paddleTracker = Input.mousePosition.x / Screen.width * screenWidthUnits;
        Vector2 paddlePos = new Vector2(paddleTracker, transform.position.y);
        paddlePos.x = Mathf.Clamp(paddleTracker, xMinClamp, xMaxClamp);
        transform.position = paddlePos;
    }
}
