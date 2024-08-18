using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App9
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			radioButton1.CheckedChanged += RadioButton_CheckedChanged;
			radioButton2.CheckedChanged += RadioButton_CheckedChanged;
			radioButton3.CheckedChanged += RadioButton_CheckedChanged;
			radioButton4.CheckedChanged += RadioButton_CheckedChanged;
			radioButton5.CheckedChanged += RadioButton_CheckedChanged;
			radioButton6.CheckedChanged += RadioButton_CheckedChanged;
		}
		private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			RadioButton selectedRadioButton = (RadioButton)sender;

			if (e.Value)
			{
				string selectedValue = selectedRadioButton.Content.ToString();
				rd.Text = "Consumption: " + selectedValue;
			}
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			double consumptionCharge = 0;
			double demandCharge = 0;
			double serviceCharge = 0;
			double addOns = 0;
			double VAT = 0;

			// Calculate consumption charge based on selected radio button
			if (radioButton1.IsChecked)
				consumptionCharge = 2.50;
			else if (radioButton2.IsChecked)
				consumptionCharge = 3.50;
			else if (radioButton3.IsChecked)
				consumptionCharge = 4.50;
			else if (radioButton4.IsChecked)
				consumptionCharge = 5.50;
			else if (radioButton5.IsChecked)
				consumptionCharge = 6.00;
			else if (radioButton6.IsChecked)
				consumptionCharge = 6.50;

			// Calculate demand and service charge based on selected picker item
			if (myPicker.SelectedIndex == 0) // Type 1
			{
				demandCharge = 20;
				serviceCharge = 5;
			}
			else if (myPicker.SelectedIndex == 1) // Type 2
			{
				demandCharge = 40;
				serviceCharge = 10;
			}

			// Calculate add-ons based on checkbox selection
			if (checkbox1.IsChecked)
				addOns += 2500;
			if (checkbox2.IsChecked)
				addOns += 0; // No add-ons for old members

			// Calculate principal amount
			double principalAmount = (Convert.ToDouble(cons.Text) * consumptionCharge) + demandCharge + serviceCharge + addOns;

			// Calculate VAT
			VAT = 0.05 * principalAmount;

			// Calculate amount payable
			double amountPayable = principalAmount + VAT;

			// Update labels with calculated values
			PA.Text = "Principal Amount: " + principalAmount;
			AP.Text = "Amount Payable: " + amountPayable;
			VA.Text = "VAT: " + VAT;
		}
	}
}