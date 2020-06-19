using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthbarBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject boss;

    Vector2 position;
    Vector2 backgroundPosition;
    Vector2 backgroundSize = new Vector2(1020, 100);

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        backgroundPosition = new Vector2(position.x - 10, position.y - 10);
    }

    // Update is called once per frame
    void Update()
    {
        //No healthbar if the boss is dead
        if (boss.GetComponent<JesterBossBehavior>().GetHealth() <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnGUI()
    {
        Rect background = new Rect(backgroundPosition, backgroundSize);
        DrawQuad(background, Color.black);

        Vector2 remainingHP = new Vector2(boss.GetComponent<JesterBossBehavior>().GetHealth() * 10, 80);
        Rect r = new Rect(position, remainingHP);
        DrawQuad(r, Color.red);
    }

    void DrawQuad(Rect position, Color color)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, color);
        texture.Apply();
        GUI.skin.box.normal.background = texture;
        GUI.Box(position, GUIContent.none);
    }

}
