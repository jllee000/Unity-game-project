using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arrowPrefab;
    public float span = 1.0f;
    float delta = 0;

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            delta = 0;
            GameObject go = Instantiate(arrowPrefab);
            int px = Random.Range(-6, 7);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
