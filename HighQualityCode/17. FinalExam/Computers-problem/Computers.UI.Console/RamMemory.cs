namespace Computers.UI.Console
{
    using Computers.UI.Console.Interfaces;

    public class RamMemory : IRamMemory
    {
        private int value;

        internal RamMemory(int amount)
        {
            this.Amount = amount;
        }

        public int Amount { get; private set; }

        public void SaveValue(int newValue)
        {
            this.value = newValue;
        }

        public int LoadValue()
        {
            return this.value;
        }
    }
}
