using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbols : MonoBehaviour
{
        public string symbolName;
        public int callChance;

        public Symbols(string symbolName , int callChance)
        {
                this.symbolName = symbolName;
                this.callChance = callChance;
        }
}
