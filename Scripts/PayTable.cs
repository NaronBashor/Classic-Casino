using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayTable : MonoBehaviour
{
        public List<GameObject> symbols = new List<GameObject>();

        private int matchLength = 1;
        private int winAmount = 0;

        public int MatchLength
        {
                get
                {
                        return matchLength;
                }
                set
                {
                        matchLength = value;
                }
        }

        public int WinAmount
        {
                get
                {
                        return winAmount;
                }
                set
                {
                        winAmount = value;
                }
        }

        private void Start()
        {
                matchLength = 1;
        }

        public void CheckForWin()
        {
                for (int i = 0; i <= 9; i += 3)
                {
                        if (symbols[i].name == symbols[i + 3].name)
                        {
                                Debug.Log("Symbol " + i + " is " + symbols[i].name + " and is equal too " + (i + 3) + " which is " + symbols[i + 3].name);
                                matchLength++;
                        }
                        else
                        {
                                if (matchLength >= 3)
                                {
                                        WinningAmount(symbols[i].name , 3);
                                }
                        }
                }

                for (int i = 1; i <= 10; i += 3)
                {
                        if (symbols[i].name == symbols[i + 3].name)
                        {
                                Debug.Log("Symbol " + i + " is " + symbols[i].name + " and is equal too " + (i + 3) + " which is " + symbols[i + 3].name);
                                matchLength++;
                        }
                        else
                        {
                                if (matchLength >= 3)
                                {
                                        WinningAmount(symbols[i].name , 3);
                                }
                        }
                }

                for (int i = 2; i <= 11; i += 3)
                {
                        if (symbols[i].name == symbols[i + 3].name)
                        {
                                Debug.Log("Symbol " + i + " is " + symbols[i].name + " and is equal too " + (i + 3) + " which is " + symbols[i + 3].name);
                                matchLength++;
                        }
                        else
                        {
                                if (matchLength >= 3)
                                {
                                        WinningAmount(symbols[i].name , 3);
                                }
                        }
                }
        }

        public void WinningAmount(string name , int amount)
        {
                if (name == "Cherry(Clone)")
                {
                        if (amount == 3)
                        {
                                winAmount += 4;
                        }
                        else if (amount == 4)
                        {
                                winAmount += 8;
                        }
                        else if (amount == 5)
                        {
                                winAmount += 40;
                        }
                }
                if (name == "Watermelon(Clone)")
                {
                        if (amount == 3)
                        {
                                winAmount += 8;
                        }
                        else if (amount == 4)
                        {
                                winAmount += 25;
                        }
                        else if (amount == 5)
                        {
                                winAmount += 70;
                        }
                }
                if (name == "Grape(Clone)")
                {
                        if (amount == 3)
                        {
                                winAmount += 10;
                        }
                        else if (amount == 4)
                        {
                                winAmount += 50;
                        }
                        else if (amount == 5)
                        {
                                winAmount+= 100;
                        }
                }
                if (name == "Banana(Clone)")
                {
                        if (amount == 3)
                        {
                                winAmount += 12;
                        }
                        else if (amount == 4)
                        {
                                winAmount += 75;
                        }
                        else if (amount == 5)
                        {
                                winAmount += 125;
                        }
                }
                if (name == "Plum(Clone)")
                {
                        if (amount == 3)
                        {
                                winAmount += 15;
                        }
                        else if (amount == 4)
                        {
                                winAmount += 100;
                        }
                        else if (amount == 5)
                        {
                                winAmount += 250;
                        }
                }
                if (name == "Orange(Clone)")
                {
                        if (amount == 3)
                        {
                                winAmount += 20;
                        }
                        else if (amount == 4)
                        {
                                winAmount += 150;
                        }
                        else if (amount == 5)
                        {
                                winAmount += 500;
                        }
                }
                if (name == "Lemon(Clone)")
                {
                        if (amount == 3)
                        {
                                winAmount += 30;
                        }
                        else if (amount == 4)
                        {
                                winAmount += 200;
                        }
                        else if (amount == 5)
                        {
                                winAmount += 1000;
                        }
                }
                if (name == "Bar(Clone)")
                {
                        if (amount == 3)
                        {
                                winAmount += 30;
                        }
                        else if (amount == 4)
                        {
                                winAmount += 300;
                        }
                        else if (amount == 5)
                        {
                                winAmount += 2000;
                        }
                }
                if (name == "Seven(Clone)")
                {
                        if (amount == 3)
                        {
                                winAmount += 50;
                        }
                        else if (amount == 4)
                        {
                                winAmount += 350;
                        }
                        else if (amount == 5)
                        {
                                winAmount += 2500;
                        }
                }
        }

        #region Testing

        //public void DrawLine(Vector2 start , Vector2 end)
        //{
        //        GameObject myLine = new GameObject();
        //        myLine.transform.position = start;
        //        myLine.AddComponent<LineRenderer>();
        //        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        //        lr.startWidth = .1f;
        //        lr.endWidth = .1f;
        //        lr.SetPosition(0 , start);
        //        lr.SetPosition(1 , end);
        //        symbols.Add(myLine);
        //}

        //public void TestOneCheckForMatch()
        //{
        //                        if (symbols[6].name == symbols[9].name)
        //                        {
        //                                if (symbols[0].name == "Cherry(Clone)")
        //                                {
        //                                        winAmount = 8;
        //                                }
        //                                else if (symbols[0].name == "Watermelon(Clone)")
        //                                {
        //                                        winAmount = 25;
        //                                }
        //                                else if (symbols[0].name == "Grape(Clone)")
        //                                {
        //                                        winAmount = 50;
        //                                }
        //                                else if (symbols[0].name == "Banana(Clone)")
        //                                {
        //                                        winAmount = 75;
        //                                }
        //                                else if (symbols[0].name == "Plum(Clone)")
        //                                {
        //                                        winAmount = 100;
        //                                }
        //                                else if (symbols[0].name == "Orange(Clone)")
        //                                {
        //                                        winAmount = 150;
        //                                }
        //                                else if (symbols[0].name == "Lemon(Clone)")
        //                                {
        //                                        winAmount = 200;
        //                                }
        //                                else if (symbols[0].name == "Bar(Clone)")
        //                                {
        //                                        winAmount = 300;
        //                                }
        //                                else if (symbols[0].name == "Seven(Clone)")
        //                                {
        //                                        winAmount = 350;
        //                                }

        //                                if (symbols[9].name == symbols[12].name)
        //                                {
        //                                        if (symbols[0].name == "Cherry(Clone)")
        //                                        {
        //                                                winAmount = 40;
        //                                        }
        //                                        else if (symbols[0].name == "Watermelon(Clone)")
        //                                        {
        //                                                winAmount = 70;
        //                                        }
        //                                        else if (symbols[0].name == "Grape(Clone)")
        //                                        {
        //                                                winAmount = 100;
        //                                        }
        //                                        else if (symbols[0].name == "Banana(Clone)")
        //                                        {
        //                                                winAmount = 125;
        //                                        }
        //                                        else if (symbols[0].name == "Plum(Clone)")
        //                                        {
        //                                                winAmount = 250;
        //                                        }
        //                                        else if (symbols[0].name == "Orange(Clone)")
        //                                        {
        //                                                winAmount = 500;
        //                                        }
        //                                        else if (symbols[0].name == "Lemon(Clone)")
        //                                        {
        //                                                winAmount = 1000;
        //                                        }
        //                                        else if (symbols[0].name == "Bar(Clone)")
        //                                        {
        //                                                winAmount = 2000;
        //                                        }
        //                                        else if (symbols[0].name == "Seven(Clone)")
        //                                        {
        //                                                winAmount = 2500;
        //                                        }
        //                                }
        //                        }
        //                }
        //        }
        //        if (symbols[1].name == symbols[4].name)
        //        {
        //                if (symbols[4].name == symbols[7].name)
        //                {
        //                        winAmount = 3;
        //                        Debug.Log(winAmount);

        //                        if (symbols[7].name == symbols[70].name)
        //                        {
        //                                winAmount = 4;
        //                                Debug.Log(winAmount);

        //                                if (symbols[70].name == symbols[13].name)
        //                                {
        //                                        winAmount = 5;
        //                                        Debug.Log(winAmount);
        //                                }
        //                        }
        //                }
        //        }
        //        else
        //        {
        //                Debug.Log("No win.");
        //        }
        //}

        #endregion
}
