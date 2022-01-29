using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using GlobalKeyHookDemo.helpers;

namespace GlobalKeyHookDemo
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly KeyboardHook _hook = new KeyboardHook();

        private readonly List<string> _wisdom = new List<string>
        {
            "The greatest glory in living lies not in never falling, but in rising every time we fall. -Nelson Mandela",
            "The way to get started is to quit talking and begin doing. -Walt Disney",
            "Your time is limited, so don't waste it living someone else's life. Don't be trapped by dogma – which is living with the results of other people's thinking. -Steve Jobs",
            "If life were predictable it would cease to be life, and be without flavor. -Eleanor Roosevelt",
            "If you look at what you have in life, you'll always have more. If you look at what you don't have in life, you'll never have enough. -Oprah Winfrey",
            "If you set your goals ridiculously high and it's a failure, you will fail above everyone else's success. -James Cameron",
            "Life is what happens when you're busy making other plans. -John Lennon"
        };

        private readonly Random _rand = new Random();

        public MainWindow()
        {
            InitializeComponent();

            _hook.KeyPressed += hook_KeyPressed;
            _hook.RegisterHotKey(ModifierKeys.None, Keys.F8);
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e) { txtQuote.Text = _wisdom[_rand.Next(_wisdom.Count)]; }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e) { _hook.Dispose(); }
    }
}