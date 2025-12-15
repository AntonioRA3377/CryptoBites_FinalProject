using System;
using System.Windows.Forms;

namespace CryptoBites_FinalProject
{
    public partial class Foods : Form
    {
        private Cart cart;       // reference to Cart
        private string username; // logged-in username

        public Foods(Cart currentCart, string loggedInUser)
        {
            InitializeComponent();
            cart = currentCart;
            username = loggedInUser;
        }

        // 🔹 Helper method (ADDED)
        private void AddFood(string name, decimal price, NumericUpDown qtyControl)
        {
            int qty = (int)qtyControl.Value;

            if (qty <= 0)
            {
                MessageBox.Show("Please select a quantity.",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            cart.AddItemToCart(name, price, qty);

            MessageBox.Show($"{qty} x {name} added to cart!",
                            "Added",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            qtyControl.Value = 0;
        }

        // ---------------- Navigation ----------------

        private void btnBack_Click(object sender, EventArgs e)
        {
            cart.Show();
            this.Close();
        }

        // ---------------- Account / About ----------------

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Welcome to CryptoBites, {username}!",
                            "Account Info",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            string aboutText =
                "🍔 Welcome to CryptoBites! 🍟\n\n" +
                "📍 Bayombong, Nueva Vizcaya\n\n" +
                "Thank you for choosing CryptoBites!";
            MessageBox.Show(aboutText,
                            "About CryptoBites",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        // ---------------- Navigation Buttons ----------------

        private void btndrinks_Click_1(object sender, EventArgs e)
        {
            Dinks drinksForm = new Dinks(cart, username);
            drinksForm.Show();
            this.Hide();
        }

        private void btnfood_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please select Food.",
                            "Info",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        // ---------------- View Cart ----------------

        private void btnviewcart_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cart.GetCartSummary(),
                            "Your Order",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cart.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show($"User: {username}\nEnjoy CryptoBites!",
                            "Account Info",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        // ================= FOOD BUTTONS =================

        private void btnBurger_Click(object sender, EventArgs e)
        {
            AddFood("Crypto Burger", 129.00m, numericUpDownBurger);
        }

        private void btnFries_Click(object sender, EventArgs e)
        {
            AddFood("Blockchain Fries", 89.00m, numericUpDownFries);
        }

        private void btnChicken_Click(object sender, EventArgs e)
        {
            AddFood("Satoshi Chicken", 149.00m, numericUpDownChicken);
        }

        private void btnpizza_Click(object sender, EventArgs e)
        {
            AddFood("Crypto Pizza", 199.00m, numericUpDownpizza);
        }

        private void btnhotdog_Click(object sender, EventArgs e)
        {
            AddFood("Blockchain Hotdog", 79.00m, numericUpDownhotdog);
        }

        private void btnpancit_Click(object sender, EventArgs e)
        {
            AddFood("Crypto Pancit", 99.00m, numericUpDownpancit);
        }

        // ---------------- NumericUpDown Safety ----------------

        private void numericUpDownBurger_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownBurger.Value < 0) numericUpDownBurger.Value = 0;
        }

        private void numericUpDownFries_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownFries.Value < 0) numericUpDownFries.Value = 0;
        }

        private void numericUpDownChicken_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownChicken.Value < 0) numericUpDownChicken.Value = 0;
        }

        private void numericUpDownpizza_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownpizza.Value < 0) numericUpDownpizza.Value = 0;
        }

        private void numericUpDownhotdog_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownhotdog.Value < 0) numericUpDownhotdog.Value = 0;
        }

        private void numericUpDownpancit_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownpancit.Value < 0) numericUpDownpancit.Value = 0;
        }

        private void txtsearchbar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
