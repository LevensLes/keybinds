using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleKeyBinds
{
    public partial class Form1 : Form
    {
        private KeyboardHook keyboardHook = new KeyboardHook();
        public bool IsToggled;
        public Form1()
        {
            InitializeComponent();
            keyboardHook.KeyUp += KeyboardHook_KeyUp;
            keyboardHook.Install();

        }
        public KeyboardHook.VKeys KeyBind;
        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            button1.Text = ">...<";
            KeyBind = KeyboardHook.ConvertToBindable(e);
            button1.Text = KeyBind.ToString();

        }

        private void KeyboardHook_KeyUp(KeyboardHook.VKeys key)
        {
            if (key == KeyBind || key == KeyboardHook.VKeys.SHIFT)
            {
                IsToggled = !IsToggled;
            label1.Text = (IsToggled ? "TOGGLED: YES" : "TOGGLED: NO");
            }
           
        }


    }
}
