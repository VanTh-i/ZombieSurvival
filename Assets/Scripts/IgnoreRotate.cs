using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreRotate : MonoBehaviour
{
    private Quaternion parentRotation;
    //Start is called before the first frame update
    void Start()
    {
        parentRotation = transform.parent.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Inverse(transform.parent.localRotation) * parentRotation * transform.localRotation;
        parentRotation = transform.parent.localRotation;
    }
}
