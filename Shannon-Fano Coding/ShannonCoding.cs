using System;
using System.Collections.Generic;
using System.Text;


namespace Shannon_Fano_Coding
{
    public class ShannonCoding
    {
        private decimal probability;
        private decimal accumulateProb;
        private decimal logProb;
        private int codeLength;
        private string binaryCode;
        private string code;

        public static string dec2bin(decimal src)
        {
            string res = "0.";
            for(int i=0;i<6;i++)
            {
                src *= 2;
                decimal temp = Math.Truncate(src);
                string addToEnd = Convert.ToString(Convert.ToInt32(temp));
                res += addToEnd;
                src -= temp;
            }
            return res;
        }

        public decimal Probability
        {
            get
            {
                return this.probability;
            }
            set
            {
                this.probability = value;
            }
        }

        public decimal AccumulateProb
        {
            get
            {
                return this.accumulateProb;

            }

            set
            {
                this.accumulateProb = value;
            }
        }

        public decimal LogProb
        {
            get
            {
                return this.logProb;

            }

            set
            {
                this.logProb = value;
            }
        }

        public string BinaryCode
        {
            get
            {
                return this.binaryCode;

            }

            set
            {
                this.binaryCode = value;
            }
        }

        public int CodeLength
        {
            get
            {
                return this.codeLength;

            }

            set
            {
                this.codeLength = value;
            }
        }

        public string Code
        {
            get 
            {
                return this.code;
            }

            set
            {
                this.code = value;
            }
        }

        public ShannonCoding(decimal prob)
        {

            probability = prob;
        }
        
        
/*        public string[] CalcCode()
        {
            for(int i=0;i<accumulateProb.Length;i++)
            {
                binaryCode[i] = ShannonCoding.dec2bin(accumulateProb[i]);
            }
            return binaryCode;
        }*/


    }
}
