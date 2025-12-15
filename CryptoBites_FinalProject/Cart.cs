using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CryptoBites_FinalProject
{
    public partial class Cart : Form
    {
        private List<string> cartItems = new List<string>();
        private List<decimal> cartPrices = new List<decimal>();
        private string currentUsername;

        public Cart(string loggedInUser)
        {
            InitializeComponent();
            currentUsername = loggedInUser;

            
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            labelTotal.Text = "₱0.00";

            numericUpDownadobo.Minimum = 0;
            numericUpDownadobo.Maximum = 20;

            numericUpDownsinigang.Minimum = 0;
            numericUpDownsinigang.Maximum = 20;

            numericUpDowndiniguan.Minimum = 0;
            numericUpDowndiniguan.Maximum = 20;
        }


        // ---------------- Navigation Buttons ----------------
        private void btndrinks_Click(object sender, EventArgs e)
        {
            Dinks drinksForm = new Dinks(this, currentUsername);
            drinksForm.Show();
            this.Hide();
        }

        // ---------------- Add item to cart ----------------
        public void AddItemToCart(string itemName, decimal price, int quantity)
        {
            if (quantity <= 0)
            {
                MessageBox.Show("Please select a quantity before adding to cart.");
                return;
            }

            decimal subtotal = price * quantity;
            cartItems.Add($"{itemName} x{quantity}");
            cartPrices.Add(subtotal);
            listBox1.Items.Add($"{itemName} x{quantity}   ₱{subtotal:0.00}");
            UpdateTotal();
        }

        // ---------------- Back / Remove item ----------------
        private void btnback_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item to remove.");
                return;
            }

            int index = listBox1.SelectedIndex;
            cartItems.RemoveAt(index);
            cartPrices.RemoveAt(index);
            listBox1.Items.RemoveAt(index);
            UpdateTotal();
        }

        // ---------------- Checkout ----------------
        private void btncheck_Click(object sender, EventArgs e)
        {
            // Check if cart is empty
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty! Please add items before checking out.",
                                "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Determine selected payment method
            string paymentMethod = "";
            if (radioBtncash.Checked) paymentMethod = "Cash";
            else if (radioBtngcash.Checked) paymentMethod = "GCash";
            else if (radiobtncredit.Checked) paymentMethod = "Credit Card";

            if (string.IsNullOrEmpty(paymentMethod))
            {
                MessageBox.Show("Please select a payment method.",
                                "Select Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Build order summary
            string orderSummary = "";
            for (int i = 0; i < cartItems.Count; i++)
            {
                orderSummary += $"{cartItems[i]} - ₱{cartPrices[i]:0.00}\n";
            }

            decimal total = CalculateTotal();

            // Show confirmation dialog
            DialogResult confirm = MessageBox.Show(
                $"Your order:\n{orderSummary}\nTotal: ₱{total:0.00}\nPayment Method: {paymentMethod}\n\nDo you want to confirm your order?",
                "Confirm Order",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                MessageBox.Show(
                    $"Thank you for your order!\n\nPayment Method: {paymentMethod}\nTotal Amount: ₱{total:0.00}\n\nYour order is now being prepared!",
                    "Order Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Clear cart
                cartItems.Clear();
                cartPrices.Clear();
                listBox1.Items.Clear();
                UpdateTotal();

                // Reset payment method
                radioBtncash.Checked = false;
                radioBtngcash.Checked = false;
                radiobtncredit.Checked = false;
            }
        }

        // ---------------- Helper Methods ----------------
        private void UpdateTotal()
        {
            decimal total = CalculateTotal();
            labelTotal.Text = $"₱{total:0.00}";
        }

        private decimal CalculateTotal()
        {
            decimal sum = 0;
            foreach (var price in cartPrices)
                sum += price;
            return sum;
        }

        private void btnfood_Click(object sender, EventArgs e)
        {
            Foods foodForm = new Foods(this, currentUsername);
            foodForm.Show();
            this.Hide();
        }

        private void btnback_Click_1(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1();
            loginForm.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string aboutText =
           "🍔 Welcome to CryptoBites! 🍟\n\n" +
           "Where technology meets taste, right in the heart of Bayombong, Nueva Vizcaya.\n\n" +
           "At CryptoBites, every dish is inspired by digital culture — " +
           "from blockchain burgers to byte-sized snacks. " +
           "We pride ourselves on using fresh ingredients and bringing innovative flavors to your plate.\n\n" +
           "Founded by a team of food enthusiasts and tech explorers, " +
           "our mission is to combine fun, flavor, and convenience in every meal.\n\n" +
           "Whether you’re here for a quick lunch, a casual dinner, or a tech-inspired snack, " +
           "CryptoBites is your go-to spot for delicious, creative meals.\n\n" +
           "📍 Location: Bayombong, Nueva Vizcaya\n" +
           "💻 Connect with us online for promotions and updates.\n\n" +
           "Thank you for choosing CryptoBites — where your cravings meet creativity!";
            MessageBox.Show(aboutText, "About CryptoBites", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ---------------- Account Info ----------------
        private void btnaccnt_Click(object sender, EventArgs e)
        {
            string username = this.currentUsername;
            MessageBox.Show($"User: {username}\nEnjoy CryptoBites! Enjoy your Meal",
                            "Account Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void radioBtncash_CheckedChanged(object sender, EventArgs e) { }
        private void radioBtngcash_CheckedChanged(object sender, EventArgs e) { }
        private void radiobtncredit_CheckedChanged(object sender, EventArgs e) { }

       

        private void btnAddAdobo_Click(object sender, EventArgs e)
        {
            int quantity = (int)numericUpDownadobo.Value;
            AddItemToCart("Adobo", 120.00m, quantity);
            numericUpDownadobo.Value = 0;
        }


        private void btnAddSinigang_Click(object sender, EventArgs e)
        {
            int quantity = (int)numericUpDownsinigang.Value;
            AddItemToCart("Sinigang", 140.00m, quantity);
            numericUpDownsinigang.Value = 0;
        }


        private void btnAddDinuguan_Click(object sender, EventArgs e)
        {
            int quantity = (int)numericUpDowndiniguan.Value;
            AddItemToCart("Dinuguan", 130.00m, quantity);
            numericUpDowndiniguan.Value = 0;
        }
        // ---------------- View Cart ----------------
        public string GetCartSummary()
        {
            if (cartItems.Count == 0)
                return "Your cart is empty.";

            string summary = "";
            for (int i = 0; i < cartItems.Count; i++)
            {
                summary += $"{cartItems[i]} - ₱{cartPrices[i]:0.00}\n";
            }

            summary += $"\nTotal: {labelTotal.Text}";
            return summary;
        }

        private void btndrinks_Click_1(object sender, EventArgs e)
        {
            Dinks DinksForm = new Dinks(this, currentUsername);
            DinksForm.Show();
            this.Hide();
        }
    }
}
