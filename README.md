# tutorial-survival-shooter
<img src="res/intro.png" width="100%">
Unity官方範例 https://learn.unity.com/project/survival-shooter-tutorial

# 場景建置
![](res/1.png)
![](res/2.png)
![](res/3.png)
![](res/4.png)
![](res/5.png)
![](res/6.png)
![](res/7.png)
![](res/8.png)
![](res/9.png)
![](res/10.png)
![](res/11.png)
![](res/12.png)
![](res/13.png)
# 角色控制
![](res/14.png)
![](res/15.png)
![](res/16.png)
![](res/17.png)
![](res/18.png)
![](res/19.png)
![](res/20.png)
![](res/21.png)
![](res/22.png)
![](res/23.png)
![](res/24.png)
![](res/25.png)
![](res/26.png)
![](res/27.png)
![](res/28.png)
![](res/29.png)
![](res/30.png)
![](res/31.png)
# PlayerMovement.cs
```csharp
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    private Vector3 movement;
    private Animator anim;
    private Rigidbody playerRigidbody;
    private int floorMask;
    private float camRayLength = 100f;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Turning();
        Animating(h, v);
    }

    private void Move(float h, float v)
    {
        movement = new Vector3(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    private void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if(Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    private void Animating(float h, float v)
    {
        bool walking = h != 0 || v != 0;
        anim.SetBool("IsWalking", walking);
    }
}

```
# 攝影機建置
![](res/32.png)
![](res/33.png)
# CameraFollow.cs
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}

```
![](res/34.png)
# 敵人建置
![](res/35.png)
![](res/36.png)
![](res/37.png)
![](res/38.png)
![](res/39.png)
![](res/40.png)
![](res/41.png)
![](res/42.png)
![](res/43.png)
![](res/44.png)
![](res/45.png)
![](res/46.png)
![](res/47.png)
![](res/48.png)
![](res/49.png)
![](res/50.png)
![](res/51.png)
# 創建生命UI
![](res/52.png)
![](res/53.png)
![](res/54.png)
![](res/55.png)
![](res/56.png)
![](res/57.png)
![](res/58.png)
![](res/59.png)
![](res/60.png)
![](res/61.png)
![](res/62.png)
![](res/63.png)
![](res/64.png)
# 未完待續
