using UnityEngine;

public class Coin : MonoBehaviour
{
    // 收集时给的分数，一般是1
    public int scoreValue = 1;

    void OnTriggerEnter(Collider other)
    {
        // 只对带有Player标签的物体生效
        if (other.CompareTag("Player"))
        {
            // 调用ScoreManager的加分方法
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(scoreValue);
            }
            // 收集后销毁金币
            Destroy(gameObject);
        }
    }

    // 让金币旋转，增加视觉效果（可选）
    void Update()
    {
        transform.Rotate(Vector3.up * 100 * Time.deltaTime);
    }
}