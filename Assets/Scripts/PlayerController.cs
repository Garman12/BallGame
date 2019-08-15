using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text countText;
    public Text winText;
    public float speed;
    private Rigidbody rb;
    private int count;
    private int winCount;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        UpdateText();
        winText.text = "";
        winCount = GameObject.FindGameObjectsWithTag("Pick Up").Length;
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up")){
            other.gameObject.SetActive(false);
            count += 1;
            UpdateText();
        }
    }
    void UpdateText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= winCount)
        {
            winText.text = "You Win!";
        }
    }
}
