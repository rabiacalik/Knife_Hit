using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KnifeManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> knifeList = new List<GameObject>();
    [SerializeField] private List<GameObject> knifeIconList = new List<GameObject>();

    [SerializeField] private Vector2 knifeIconPosition;
    
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private GameObject knifeIconPrefab;

    [SerializeField] private Color activeKnifeIconColor;
    [SerializeField] private Color disableKnifeIconColor;

    [SerializeField] private int knifeCount;
    private int knifeIndex;

    private void Start()
    {
        CreateKnifes();
        CreateKnifeIcon();
    }
    
    private void CreateKnifes()
    {
        for (int i = 0; i < knifeCount; i++)
        {
            GameObject newKnife = Instantiate(knifePrefab, transform.position, Quaternion.identity); //yeni bicaklar uretildi
            newKnife.SetActive(false);          // uretilen bicaklari kapattik
            knifeList.Add(newKnife);            // uretilen bicaklari listeye ekledik
        }

        knifeList[0].SetActive(true);
    }

    private void CreateKnifeIcon()
    {
        for (int i = 0; i < knifeCount; i++)
        {
            GameObject newKnifeIcon = Instantiate(knifeIconPrefab, knifeIconPosition, knifeIconPrefab.transform.rotation);
            newKnifeIcon.GetComponent<SpriteRenderer>().color = activeKnifeIconColor;
            knifeIconPosition.y += 0.4f;
            knifeIconList.Add(newKnifeIcon);


            // Prefab'ýn opaklýk deðerini koruyun
            Color originalColor = newKnifeIcon.GetComponent<SpriteRenderer>().color;
            originalColor.a = 1.0f; // Opaklýk deðerini 1 (tamamen opak) yapabilirsiniz.
            newKnifeIcon.GetComponent<SpriteRenderer>().color = originalColor;
        }
    }

    public void SetKinefeIconDisableColor()
    {
        GameObject newKnifeIcon = knifeIconList[(knifeIconList.Count - 1) - knifeIndex];
        newKnifeIcon.GetComponent<SpriteRenderer>().color = disableKnifeIconColor;

        // Prefab'ýn opaklýk deðerini koruyun
        Color originalColor = newKnifeIcon.GetComponent<SpriteRenderer>().color;
        originalColor.a = 1.0f; // Opaklýk deðerini 1 (tamamen opak) yapabilirsiniz.
        newKnifeIcon.GetComponent<SpriteRenderer>().color = originalColor;
    }

    public void SetActiveKnife()
    {
        if (knifeIndex < knifeCount - 1)
        {
            knifeIndex++;
            knifeList[knifeIndex].SetActive(true);
        }
    }

    /*
     * Instantiate = orjinal nesneyi klonlar ve klonu geri dondurur
     *      Object original = kopyasýný olusturmak istediginiz mevcut bir nesne
     *      Transform parent = yeni nesneye atanacak parent(ebeveyn)
     *      Quaternion rotation = yeni nesnenin yonelimi / Quaternion.identity = varsayilan kendi rotasyonu
     *
     */







}
