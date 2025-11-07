using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] Renderer renderer;
    [SerializeField] float speed = 1.0f;
    void Start()
    {
        
    }

    
    void Update()
    {
        renderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
