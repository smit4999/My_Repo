using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project {
    public partial class MainWindow : Form {
        public MainWindow() {
            InitializeComponent();
        }


        private void MainWindow_Load(object sender, EventArgs e) {

        }

        string hexchar = "ABCDEFabcdef";

        enum NumeralSystem {
            Bin, Dec, Hex
        }

        NumeralSystem CurrentNumeralSystem = NumeralSystem.Dec;

        private void radioButtonBin_CheckedChanged(object sender, EventArgs e) {
            if (CurrentNumeralSystem == NumeralSystem.Bin)
                return;
            var lastValue = CurrentNumeralSystem;
            CurrentNumeralSystem = NumeralSystem.Bin;
            ChangeNumeralSystem(lastValue);
        }

        private void radioButtonDec_CheckedChanged(object sender, EventArgs e) {
            if (CurrentNumeralSystem == NumeralSystem.Dec)
                return;
            var lastValue = CurrentNumeralSystem;
            CurrentNumeralSystem = NumeralSystem.Dec;
            ChangeNumeralSystem(lastValue);
        }

        private void radioButtonHex_CheckedChanged(object sender, EventArgs e) {
            if (CurrentNumeralSystem == NumeralSystem.Hex)
                return;
            var lastValue = CurrentNumeralSystem;
            CurrentNumeralSystem = NumeralSystem.Hex;
            ChangeNumeralSystem(lastValue);
        }

        private void ChangeNumeralSystem(NumeralSystem lastValue) {
            if (string.IsNullOrEmpty(textBoxNum.Text)) return;
            switch (CurrentNumeralSystem) {
                case NumeralSystem.Bin: {
                        textBoxNum.Text = (lastValue == NumeralSystem.Hex) ?
                            Convert.ToString(Convert.ToInt64(textBoxNum.Text, 16), 2) : textBoxNum.Text = Convert.ToString(long.Parse(textBoxNum.Text), 2);
                    }
                    break;
                case NumeralSystem.Dec: {
                        textBoxNum.Text = Convert.ToInt64(textBoxNum.Text, (lastValue == NumeralSystem.Bin) ? 2 : 16).ToString();
                    }
                    break;
                case NumeralSystem.Hex: {
                        if (lastValue == NumeralSystem.Bin) {
                            textBoxNum.Text = Convert.ToString(Convert.ToInt64(textBoxNum.Text, 2), 16);
                        }
                        else if (lastValue == NumeralSystem.Dec) {
                            textBoxNum.Text = Convert.ToString(long.Parse(textBoxNum.Text), 16);
                        }
                    }
                    break;
            }
        }

        private void textBoxNum_KeyPress(object sender, KeyPressEventArgs e) {
            if (((Keys)(e.KeyChar)) == Keys.Back)
                return;
            switch (CurrentNumeralSystem) {
                case NumeralSystem.Dec: {
                        e.Handled = (e.KeyChar == ',') ? textBoxNum.Text.Contains(',') : !char.IsDigit(e.KeyChar);
                    }
                    break;
                case NumeralSystem.Bin: {
                        e.Handled = !((e.KeyChar == '0') | (e.KeyChar == '1'));
                    }
                    break;
                case NumeralSystem.Hex: {
                        e.Handled = (hexchar.Contains(e.KeyChar)) ? false : !char.IsDigit(e.KeyChar);
                    }
                    break;
            }
        }

    }
}
