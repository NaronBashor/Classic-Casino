using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSymbolSelection : MonoBehaviour
{
        private float totalWeight;
        public List<GameObject> symbols = new List<GameObject>();
        public List<string> symbolTotal = new List<string>();

        // Inspector variables to check symbol percentage
        //[SerializeField] private float cherryCount = 0;
        //[SerializeField] private float watermelonCount = 0;
        //[SerializeField] private float grapeCount = 0;
        //[SerializeField] private float bananaCount = 0;
        //[SerializeField] private float bellCount = 0;
        //[SerializeField] private float strawberryCount = 0;
        //[SerializeField] private float plumCount = 0;
        //[SerializeField] private float orangeCount = 0;
        //[SerializeField] private float lemonCount = 0;
        //[SerializeField] private float barCount = 0;
        //[SerializeField] private float sevenCount = 0;

        public bool canRun = false;

        private void Start()
        {
                CalculateTotalWeight();
                GameObject selectedSymbol = ChooseRandomSymbol();
                // This bool controls if update will run
                // canRun = true;
        }

        // Update is commented out unless checking for symbol percentage
        //private void Update()
        //{
        //        if (canRun)
        //        {
        //                canRun = false;
        //                CalculateTotalWeight();
        //                Symbols selectedSymbol = ChooseRandomSymbol();
        //                switch (selectedSymbol.name.ToString())
        //                {
        //                        case "Cherry":
        //                        cherryCount++;
        //                        canRun = true;
        //                        symbolTotal.Add("A");
        //                        break;

        //                        case "Watermelon":
        //                        watermelonCount++;
        //                        canRun = true;
        //                        symbolTotal.Add("A");
        //                        break;

        //                        case "Grape":
        //                        grapeCount++;
        //                        canRun = true;
        //                        symbolTotal.Add("A");
        //                        break;

        //                        case "Banana":
        //                        bananaCount++;
        //                        canRun = true;
        //                        symbolTotal.Add("A");
        //                        break;

        //                        case "Bell":
        //                        bellCount++;
        //                        canRun = true;
        //                        break;

        //                        case "Strawberry":
        //                        strawberryCount++;
        //                        canRun = true;
        //                        symbolTotal.Add("A");
        //                        break;

        //                        case "Plum":
        //                        plumCount++;
        //                        canRun = true;
        //                        symbolTotal.Add("A");
        //                        break;

        //                        case "Orange":
        //                        orangeCount++;
        //                        canRun = true;
        //                        symbolTotal.Add("A");
        //                        break;

        //                        case "Lemon":
        //                        lemonCount++;
        //                        canRun = true;
        //                        symbolTotal.Add("A");
        //                        break;

        //                        case "Bar":
        //                        barCount++;
        //                        canRun = true;
        //                        symbolTotal.Add("A");
        //                        break;

        //                        case "Seven":
        //                        sevenCount++;
        //                        canRun = true;
        //                        symbolTotal.Add("A");
        //                        break;
        //                }
        //        }
        //}

        public GameObject RandomSymbol()
        {
                CalculateTotalWeight();
                GameObject selectedSymbol = ChooseRandomSymbol();
                return selectedSymbol;
        }

        void CalculateTotalWeight()
        {
                totalWeight = 0;
                foreach (GameObject symbol in symbols)
                {
                        totalWeight += symbol.GetComponent<Symbols>().callChance;
                }
        }

        GameObject ChooseRandomSymbol()
        {
                float randomValue = Random.Range(1 , totalWeight + 1);
                int cumulativeWeight = 0;

                for (int i = 0; i < symbols.Count; i++)
                {
                        cumulativeWeight += symbols[i].GetComponent<Symbols>().callChance;
                        if (randomValue <= cumulativeWeight)
                        {
                                return symbols[i];
                        }
                }
                return symbols[symbols.Count - 1];
        }

        // Uncomment if want to print symbol percentages to console
        //private void OnApplicationQuit()
        //{
        //        Debug.Log("List count is " + symbolTotal.Count);
        //        Debug.Log("Cherry percentage: " + (cherryCount / symbolTotal.Count) * 100 + " %");
        //        Debug.Log("Watermelon percentage: " + (watermelonCount / symbolTotal.Count) * 100 + " %");
        //        Debug.Log("Grape percentage: " + (grapeCount / symbolTotal.Count) * 100 + " %");
        //        Debug.Log("Banana percentage: " + (bananaCount / symbolTotal.Count) * 100 + " %");
        //        Debug.Log("Bell percentage: " + (bellCount / symbolTotal.Count) * 100 + " %");
        //        Debug.Log("Strawberry percentage: " + (strawberryCount / symbolTotal.Count) * 100 + " %");
        //        Debug.Log("Plum percentage: " + (plumCount / symbolTotal.Count) * 100 + " %");
        //        Debug.Log("Orange percentage: " + (orangeCount / symbolTotal.Count) * 100 + " %");
        //        Debug.Log("Lemon percentage: " + (lemonCount / symbolTotal.Count) * 100 + " %");
        //        Debug.Log("Bar percentage: " + (barCount / symbolTotal.Count) * 100 + " %");
        //        Debug.Log("Seven percentage: " + (sevenCount / symbolTotal.Count) * 100 + " %");
        //}
}
