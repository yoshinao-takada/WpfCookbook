using System;
using System.Windows;
using System.Windows.Input;

/// <summary>
/// Types for Inter-Object Communication
/// </summary>
namespace WpfUserControlLib
{
    /// <summary>
    /// It is for an input event with an int type data; For example, software keyboard click
    /// </summary>
    public class KeyButtonClickedEventArgs : InputEventArgs
    {
        private int keyCode_;

        public int KeyCode
        {
            get => keyCode_;
        }

        public KeyButtonClickedEventArgs(InputDevice device, int keyCode)
            : base(device, (int)DateTime.Now.ToFileTime())
        {
            keyCode_ = keyCode;
        }
    }

    /// <summary>
    /// It handles an input event with int type input data; for example key-code of software keyboards.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void InputEventHandler(object sender, KeyButtonClickedEventArgs e);

    /// <summary>
    /// double-to-string converter
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public delegate string D2s(double d);

    /// <summary>
    /// long-to-string converter
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public delegate string L2s(long l);

    /// <summary>
    /// bool-to-string converter
    /// </summary>
    /// <param name="b"></param>
    /// <returns></returns>
    public delegate string B2s(bool b);

}
