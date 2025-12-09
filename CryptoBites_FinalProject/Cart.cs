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

            // Wire buttons (if not wired in Designer)
            this.btndrinks.Click += btndrinks_Click;
            this.btnfood.Click += btnfood_Click_1;
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            labelTotal.Text = "₱0.00";
        }

        // ---------------- Navigation Buttons ----------------
        private void btndrinks_Click(object sender, EventArgs e)
        {
            // Open Drinks form and hide Cart
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
        private void button5_Click(object sender, EventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("Your cart is empty!");
                return;
            }

            string paymentMethod = "";
            if (radioButton1.Checked) paymentMethod = "Cash";
            else if (radioButton2.Checked) paymentMethod = "GCash";
            else if (radioButton3.Checked) paymentMethod = "Credit Card";
            else
            {
                MessageBox.Show("Please select a payment method.");
                return;
            }

            decimal total = CalculateTotal();
            MessageBox.Show(
                $"Thank you for ordering at CryptoBites!\n\nPayment Method: {paymentMethod}\nTotal Amount: ₱{total:0.00}\n\nYour order is now being prepared!",
                "Order Complete",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            cartItems.Clear();
            cartPrices.Clear();
            listBox1.Items.Clear();
            UpdateTotal();
        }

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

        private void btnfood_Click_1(object sender, EventArgs e)
        {
            Foods foodForm = new Foods(this, currentUsername);
            foodForm.Show();
            this.Hide();
        }

       
            private void btnback_Click_1(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1(); // create a new login form
            loginForm.Show();               // show login form
            this.Close();                   // close current Cart form
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
            MessageBox.Show(aboutText, "About CryptoBites", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

    

