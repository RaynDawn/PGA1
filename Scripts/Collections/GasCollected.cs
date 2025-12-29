using UnityEngine;
using UnityEngine.Events;

public class GasCollected : MonoBehaviour
{
    [Header("Effect")]
    public GameObject ScannerPrefab;
    [Range(0, 100)]
    public float duration = 10;
    [Range(0, 1000)]
    public float size = 500;
    [Header("Attributes")]
    public float amount = 30;
    [Header("EventRaise")]
    public ResourceEventSO ResourceEvent;
    [Header("Animation")]
    private Animator animator;
    
    private bool isCollected = false; // 防止重复收集的标志

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    /// <summary>
    /// 当其他Collider进入触发器时调用
    /// </summary>
    /// <param name="other">进入触发器的Collider</param>
    private void OnTriggerEnter(Collider other)
    {
        // 检查进入的物体是否为Player
        if (other.CompareTag("Player"))
        {
            // 广播事件
            ResourceEvent.RaiseEvent(amount);
            ResourceCollect();
        }
        else if(other.CompareTag("Scanner"))
        {
            animator.SetBool("Scan", true);
            SpawnScan();
        }
    }
    private void SpawnScan()
    {
        GameObject Scanner = Instantiate(ScannerPrefab, gameObject.transform.position, Quaternion.identity) as GameObject;
        ParticleSystem ScannerPS = Scanner.transform.GetChild(0).GetComponent<ParticleSystem>();
        if(ScannerPS != null)
        {
            var main = ScannerPS.main;
            main.startLifetime = duration;
            main.startSize = size;
        }
        Destroy(Scanner, duration+1);
    }
    public void ResourceCollect()
    {
        if (isCollected) return; // 如果已经被收集，直接返回
        isCollected = true; // 标记为已收集
        Destroy(gameObject);
    }
    public void ScanFinish()
    {
        animator.SetBool("Scan", false);
    }
}
