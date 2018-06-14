using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Text.RegularExpressions;

namespace calcTool
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] freq_unit = { "Hz", "kHz", "MHz", "GHz" };
        string[] period_unit = { "s", "ms", "us", "ns" };
        string[] f1_tim_name = { "TIM1", "TIM2", "TIM3", "TIM4" };
        string[] f4_tim_name = { "TIM1", "TIM2", "TIM3", "TIM4", "TIM5", "TIM6", "TIM7", "TIM8", "TIM9", "TIM10", "TIM11", "TIM12", "TIM13", "TIM14" };

        public MainWindow()
        {
            InitializeComponent();

            setPullDowmMenu();

            f1_radio_btn.IsChecked = true;
            setTimBox(1);
        }

        public void setPullDowmMenu()
        {

            foreach (string unit in freq_unit)
            {
                // 項目を追加する
                f_unit_menu.Items.Add(unit);
            }

            foreach (string unit in period_unit)
            {
                // 項目を追加する
                p_unit_menu.Items.Add(unit);
            }

            f_unit_menu.SelectedIndex = 0;
            p_unit_menu.SelectedIndex = 0;
        }

        public void setTimBox(int f)
        {
            use_tim_name.Items.Clear();

            if(f == 1)
            {
                foreach (string tim in f1_tim_name)
                {
                    // 項目を追加する
                    use_tim_name.Items.Add(tim);
                }
            }
            else if (f == 4)
            {
                foreach (string tim in f4_tim_name)
                {
                    // 項目を追加する
                    use_tim_name.Items.Add(tim);
                }
            }
            use_tim_name.SelectedIndex = 0;
        }


        private void p2f_Click(object sender, RoutedEventArgs e)
        {
            if (input_period.Text != "")
            {
                _p2f_();
            }
        }

        private void f2p_Click(object sender, RoutedEventArgs e)
        {
            if (input_freq.Text != "")
            {
                _f2p_();
            }
        }

        private void f_unit_menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (input_period.Text != "")
            {
                _p2f_();
            }
        }

        private void p_unit_menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(input_freq.Text != "")
            {
                _f2p_();
            }
        }

        void _p2f_()
        {
            try
            {
                checked
                {
                    Decimal tmp;
                    Decimal.TryParse(input_period.Text, out tmp);

                    tmp = (1.0m / (tmp * n2t(f_unit_menu.SelectedIndex))) * n2t(p_unit_menu.SelectedIndex);
                    input_freq.Text = tmp.ToString();
                }
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message, "エラー");
                clear_freq_period_input();
            }
            catch (Exception ex)
            {
                MessageBox.Show("入力値が不正です。\n(" + ex.Message + ")", "エラー");
                clear_freq_period_input();
            }
        }

        void _f2p_()
        {
            try
            {
                checked
                {
                    Decimal tmp;
                    Decimal.TryParse(input_freq.Text, out tmp);

                    tmp = (1.0m / (tmp * n2t(f_unit_menu.SelectedIndex))) * n2t(p_unit_menu.SelectedIndex);
                    input_period.Text = tmp.ToString();
                }
            }catch(OverflowException ex)
            {
                MessageBox.Show(ex.Message, "エラー");
                clear_freq_period_input();
            }
            catch (Exception ex)
            {
                MessageBox.Show("入力値が不正です。\n(" + ex.Message + ")", "エラー");
                clear_freq_period_input();
            }

        }

        int n2t(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return (int)Math.Pow(1000, n);
            }
        }

        private void input_freq_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            var text = input_freq.Text + e.Text;
            e.Handled = regex.IsMatch(text);
        }

        private void input_period_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            var text = input_period.Text + e.Text;
            e.Handled = regex.IsMatch(text);
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            input_freq.Clear();
            input_period.Clear();
        }

        private void input_binery_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-1]+");
            var text = input_freq.Text + e.Text;
            e.Handled = regex.IsMatch(text);
        }

        private void input_decimal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            var text = input_freq.Text + e.Text;
            e.Handled = regex.IsMatch(text);
        }

        private void input_hex_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9A-Fa-f]+");
            var text = input_freq.Text + e.Text;
            e.Handled = regex.IsMatch(text);
        }

        private void input_binery_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(input_binery.Text == "")
            {
                clear_radix_input();
            }
            else
            {
                try
                {
                    checked
                    {
                        int dec = Convert.ToInt32(input_binery.Text, 2);

                        input_decimal.Text = dec.ToString();
                        input_hex.Text = Convert.ToString(dec, 16);
                    }
                }
                catch(OverflowException ex)
                {
                    MessageBox.Show(ex.Message, "エラー");
                    clear_radix_input();
                }
            }
        }

        private void input_decimal_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (input_decimal.Text == "")
            {
                clear_radix_input();
            }
            else
            {
                try
                {
                    checked
                    {
                        int dec = Convert.ToInt32(input_decimal.Text, 10);

                        input_hex.Text = Convert.ToString(dec, 16);
                        input_binery.Text = Convert.ToString(dec, 2);
                    }
                }
                catch (OverflowException ex)
                {
                    MessageBox.Show(ex.Message, "エラー");
                    clear_radix_input();
                }
            }
        }

        private void input_hex_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (input_hex.Text == "")
            {
                clear_radix_input();
            }
            else
            {
                try
                {
                    checked
                    {
                        int dec = Convert.ToInt32(input_hex.Text, 16);

                        input_decimal.Text = dec.ToString();
                        input_binery.Text = Convert.ToString(dec, 2);
                    }
                }
                catch (OverflowException ex)
                {
                    MessageBox.Show(ex.Message, "エラー");
                    clear_radix_input();
                }
            }
        }

        private void clear_btn_Click(object sender, RoutedEventArgs e)
        {
            clear_radix_input();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //clear_freq_period_input();
            clear_radix_input();
        }

        void clear_radix_input()
        {
            input_binery.Clear();
            input_decimal.Clear();
            input_hex.Clear();
        }

        void clear_freq_period_input()
        {
            input_freq.Clear();
            input_period.Clear();
        }

        private void f1_radio_btn_Checked(object sender, RoutedEventArgs e)
        {
            f1_radio_btn.IsChecked = true;
            setTimBox(1);
        }

        private void f4_radio_btn_Checked(object sender, RoutedEventArgs e)
        {
            f4_radio_btn.IsChecked = true;
            setTimBox(4);
        }

        int[] periods;
        int[] prescalers;
        int ticker_num = 0;

        private void calc_btn_Click(object sender, RoutedEventArgs e)
        {
            int base_c = 0;

            if(f1_radio_btn.IsChecked == true)
            {
                base_c = 72000000;
            }
            else if(f4_radio_btn.IsChecked == true)
            {
                switch (use_tim_name.Text)
                {
                    case "TIM1":
                    case "TIM8":
                    case "TIM9":
                    case "TIM10":
                    case "TIM11":
                        base_c = 168000000;
                        break;

                    case "TIM2":
                    case "TIM3":
                    case "TIM4":
                    case "TIM5":
                    case "TIM6":
                    case "TIM7":
                    case "TIM12":
                    case "TIM13":
                    case "TIM14":
                        base_c = 84000000;
                        break;
                }
            }

            int pres = 1;
            int pur = Int32.Parse(it_freq.Text);
            periods = new int[1000];
            prescalers = new int[1000];
            ticker_num = 0;

            while (pres < 65535)
            {
                if((base_c / pur) % pres == 0)
                {
                   if((base_c / pur) / pres < 65535)
                   {
                        periods[ticker_num] = ((base_c / pur) / pres) - 1;
                        prescalers[ticker_num] = pres - 1;
                        ticker_num++;
                    }
                }
                pres++;
            }

            period_box.Items.Clear();
            pres_box.Items.Clear();

            for (int i = 0; i < ticker_num; i++)
            {
                period_box.Items.Add(periods[i].ToString());
                pres_box.Items.Add(prescalers[i].ToString());
            }

            period_box.SelectedIndex = 0;
            pres_box.SelectedIndex = 0;
        }

        private void period_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int num = period_box.SelectedIndex;
            pres_box.SelectedIndex = num;
        }

        private void pres_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int num = pres_box.SelectedIndex;
            period_box.SelectedIndex = num;
        }
    }
}
