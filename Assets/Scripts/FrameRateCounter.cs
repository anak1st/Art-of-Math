using UnityEngine;
using TMPro;

public class FrameRateCounter : MonoBehaviour {
    [SerializeField] TextMeshProUGUI display;

    private const int Count = 60;
    private int tick;
    private float duration;
    private float FPS;

    void Awake() {
        tick = 0;
        duration = 0f;
        FPS = 0f;
    }
    
    // Start is called before the first frame update
    void Start() {
        Update();
    }

    // Update is called once per frame
    void Update() {
        float timeTick = Time.unscaledDeltaTime;
        duration += timeTick;
        tick++;
        
        if (tick == Count) {
            FPS = Count / duration;
            tick = 0;
            duration = 0f;
        }

        display.SetText("FPS\n{0:0}\n000\n000", FPS);
    }
}