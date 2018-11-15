using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Globalization;

namespace ScreenshotApp
{
    public class Hotkey
    {
        /// <summary>
        /// Typical hotkey assigngments
        /// </summary>
        public enum fsModifiers
        {
            Alt = 0x0001,
            Control = 0x0002,
            Shift = 0x0004, // Changes!
            Window = 0x0008,
        }

        private IntPtr _hWnd;

        public Hotkey(IntPtr hWnd)
        {
            this._hWnd = hWnd;
        }

        public void UnRegisterHotKeys()
        {
            UnregisterHotKey(_hWnd, 1);
        }

        #region WindowsAPI
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public static implicit operator SortKey(Hotkey v)
        {
            throw new NotImplementedException();
        }
        #endregion

        public void SetSnipHotkey(string modifier, string key)
        {
            RegisterHotKey(_hWnd, 2, GetModifier(modifier), GetKey(key));
        }

        public void SetWindowCaptureHotkey(string modifier, string key)
        {
            RegisterHotKey(_hWnd, 1, GetModifier(modifier), GetKey(key));
        }

        private uint GetModifier(string modifier)
        {
            switch (modifier)
            {
                case "Ctrl + Alt":
                    return (uint)fsModifiers.Control | (uint)fsModifiers.Alt;
                case "Ctrl":
                    return (uint)fsModifiers.Control;
                default:
                    throw new Exception("Modifier not supported.");
            }
        }

        private uint GetKey(string key)
        {
            switch (key)
            {
                case "A": return (uint)Keys.A;
                case "B": return (uint)Keys.B;
                case "C": return (uint)Keys.C;
                case "D": return (uint)Keys.D;
                case "E": return (uint)Keys.E;
                case "F": return (uint)Keys.F;
                case "G": return (uint)Keys.G;
                case "H": return (uint)Keys.H;
                case "I": return (uint)Keys.I;
                case "J": return (uint)Keys.J;
                case "K": return (uint)Keys.K;
                case "L": return (uint)Keys.L;
                case "M": return (uint)Keys.M;
                case "N": return (uint)Keys.N;
                case "O": return (uint)Keys.O;
                case "P": return (uint)Keys.P;
                case "Q": return (uint)Keys.Q;
                case "R": return (uint)Keys.R;
                case "S": return (uint)Keys.S;
                case "T": return (uint)Keys.T;
                case "U": return (uint)Keys.U;
                case "V": return (uint)Keys.V;
                case "W": return (uint)Keys.W;
                case "X": return (uint)Keys.X;
                case "Y": return (uint)Keys.Y;
                case "Z": return (uint)Keys.Z;
                default: throw new Exception("Key not supported.");
            }
        }
    }
}
