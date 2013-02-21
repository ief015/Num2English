using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Num2English
{
	public partial class frmN2E : Form
	{
		public frmN2E()
		{
			InitializeComponent();
		}

		private void clearOutput()
		{
			txtOutput.Text = "";
		}

		private void txtInput_TextChanged(object sender, EventArgs e)
		{
			if (txtInput.Text == String.Empty)
			{
				clearOutput();
				return;
			}

			decimal n = 0;

			if (System.Decimal.TryParse(txtInput.Text, out n))
			{
				int decimalPlace = txtInput.Text.IndexOf('.');
				decimalPlace = txtInput.Text.Length-1 - decimalPlace;

				txtOutput.Text = N2E.process(n, (uint)decimalPlace);
				return;
			}

			clearOutput();
		}
	}
}
