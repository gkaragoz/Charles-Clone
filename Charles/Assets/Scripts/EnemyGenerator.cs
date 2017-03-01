using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    private const float PLAY_AREA_MIN_X = -2.5f;
    private const float PLAY_AREA_MAX_X = 2.5f;
    private const float PLAY_AREA_MIN_Y = -4f;
    private const float PLAY_AREA_MAX_Y = 4f;

    #region Color Hex List
    /* RED          #F34235
     * PINK         #E81D62
     * DARK GRAY    #51585D
     * PURPLE       #9B26AF
     * DEEP PURPLE  #6639B6
     * INDIGO       #3E50B4
     * BLUE         #2095F2
     * LIGHT BLUE   #02A8F3
     * CYAN         #00BBD3
     * TEAL         #009587
     * GREEN        #4BAE4F
     * LIGHT GREEN  #8AC249
     * LIME         #CCDB38
     * YELLOW       #FEEA3A
     * AMBER        #FEC006
     * ORANGE       #FE9700
     * DEEP ORANGE  #FE5621
     * BROWN        #785447
     * GREY         #9D9D9D
     * BLUE GREY    #5F7C8A
     * */
    #endregion

    [SerializeField] private List<Color> COLORS = new List<Color>();
    [SerializeField] private GameObject dotPrefab;

    void Start()
    {
        InvokeRepeating("Spawn", 1f, 0.2f);
    }

    void Spawn()
    {
        GameObject dot = Instantiate(dotPrefab, GetRandomPosition(), Quaternion.identity);
        dot.GetComponent<SpriteRenderer>().color = GetRandomColor();
    }

    Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(PLAY_AREA_MIN_X, PLAY_AREA_MAX_X);
        float randomY = Random.Range(PLAY_AREA_MIN_Y, PLAY_AREA_MAX_Y);

        return new Vector3(randomX, randomY, 0);
    }

    Color GetRandomColor()
    {
        return COLORS[Random.Range(0, COLORS.Count)];
    }
}
