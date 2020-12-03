using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public float distance = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = distance;

        this.transform.position = Camera.main.ScreenToWorldPoint(mousePos);

        this.transform.localEulerAngles = new Vector3(Remap(Screen.height - mousePos.y, 0, Screen.height, -30,30),Remap(mousePos.x, 0, Screen.width, -30, 30), 0); 


        
    }

    float Remap(float from, float fromMin, float fromMax, float toMin, float toMax)
    {
        var fromAbs = from - fromMin;
        var fromMaxAbs = fromMax - fromMin;

        var normal = fromAbs / fromMaxAbs;

        var toMaxAbs = toMax - toMin;
        var toAbs = toMaxAbs * normal;

        var to = toAbs + toMin;

        return to;
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

}
