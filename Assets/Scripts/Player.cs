using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    private Animator anim;

    void Start()
    {
        this.anim = this.GetComponent<Animator>();    
    }

    void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        var dir = new Vector3(h, v, 0).normalized;
        this.transform.Translate(dir * this.speed * Time.deltaTime);

        if(dir != Vector3.zero)
        {
            var clampX = Mathf.Clamp(this.transform.position.x, -2.2f, 2.2f);
            var clampY = Mathf.Clamp(this.transform.position.y, -4.4f, 4.4f);
            this.transform.position = new Vector3(clampX, clampY, 0);
        }

        this.anim.SetInteger("dir", (int)h);

    }
}
