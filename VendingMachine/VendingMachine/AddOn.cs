using System;

namespace VendingMachine
{
    public class Addon : Product
    {
        public enum AddOnNames
        {
            Sugar,
            Cream
        }

        public override sealed string Name { get; set; }

        public override int Price { get; set; }



        public Addon(AddOnNames name)
        {
            this.Name = name.ToString();
            SetPrice(name);
        }

        private void SetPrice(AddOnNames name)
        {
            switch (name)
            {
                case AddOnNames.Sugar:
                    Price = 25;
                    break;
                case AddOnNames.Cream:
                    Price = 25;
                    break;
            }
        }
    }
}
