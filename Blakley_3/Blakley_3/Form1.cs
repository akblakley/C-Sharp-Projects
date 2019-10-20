//  Programmer: Amanda Blakley
//  Project:  Blakley_3
//  Due Date: 11/07/2018
//  Description: Individual Assignment #3

using System;
using System.IO;
using System.Windows.Forms;


namespace Blakley_3
{
    public partial class Form1 : Form
    { 
        //Declare constant at the class level
     
        private const decimal SALES_TAX = .07m;
        private const decimal inStorePickUp = 0.0m;
        private const decimal homeDelivery = 7.50m;
        private const decimal singleOrder = 9.95m;
        private const decimal halfDozenOrder = 39.95m;
        private const decimal dozenOrder = 65.95m;
        private const decimal customMessageOrder = 2.95m;
        private const decimal EXTRAS = 9.50m;

        // Declare class level variables 

        string deliveryType = "";
        string bundleSize = "";
        private decimal orderSubTotal = 0m;
        private decimal orderTotal = 0m;
        private decimal salesTax = 0m;
        
        public Form1()
        {
            InitializeComponent();
        }

        // Form load event 

        private void Form1_Load(object sender, EventArgs e)
        {

            PopulateBoxes(); //Call the Populate Boxes custom method 

            // Execute event immediately upon program startup
            // Display current date (reported by the system clock) in the delivery date textbox

            deliveryDateMaskedTextBox.Text = DateTime.Now.ToString("MM/dd/yyyy");


            // This code block sets all default values to be displayed when the form loads
            inStorePickupRadioButton.Enabled = true;
            singleRadioButton.Enabled = true;
            customMessageTextBox.Enabled = false;
            customMessageTextLimitLabel.Enabled = false;
            occasionComboBox.SelectedIndex = 1;
            orderSubTotalLabel.Text = "$0.00";
            inStorePickUpLabel.Text = "$0.00";
            homeDeliveryLabel.Text = "$7.50";
            singleOrderLabel.Text = "$9.95";
            halfDozenOrderLabel.Text = "$39.95";
            dozenOrderLabel.Text = "$65.95";
            customMessageLabel.Text = "$2.95";
            orderSubTotalLabel.Text = "$0.00";
            salesTaxLabel.Text = "$0.00";
            totalPriceLabel.Text = "$0.00";
            extrasPriceLabel.Text = "$9.50";
        }

        // Handles the 'Title' Combobox index changed event 

        private void titleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  Code that enables the user to add a string or object to the 'Title' combobox list 

            titleComboBox.Items.Add("");
        }

        // Handles the home delivery radio button's check changed event 

        private void homeDeliveryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (homeDeliveryRadioButton.Checked)
            {
                deliveryType = "Home";
            }
            else
            {
                deliveryType = "Store";
            }

            UpdateTotals(); // Call custom method to update calculated totals
        }

        // When user checks the custom message checkbox, the custom message textbox is enabled
        // When user unchecks the custom mesage checkbox, the custom message textbox is disabled

        private void customMessageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (customMessageCheckBox.Checked == true)
            {
                customMessageTextBox.Enabled = true;
                customMessageTextLimitLabel.Enabled = true;
            }
            if (customMessageCheckBox.Checked == false)
            {
                customMessageTextBox.Enabled = false;
                customMessageTextLimitLabel.Enabled = false;
            }

            UpdateTotals(); // Call custom method to update calculated totals
        }

        private void singleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (singleRadioButton.Checked)
            {
                bundleSize = "Single";
            }
            else if (halfDozenRadioButton.Checked)
            {
                bundleSize = "Half Dozen";
            }
            else if (dozensRadioButton.Checked)
            {
                bundleSize = "Dozens";
            }

            UpdateTotals(); // Call custom method to update calculated totals
        }

        // Handles the display summary button's click event
        // Simulate saved information displayed in a Message Box
        // Display all order information in a message box 

        private void displaySummaryButton_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Order Summary\n\n" +
                "Name: " + titleComboBox.Text + " " + firstNameTextBox.Text + " " + lastNameTextbox.Text + "\n" +
                "\n" +
                "Address: " + streetAddressTextBox.Text + " " + cityTextBox.Text + " " + stateTextBox.Text + zipCodeMaskedTextBox.Text + "\n" +
                "\n" +
                "Phone Number: " + phoneMaskedTextBox.Text + "\n" +
                "\n" +
                "Delivery Date: " + deliveryDateMaskedTextBox.Text + "\n" +
                "\n" +
                "Delivery Type: " + deliveryType + "\n" +
                "\n" +
                "Bundle Size: " + bundleSize + "\n" +
                "\n" +
                "Occasion: " + occasionComboBox.Text + "\n" +
                "\n" +
                "Extras: " + extrasListBox.Text + "\n" +
                "\n" +
                "Custom Message: " + customMessageTextBox.Text
                + "\n", "Order Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Display an error message 
                MessageBox.Show(ex.Message);
            }
        }

        private void clearFormButton_Click(object sender, EventArgs e)
        {
            ResetForm(); // Call custom method to clear the form 
        }

        private void ResetForm()
        {
            // Clear controls and reset form to its original state using custom method ResetForm
            titleComboBox.SelectedIndex = -1;
            firstNameTextBox.Text = "";
            lastNameTextbox.Text = "";
            phoneMaskedTextBox.Text = "";
            streetAddressTextBox.Text = "";
            cityTextBox.Text = "";
            stateTextBox.Text = "";
            zipCodeMaskedTextBox.Text = "";
            deliveryDateMaskedTextBox.Text = DateTime.Now.ToString("MM/dd/yyyyd");
            homeDeliveryRadioButton.Checked = false;
            inStorePickupRadioButton.Checked = true;
            singleRadioButton.Checked = true;
            halfDozenRadioButton.Checked = false;
            dozensRadioButton.Checked = false;
            occasionComboBox.SelectedIndex = 1;
            customMessageCheckBox.Checked = false;
            customMessageTextBox.Text = "";
            customMessageTextBox.Enabled = false; // Disable the custom message textbox until the UpdateTotals method runs
            customMessageTextLimitLabel.Enabled = false; // Disable the custom message label that displays the text limit
            orderSubTotalLabel.Text = "$0.00";
            salesTaxLabel.Text = "$0.00";
            totalPriceLabel.Text = "$0.00";
            extrasListBox.SelectedIndex = -1;
            titleComboBox.Focus(); // Focus is sent to the first data control box on the form 
        }

        // Handles the custom method for PopulateBoxes()
        // Populates the text in the occasion combobox and extras listbox 

        private void PopulateBoxes()
        {
            // Populates the Extras listbox with text read from an external file 

            try
            {
                // Declare a variable to hold type of extra selected
                string extraName;

                // Declare a StreamReader variable
                StreamReader inputFile;

                // Open the file and get a StreamReader object
                inputFile = File.OpenText("Extras.txt");

                // Read the files constants
                while (!inputFile.EndOfStream)
                {
                    // Get the name of the extra
                    extraName = inputFile.ReadLine();

                    // Add the name of the extra
                    extrasListBox.Items.Add(extraName);
                }
                // Close the file 
                inputFile.Close();
            }
            catch (Exception ex)
            {
                // Display an error message
                MessageBox.Show(ex.Message);
            }

            // Populates the Occasion combobox with text read from an external file 
            try
            {
                // Declare a variable to hold an occassion type
                string occasionType;

                // Declare a StreamReader variable 
                StreamReader inputFile;

                // Open the file and get a StreamReader object 
                inputFile = File.OpenText("Occasions.txt");

                // Read the files constants 
                while (!inputFile.EndOfStream)
                {
                    // Get the Occasion type 
                    occasionType = inputFile.ReadLine();

                    // Add the Occasion type 
                    occasionComboBox.Items.Add(occasionType);
                }
                // close the file 
                inputFile.Close();
            }
            catch (Exception ex)
            {
                // Display an error message 
                MessageBox.Show(ex.Message);
            }

        }
        private void UpdateTotals() // Call custom method to update the totals
        {
            // Calculate order subtotal amount 
            orderSubTotal = (inStorePickUp + homeDelivery) + (singleOrder + halfDozenOrder + dozenOrder) + customMessageOrder;

            // Calculate the amount of sales tax 
            salesTax = (inStorePickUp + homeDelivery + singleOrder + halfDozenOrder + dozenOrder + customMessageOrder) * SALES_TAX;

            // Calculate the order subtotal amount based on which delivery type radio button is selected 

            if (homeDeliveryRadioButton.Checked)
            {
                orderSubTotal = homeDelivery;
                salesTax = homeDelivery * SALES_TAX;
            }
            else
            {
                orderSubTotal = inStorePickUp;
                salesTax = inStorePickUp * SALES_TAX;
            }

            // Calculate the order subtotal amount based on which order size radio button is selected 

            if (singleRadioButton.Checked)
            {
                orderSubTotal = singleOrder;
                salesTax = singleOrder * SALES_TAX;
            }
            else if (halfDozenRadioButton.Checked)
            {
                orderSubTotal = halfDozenOrder;
                salesTax = halfDozenOrder * SALES_TAX;
            }
            else if (dozensRadioButton.Checked)
            {
                orderSubTotal = dozenOrder;
                salesTax = halfDozenOrder * SALES_TAX;
            }

            // Calculate the order amount based on whether the special message checkbox is selected

            if (customMessageCheckBox.Checked)
            {
                orderSubTotal = customMessageOrder;
                salesTax = customMessageOrder * SALES_TAX;
            }

            // Calculate the order amount based on whether an extra is selected 

          //if (extrasListBox.SelectedIndex = 1)
              //(
                  //orderSubTotal = EXTRAS;
         // )

            // Calculate the total price 
            orderTotal = orderSubTotal + salesTax;

            // Update display of values on form

            orderSubTotalLabel.Text = orderSubTotal.ToString("C");
            salesTaxLabel.Text = salesTax.ToString("C");
            totalPriceLabel.Text = orderTotal.ToString("c");

        }

        // Handles the instore pickup delivery check changed event 

        private void inStorePickupRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotals(); // Call custom method to update calculated totals
        }

        // Handles the half dozen size radio button's check changed event 

        private void halfDozenRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotals(); // Call custom method to update calculated totals
        }

        // Handles the dozen size radio button's check changed event 
        private void dozensRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotals(); // Call custom method to update calculated totals
        }

        // Exit program button click event - closes the application 

        private void exitProgramButton_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("Are you sure you wish to quit?", "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes) ;

            this.Close();
        }

        // Handles the Extras listbox selection event 
        private void extrasListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }
    }
}
