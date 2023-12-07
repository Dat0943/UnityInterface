using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public enum TargetEnum
{
    TopRight,
    TopLeft,
    BottomRight,
    BottomLeft
}

public class PLayerController : MonoBehaviour
{
    public float mySpeed;
    public Transform topLeftTransform;
    public Transform topRightTransform;
    public Transform bottomLeftTransform;
    public Transform bottomRightTransform;

    TargetEnum nextTarget = TargetEnum.TopLeft;
    Transform curTarget; // Giá trị đầu tiên
     
    // Start is called before the first frame update
    void Start()
    {
        curTarget = topLeftTransform; // Bắt đầu vị trị xe dừng 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = curTarget.position;
        Vector3 moveDirection = targetPosition - transform.position;

        float distance = moveDirection.magnitude; // Tính khoảng cách giữa 2 điểm

        if(distance > 0.1f) // Quy về lớn hơn 0.1f là chưa đến
        {
            // Khi chưa tới điểm tiếp theo thì vẫn tiếp tục di chuyển
            transform.position = Vector3.MoveTowards(transform.position, curTarget.position, mySpeed * Time.deltaTime);

        }
        else
        {
            // Nếu đã đến điểm curTarget
            // => Chuyển mục tiêu
            SetNextTarget(nextTarget);
        }

        // THay đổi góc quay theo hướng target
        Vector3 direction = curTarget.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = targetRotation;
    }

    private void SetNextTarget(TargetEnum target)
    {
        switch(target)
        {
            case TargetEnum.TopLeft:
                curTarget = topLeftTransform;
                nextTarget = TargetEnum.TopRight;
                break;

            case TargetEnum.TopRight:
                curTarget = topRightTransform;
                nextTarget = TargetEnum.BottomRight;
                break;

            case TargetEnum.BottomLeft:
                curTarget = bottomLeftTransform;
                nextTarget = TargetEnum.TopLeft;
                break;

            case TargetEnum.BottomRight:
                curTarget = bottomRightTransform;
                nextTarget = TargetEnum.BottomLeft;
                break;
        }
    }
}
