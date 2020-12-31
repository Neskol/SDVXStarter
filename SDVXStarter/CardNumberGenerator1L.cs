using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDVXStarter
{
    /**
     * Create a card generator.
     */
    public class CardNumberGenerator1L : ICardNumberGenerator
    {
        public const string CHAR_ALLOWED = "01234567890ABCDEF";
       
       /// <summary>
       /// Constructor.
       /// </summary>
        public CardNumberGenerator1L()
        {   
        }

        public string Generate()
        { 
            string result = "E004";
            Random rd = new Random();

            for (int i = 0; i<12; i++)
            {
                result += (CHAR_ALLOWED.ToCharArray())[rd.Next(0,15)];
            }

            return result;
        }

        public bool Verify(string cardNumber)
        {
            char[] array = cardNumber.ToCharArray();
            bool valid = array.Length == 16;


            for (int i = 0; i<16 && valid; i++)
            {
                if (i == 0)
                {
                    valid = array[i] == 'E';
                }
                else if (i == 1 || i==2)
                {
                    valid = array[i] == '0';
                }
                else if (i == 3)
                {
                    valid = array[i] == '4';
                }
                else
                {
                    valid = CHAR_ALLOWED.Contains(array[i]);
                }
            }
            return valid;
        }

        public string AllowedArray
        {
            get
            {
                return CHAR_ALLOWED;
            }
        }
    }
}
