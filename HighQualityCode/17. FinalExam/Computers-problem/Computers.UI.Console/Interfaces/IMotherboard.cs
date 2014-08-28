namespace Computers.UI.Console.Interfaces
{
    /// <summary>
    /// Represents the motherboard of one computer.
    /// It can load values from the RAM, save values to the RAM and draw on the video card.
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// A method for loading values from the computer's RAM memory.
        /// </summary>
        /// <returns>Returns the loaded value from the RAM memory.</returns>
        int LoadRamValue();

        /// <summary>
        /// A method for saving values to the computer's RAM memory.
        /// </summary>
        /// <param name="value">The value that will be saved to the RAM memory.</param>
        void SaveRamValue(int value);

        /// <summary>
        /// A method that takes some string data and draws it to the video card.
        /// </summary>
        /// <param name="data">The data that will be drawn on the video card.</param>
        void DrawOnVideoCard(string data);
    }
}
