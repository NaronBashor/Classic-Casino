using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReelSymbolManager : MonoBehaviour
{
        [SerializeField] private float reelStartDelay = 3f;

        public List<GameObject> cells = new List<GameObject>();
        public List<GameObject> spinningReels = new List<GameObject>();

        public GameObject instantiatedSymbols;

        private int index = 0;

        private bool startSpinning = false;
        private bool currentlySpinning = false;
        private bool isHeldDown = false;
        private bool autoSpin = false;
        private bool canSpin = false;

        #region Properties

        public bool CanSpin
        {
                get
                {
                        return canSpin;
                }
                set
                {
                        canSpin = value;
                }
        }

        public bool IsHeldDown
        {
                get
                {
                        return isHeldDown;
                }
                set
                {
                        isHeldDown = value;
                }
        }

        public bool AutoSpin
        {
                get
                {
                        return autoSpin;
                }
                set
                {
                        autoSpin = value;
                }
        }

        #endregion

        private void Start()
        {
                index = -1;
                canSpin = true;
                for (int i = 0; i < spinningReels.Count; i++)
                {
                        spinningReels[i].SetActive(false);
                }
        }

        private void Update()
        {
                if (canSpin && startSpinning && !currentlySpinning)
                {
                        canSpin = false;
                        currentlySpinning = true;
                        for (int i = 0; i < spinningReels.Count; i++)
                        {
                                spinningReels[i].SetActive(true);
                        }
                        for (int i = 0; i < cells.Count; i++)
                        {
                                cells[i].SetActive(false);
                        }
                        StartCoroutine(Delay(reelStartDelay));
                }
                if (index >= 4)
                {
                        GameObject payTable = GameObject.Find("PayTableManager");
                        payTable.GetComponent<PayTable>().CheckForWin();
                        Debug.Log(payTable.GetComponent<PayTable>().WinAmount);
                        payTable.GetComponent<PayTable>().WinAmount = 0;
                        canSpin = true;
                        currentlySpinning = false;
                        startSpinning = false;
                        StopAllCoroutines();
                        index = -1;
                        if (autoSpin)
                        {
                                GameObject instantiatedSymbols = GameObject.Find("InstantiatedSymbols");
                                int childCount = instantiatedSymbols.transform.childCount;
                                if (childCount > 0)
                                {
                                        for (int i = childCount - 1; i >= 0; i--)
                                        {
                                                Transform child = instantiatedSymbols.transform.GetChild(i);
                                                Destroy(child.gameObject);
                                        }
                                }
                                GameObject.Find("PayTableManager").GetComponent<PayTable>().symbols.Clear();
                                StartSpin();
                        }
                }
                if (isHeldDown)
                {
                        autoSpin = true;
                }
        }

        public void CellSymbolGeneration()
        {
                switch (index)
                {
                        case 0:
                        spinningReels[0].SetActive(false);
                        for (int i = 0; i < 3; i++)
                        {
                                GameObject symbolChosen = GameObject.Find("SymbolPrefabList").GetComponent<RandomSymbolSelection>().RandomSymbol();
                                GameObject symbol = Instantiate(symbolChosen , cells[i].transform.position , Quaternion.identity);
                                GameObject.Find("PayTableManager").GetComponent<PayTable>().symbols.Add(symbol);
                                symbol.transform.parent = instantiatedSymbols.transform;
                        }
                        break;

                        case 1:
                        spinningReels[1].SetActive(false);
                        for (int i = 3; i < 6; i++)
                        {
                                GameObject symbolChosen = GameObject.Find("SymbolPrefabList").GetComponent<RandomSymbolSelection>().RandomSymbol();
                                GameObject symbol = Instantiate(symbolChosen , cells[i].transform.position , Quaternion.identity);
                                GameObject.Find("PayTableManager").GetComponent<PayTable>().symbols.Add(symbol);
                                symbol.transform.parent = instantiatedSymbols.transform;
                        }
                        break;

                        case 2:
                        spinningReels[2].SetActive(false);
                        for (int i = 6; i < 9; i++)
                        {
                                GameObject symbolChosen = GameObject.Find("SymbolPrefabList").GetComponent<RandomSymbolSelection>().RandomSymbol();
                                GameObject symbol = Instantiate(symbolChosen , cells[i].transform.position , Quaternion.identity);
                                GameObject.Find("PayTableManager").GetComponent<PayTable>().symbols.Add(symbol);
                                symbol.transform.parent = instantiatedSymbols.transform;
                        }
                        break;

                        case 3:
                        spinningReels[3].SetActive(false);
                        for (int i = 9; i < 12; i++)
                        {
                                GameObject symbolChosen = GameObject.Find("SymbolPrefabList").GetComponent<RandomSymbolSelection>().RandomSymbol();
                                GameObject symbol = Instantiate(symbolChosen , cells[i].transform.position , Quaternion.identity);
                                GameObject.Find("PayTableManager").GetComponent<PayTable>().symbols.Add(symbol);
                                symbol.transform.parent = instantiatedSymbols.transform;
                        }
                        break;

                        case 4:
                        spinningReels[4].SetActive(false);
                        for (int i = 12; i < 15; i++)
                        {
                                GameObject symbolChosen = GameObject.Find("SymbolPrefabList").GetComponent<RandomSymbolSelection>().RandomSymbol();
                                GameObject symbol = Instantiate(symbolChosen , cells[i].transform.position , Quaternion.identity);
                                GameObject.Find("PayTableManager").GetComponent<PayTable>().symbols.Add(symbol);
                                symbol.transform.parent = instantiatedSymbols.transform;
                        }
                        break;
                }
                StartCoroutine(Delay(reelStartDelay));
        }

        public void StartSpin()
        {
                if (!startSpinning && canSpin)
                {
                        GameObject instantiatedSymbols = GameObject.Find("InstantiatedSymbols");
                        int childCount = instantiatedSymbols.transform.childCount;
                        if (childCount > 0)
                        {
                                for (int i = childCount - 1; i >= 0; i--)
                                {
                                        Transform child = instantiatedSymbols.transform.GetChild(i);
                                        Destroy(child.gameObject);
                                }
                        }
                        GameObject.Find("PayTableManager").GetComponent<PayTable>().symbols.Clear();
                        startSpinning = !startSpinning;
                }
                if (isHeldDown)
                {
                        isHeldDown = !isHeldDown;
                }
        }

        IEnumerator Delay(float seconds)
        {
                yield return new WaitForSeconds(seconds);
                index++;
                CellSymbolGeneration();
        }
}
