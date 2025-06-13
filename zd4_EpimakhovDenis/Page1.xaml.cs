using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd4_EpimakhovDenis
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        //Взаимодействие со слайдером
        private void PercentSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            PercentLabel.Text = $"{e.NewValue:F0}%";
        }


        //Кнопка рассчитать
        private void CalculateButton_Clicked(object sender, EventArgs e)
        {
            double creditSum; //Сумма кредита
            int term; //Срок кредита
            double percent = (int)PercentSlider.Value; //Процентная ставка
            string paymentType = PaymentTypePicker.SelectedItem?.ToString(); //Вид платежа


            //Проверка на корректность ввода данных
            try
            {
                if (string.IsNullOrEmpty(CreditSumEntry.Text) || string.IsNullOrEmpty(TermEntry.Text) || PaymentTypePicker.SelectedItem == null)
                {
                    DisplayAlert("Ошибка", "Заполните все поля", "OK");
                    return;
                }

                try
                {
                    creditSum = double.Parse(CreditSumEntry.Text);
                    term = int.Parse(TermEntry.Text);
                }
                catch (FormatException)
                {
                    DisplayAlert("Ошибка", "Срок платежа должен быть целым числом", "OK");
                    return;
                }

                try
                {
                    CreditCalculator.CheckedValidCreditSum(creditSum);
                    CreditCalculator.CheckedValidTerm(term);
                }
                catch (Exception ex)
                {
                    DisplayAlert("Ошибка", ex.Message, "OK");
                    return;
                }

                //Условие выбор вида кредита - Аннуитетный
                if (paymentType == "Аннуитетный")
                {
                    double monthPayment = CreditCalculator.CalculateAnnuityMonthPayment(creditSum, term, percent);
                    double totalSum = CreditCalculator.CalculateAnnuityTotalSum(monthPayment, term);
                    double overpayment = CreditCalculator.CalculateAnnuityOverpayment(creditSum, monthPayment, term);

                    MonthPaymentLabel.Text = monthPayment.ToString();
                    TotalSumLabel.Text = totalSum.ToString();
                    OverpaymentLabel.Text = overpayment.ToString();
                }
                else
                {
                    MonthPaymentLabel.Text = "Нет";
                    TotalSumLabel.Text = "Нет";
                    OverpaymentLabel.Text = "Нет";
                }

            }
            catch (Exception ex)
            {
                MonthPaymentLabel.Text = "........";
                TotalSumLabel.Text = "........";
                OverpaymentLabel.Text = "........";
                DisplayAlert("Ошибка", ex.Message, "OK");
            }
        }

    }
}