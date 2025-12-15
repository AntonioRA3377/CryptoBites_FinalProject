using System;
using System.Windows.Forms;

namespace CryptoBites_FinalProject
{
    public partial class Dinks : Form
    {
        private Cart cart;       // reference to Cart
        private string username; // logged-in username

        public Dinks(Cart currentCart, string loggedInUser)
        {
            InitializeComponent();
            cart = currentCart;
            username = loggedInUser;
        }

        // 🔹 Helper method (ADDED)
        private void AddDrink(string name, decimal price, NumericUpDown qtyControl)
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
        }

        // Back to Cart
        private void btnBack_Click(object sender, EventArgs e)
        {
            cart.Show();
            this.Close();
        }

        // Add drinks to Cart (picture click – quick add 1)
        private void pictureBoxLemonade_Click(object sender, EventArgs e)
        {
            cart.AddItemToCart("Lemonade", 50.00m, 1);
        }

        private void pictureBoxSoda_Click(object sender, EventArgs e)
        {
            cart.AddItemToCart("Soda", 40.00m, 1);
        }

        // Account button
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Welcome to CryptoBites, {username}!",
                            "Account Info",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void button6_Click1(object sender, EventArgs e)
        {
            string aboutText =
                "🍔 Welcome to CryptoBites! 🍟\n\n" +
                "📍 Bayombong, Nueva Vizcaya\n\n" +
                "Thank you for choosing CryptoBites!";
            MessageBox.Show(aboutText, "About CryptoBites",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label4_Click(object sender, EventArgs e) { }

        private void btnfood_Click(object sender, EventArgs e)
        {
            Foods FoodsForm = new Foods(cart, username);
            FoodsForm.Show();
            this.Hide();
        }

        private void btndrinks_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please select Drinks.",
                            "Info",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cart.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"User: {username}\nEnjoy CryptoBites!",
                            "Account Info",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            string summary = cart.GetCartSummary();
            MessageBox.Show(summary, "Your Order",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        // ================= ADDED DRINK BUTTON LOGIC =================

        private void btnmango_Click(object sender, EventArgs e)
        {
            AddDrink("Mango Juice", 60.00m, numericUpDownmango);
        }

        private void btnlemonade_Click(object sender, EventArgs e)
        {
            AddDrink("Lemonade", 50.00m, numericUpDownlemon);
        }

        private void btnchoco_Click(object sender, EventArgs e)
        {
            AddDrink("Chocolate Drink", 55.00m, numericUpDownchoco);
        }

        private void btnmilktea_Click(object sender, EventArgs e)
        {
            AddDrink("Milk Tea", 70.00m, numericUpDownmilktea);
        }

        private void btnpineapp_Click(object sender, EventArgs e)
        {
            AddDrink("Pineapple Juice", 60.00m, numericUpDownpineapple);
        }

        private void btnapple_Click(object sender, EventArgs e)
        {
            AddDrink("Apple Juice", 55.00m, numericUpDownapple);
        }

        // NumericUpDown events not required (safe to leave empty)
        private void numericUpDownmango_ValueChanged(object sender, EventArgs e) { }
        private void numericUpDownlemon_ValueChanged(object sender, EventArgs e) { }
        private void numericUpDownchoco_ValueChanged(object sender, EventArgs e) { }
        private void numericUpDownmilktea_ValueChanged(object sender, EventArgs e) { }
        private void numericUpDownpineapple_ValueChanged(object sender, EventArgs e) { }
        private void numericUpDownapple_ValueChanged(object sender, EventArgs e) { }

        private void button5_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show($"User: {username}\nEnjoy CryptoBites!",
                            "Account Info",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            cart.Show();
            this.Close();
        }
    }
}
