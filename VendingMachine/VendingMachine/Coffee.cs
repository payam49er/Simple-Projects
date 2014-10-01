using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Coffee:Product
    {
        public enum Size
        {
           Small,
           Medium,
           Large
        }
        public override sealed string Name { get; set; }

        public override int Price { get; set; }

        public Coffee(Size size)
        {
            SetName(size);
            SetPrice(size);
        }


        private void SetName(Size size)
        {
            switch (size)
            {
                case Size.Small:
                    Name = "Small Coffee";
                    break;
                case Size.Medium:
                    Name = "Medium Coffee";
                    break;
                case Size.Large:
                    Name = "Large Coffee";
                    break;
            }
        }

        //ideally, the prices should be read from an XML or text file to make this app data driven
        // rather than hard coding in the app. 
        private void SetPrice(Size size)
        {
            switch (size)
            {
                case Size.Small:
                    Price = 175;
                    break;
                case Size.Medium:
                    Price = 200;
                    break;
                case Size.Large:
                    Price = 225;
                    break;
            }
        }

    }
}
