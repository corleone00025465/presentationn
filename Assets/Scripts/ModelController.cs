using UnityEngine;

/// <summary>
/// 模型控制脚本：旋转、移动、缩放、重置功能
/// 挂载到需要控制的 3D 物体上即可
/// </summary>
public class ModelController : MonoBehaviour
{
    [Header("基础参数")]
    [Tooltip("旋转速度")] public float rotateSpeed = 50f;
    [Tooltip("移动速度")] public float moveSpeed = 2f;
    [Tooltip("缩放速度")] public float scaleSpeed = 0.1f;

    [Header("缩放限制")]
    public float minScale = 0.3f;  // 最小缩放
    public float maxScale = 3f;    // 最大缩放

    // 记录物体初始状态（用于重置）
    private Vector3 originalPos;
    private Quaternion originalRot;
    private Vector3 originalScale;

    void Start()
    {
        // 游戏开始时保存物体的初始位置、旋转、缩放
        SaveOriginalState();
    }

    /// <summary>
    /// 保存物体初始状态
    /// </summary>
    void SaveOriginalState()
    {
        originalPos = transform.position;
        originalRot = transform.rotation;
        originalScale = transform.localScale;
    }

    #region 旋转功能
    /// <summary>
    /// 向左旋转
    /// </summary>
    public void RotateLeft()
    {
        transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
    }

    /// <summary>
    /// 向右旋转
    /// </summary>
    public void RotateRight()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
    #endregion

    #region 移动功能
    /// <summary>
    /// 向左移动
    /// </summary>
    public void MoveLeft()
    {
        transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
    }

    /// <summary>
    /// 向右移动
    /// </summary>
    public void MoveRight()
    {
        transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
    }
    #endregion

    #region 缩放功能
    /// <summary>
    /// 放大模型
    /// </summary>
    public void ScaleUp()
    {
        // 限制最大缩放，防止无限放大
        if (transform.localScale.x < maxScale)
        {
            transform.localScale += Vector3.one * scaleSpeed;
        }
    }

    /// <summary>
    /// 缩小模型
    /// </summary>
    public void ScaleDown()
    {
        // 限制最小缩放，防止无限缩小
        if (transform.localScale.x > minScale)
        {
            transform.localScale -= Vector3.one * scaleSpeed;
        }
    }
    #endregion

    #region 重置功能
    /// <summary>
    /// 重置模型到初始状态
    /// </summary>
    public void ResetModel()
    {
        transform.position = originalPos;
        transform.rotation = originalRot;
        transform.localScale = originalScale;
    }
    #endregion
}