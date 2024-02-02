using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float mouseSpeed;
    float xrot, yrot;
    public float minX, maxX;
    public float smoothSpeed = 0.3f; // Ýstenilen deðeri ayarlayabilirsiniz


    // Start is called before the first frame update
 
    void LateUpdate()
    {
        xrot -= Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSpeed;
        yrot += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSpeed;
        xrot = Mathf.Clamp(xrot, minX, maxX);
        transform.GetChild(0).localRotation = Quaternion.Euler(xrot, 0, 0);
        transform.localRotation = Quaternion.Euler(0, yrot, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {

            // Lerp fonksiyonunu kullanarak kamera pozisyonunu yumuþak bir þekilde hedefin pozisyonuna geçir
            transform.position = Vector3.Lerp(transform.position, target.position, smoothSpeed);
        }
    }
}