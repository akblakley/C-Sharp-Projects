// Programmer: Amanda Blakley
// Project: Blakley_1
// Due Date: 09/19/2018
// Description: Individual Assisgnment #1 

using System;
using System.Windows.Forms;

namespace Blakley_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void totalButton_Click(object sender, EventArgs e)
        {
            // Beginning of the try-catch block

            try
            {
                //Declare local constants

                const decimal TAX_RATE = 0.07m;

                // Declares all local variables, starting at 0, to prevent "use of unassigned local variable" error from ocurring

                int numberOfNights = 0;
                decimal miniBarCharge = 0.00m;
                decimal telephoneCharge = 0.00m;
                decimal miscCharge = 0.00m;
                decimal ratePerNight = 0.00m;
                decimal roomCharge;
                decimal additionalCharge;
                decimal subTotalCharge;
                decimal taxAmount;
                decimal totalCharge;

                // Reads values in textboxes and parses them to numeric values, stores values in numeric values declared aboved
                // Prevents a null value from throwing an exception

                if (numberOfNightsTextBox.Text != "")
                    numberOfNights = int.Parse(numberOfNightsTextBox.Text);
                if (miniBarChargeTextBox.Text != "")
                    miniBarCharge = decimal.Parse(miniBarChargeTextBox.Text);
                if (telephoneChargeTextBox.Text != "")
                    telephoneCharge = decimal.Parse(telephoneChargeTextBox.Text);
                if (miscChargeTextBox.Text != "")
                    miscCharge = decimal.Parse(miscChargeTextBox.Text);
                if (ratePerNightTextBox.Text != "")
                    ratePerNight = decimal.Parse(ratePerNightTextBox.Text);


                // Calculates total charge for each room class and overall cost
                // Displays values in appropriate labels

                roomCharge = ratePerNight * numberOfNights;
                roomChargeOutputLabel.Text = roomCharge.ToString("C");

                // Calculates additional charges incurred by the guest
                // Displays the amount of additional charges as a monetary value 

                additionalCharge = miniBarCharge + telephoneCharge + miscCharge;
                additionalChargeOutputLabel.Text = additionalCharge.ToString("C");

                // Calculates the subtotal charge incurred by the guest 
                // Displays the amount of the subtotal charge as a moneytary value

                subTotalCharge = roomCharge + additionalCharge;
                subTotalChargeOutputLabel.Text = subTotalCharge.ToString("C");

                // Calculates the amount in taxes incurred 
                // Displays the amount of taxes incurred during the guest's stay as a monetary value 

                taxAmount = TAX_RATE * subTotalCharge;
                taxAmountOutputLabel.Text = taxAmount.ToString("C");

                // Calculates the total charge incurred during the stay at the motel  
                // Displays the total charge incurred during the guests stay as a monetary value 

                totalCharge = subTotalCharge + taxAmount;
                totalChargeOutputLabel.Text = totalCharge.ToString("C");
            }

            // Catches any exceptions or invalid entries

            catch (Exception ex) 
            {
                // Displays a default error message if an error occurs

                MessageBox.Show("Hello! The entry is in an incorrect format!");
            }
            // Sends the focus to the 'clear' button

            clearButton.Focus();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Clears all input and output controls 

            roomNumberMaskedTextBox.Text = "";
            numberOfNightsTextBox.Text = "";
            ratePerNightTextBox.Text = "";
            miniBarChargeTextBox.Text = "";
            telephoneChargeTextBox.Text = "";
            miscChargeTextBox.Text = "";
            roomChargeOutputLabel.Text = "";
            additionalChargeOutputLabel.Text = "";
            subTotalChargeOutputLabel.Text = "";
            taxAmountOutputLabel.Text = "";
            subTotalChargeOutputLabel.Text = "";
            dateCheckedOutMaskedTextBox.Text = "";
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            totalChargeOutputLabel.Text = "";

            // Sends the focus to the first data control on the form, the check out date control
            // This prepares the form for the user to start a new data set 

            dateCheckedOutMaskedTextBox.Focus();
        }
        private void helpButton_Click(object sender, EventArgs e)
        {
            // Displays a message with instructions when a user needs assistance and clicks the 'help' button 
           
            MessageBox.Show(String.Join(Environment.NewLine,
                "Please follow the instructions:",
                "- Enter the check out date in the 'MM/DD/YYYY' format",
                "- Do not use special characters when entering the guest's information",
                "- Click the Total button to calculate all the charges the guest incurred",
                "- Click the Clear button to clear the form and start over",
                "- Exit when you are finished using the application"));
 
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Exits out of the form 

            this.Close();
        }
    }
}
