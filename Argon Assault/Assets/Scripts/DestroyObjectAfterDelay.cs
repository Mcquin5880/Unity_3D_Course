using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectAfterDelay : MonoBehaviour
{
    [SerializeField] float timeUntilDestroyObject = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeUntilDestroyObject);
    }

}
