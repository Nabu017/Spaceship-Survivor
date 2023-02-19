using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 viewpos = transform.position;
        viewpos.x = Mathf.Clamp(viewpos.x, screenBounds.x, screenBounds.x * -1);
        viewpos.y = Mathf.Clamp(viewpos.y, screenBounds.y, screenBounds.y * -1);
        transform.position = viewpos;
    }
}
