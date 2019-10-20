//  Programmer: Amanda Blakley
//  Project:  Blakley_2
//  Due Date: 02/23/2018
//  Description: Individual Assignment #2

using System;
using System.Windows.Forms;

namespace Blakley_2
{
    public partial class Form1 : Form
    {
        // Declare class-level constants for later use in the program
        private const decimal InStateCourseCost = 49.00m;
        private const decimal outOfStateCourseCost = 99.00m;
        private bool isInState = true;
        private decimal orderTotal = 0.00m;
        private int numberOfCourses = 0;

        public Form1()
        {
            InitializeComponent();
        }
        // Handle the other in-state radio button's check changed event
        private void inStateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (inStateRadioButton.Checked)
            {
                isInState = true;
                orderTotal = numberOfCourses * InStateCourseCost;
                orderTotalLabel.Text = orderTotal.ToString("c");
            }
        }
        // Handle the out-of-state radio button's check changed event 
        private void outStateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (outStateRadioButton.Checked)
            {
                isInState = false;
                orderTotal = numberOfCourses * outOfStateCourseCost;
                orderTotalLabel.Text = orderTotal.ToString("c");
            }
        }
        // This totals whether the Beginning French check box is checked or not 
        private void beginningFrenchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (beginningFrenchCheckBox.Checked == true)
            {
                if (isInState == true)
                {
                    orderTotal += InStateCourseCost;
                }
                else
                {
                    orderTotal += outOfStateCourseCost;
                }

                numberOfCourses += 1;
            }
            else
            {
                if (isInState)
                {
                    orderTotal -= InStateCourseCost;
                }
                else
                {
                    orderTotal -= outOfStateCourseCost;
                }

                numberOfCourses -= 1;
            }
            orderTotalLabel.Text = orderTotal.ToString("c");
            numberOfCoursesLabel.Text = numberOfCourses.ToString();
        }
        // This totals whether the Beginning German check box is checked or not 
        private void beginningGermanCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (beginningGermanCheckBox.Checked == true)
            {
                if (isInState == true)
                {
                    orderTotal += InStateCourseCost;
                }
                else
                {
                    orderTotal += outOfStateCourseCost;
                }
                
                numberOfCourses += 1;
            }
            else
            {
                if (isInState)
                {
                    orderTotal -= InStateCourseCost;
                }
                else
                {
                    orderTotal -= outOfStateCourseCost;
                }

                numberOfCourses -= 1;
            }
            orderTotalLabel.Text = orderTotal.ToString("C");
            numberOfCoursesLabel.Text = numberOfCourses.ToString();
        }
        // This totals whether the Beginning Italian check box is checked or not 
        private void beginningItalianCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (beginningItalianCheckBox.Checked == true)
            {
                if (isInState == true)
                {
                    orderTotal += InStateCourseCost;
                }
                else
                {
                    orderTotal += outOfStateCourseCost;
                }

                numberOfCourses += 1;
            }
            else
            {
                if (isInState == true)
                {
                    orderTotal -= InStateCourseCost;
                }
                else
                {
                    orderTotal -= outOfStateCourseCost;
                }

                numberOfCourses -= 1;
            }
            orderTotalLabel.Text = orderTotal.ToString("C");
            numberOfCoursesLabel.Text = numberOfCourses.ToString();
        }
        // This totals whether the Beginning Russian check box is checked or not
        private void beginningRussianCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (beginningRussianCheckBox.Checked == true)
            {
                if (isInState == true)
                {
                    orderTotal += InStateCourseCost;
                }
                else
                {
                    orderTotal += outOfStateCourseCost;
                }

                numberOfCourses += 1;
            }
            else
            {
                if (isInState)
                {
                    orderTotal -= InStateCourseCost;
                }
                else
                {
                    orderTotal -= outOfStateCourseCost;
                }

                numberOfCourses -= 1;
            }
            orderTotalLabel.Text = orderTotal.ToString("C");
            numberOfCoursesLabel.Text = numberOfCourses.ToString();            
        }
        // This totals whether the Beginning Spanish check box is checked or not
        private void beginningSpanishCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (beginningSpanishCheckBox.Checked == true)
            {
                if (isInState)
                {
                    orderTotal += InStateCourseCost;
                }
                else
                {
                    orderTotal += outOfStateCourseCost;
                }

                numberOfCourses += 1;
            }
            else
            {
                if (isInState)
                {
                    orderTotal -= InStateCourseCost;
                }
                else
                {
                    orderTotal -= outOfStateCourseCost;
                }
                numberOfCourses -= 1;
            }
            orderTotalLabel.Text = orderTotal.ToString("C");
            numberOfCoursesLabel.Text = numberOfCourses.ToString();
        }
        // Handles the Clear button's click event 
        // Clears data entry controls and resets the form to the start-up appearance 
        private void clearButton_Click(object sender, EventArgs e)
        {
            fallRadioButton.Checked = true;
           // yearComboBox.SelectedIndex = "";
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            emailTextBox.Text = "";
            studentIDMaskedTextBox.Text = "";
            inStateRadioButton.Checked = true;
            creditcardNumberTextBox.Text = "";
            expirationDateMaskedTextBox.Text = "";
            mastercardRadioButton.Checked = true;
            beginningFrenchCheckBox.Checked = false;
            beginningGermanCheckBox.Checked = false;
            beginningItalianCheckBox.Checked = false;
            beginningRussianCheckBox.Checked = false;
            beginningSpanishCheckBox.Checked = false;

            // Sends focus to first control on form
            fallRadioButton.Focus();
        }

        // Handles the exit button's click event
        // Message box will apear prior to closing the application, prompting user to click 'yes' or 'no'
        // If 'yes' is clicked, the form will close and end the program 
        private void exitButton_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("Are you sure you wish to quit?", "Question",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
            {
                this.Close();
            }
            this.Close();
        }
    }
}   