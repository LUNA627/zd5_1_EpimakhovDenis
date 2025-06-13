using System;
using System.Collections.Generic;
using System.Text;

namespace zd4_EpimakhovDenis
{
    //Класс с логикой кредитного калькулятора
    public static class CreditCalculator
    {
        //Метод для вычисления ежемесячного платежа для (аннуитетного платежа)
        public static double CalculateAnnuityMonthPayment(double creditSum, int term, double percent)
        {
            if (percent == 0)
            {
                return Math.Round(creditSum / term);
            }

            double monthlyInterestRate = percent / 1200; //Годовая процентная ставка в процентах


            double num = monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, term); //Числитель формулы
            double denom = Math.Pow(1 + monthlyInterestRate, term) - 1; //Знаменатель формулы


            if (denom == 0)
            {
                return 0;
            }

            double coff = num / denom; //Коэффициент аннуитета

            double monthPayment = creditSum * coff; //Ежемесячный платеж

            return Math.Round(monthPayment, 2);
        }



        //Метод для вычисления общей суммы для (аннуитетного платежа)
        public static double CalculateAnnuityTotalSum(double monthlyPayment, int term)
        {
            return Math.Round(monthlyPayment * term, 2);
        }



        //Метод для вычисления переплаты для (аннуитетного платежа)
        public static double CalculateAnnuityOverpayment(double creditSum, double monthlyPayment, int term)
        {
            return Math.Round((monthlyPayment * term) - creditSum, 2);
        }



        //Метод для проверки корректности ввода суммы кредита
        public static void CheckedValidCreditSum(double creditSum)
        {
            if (creditSum < 50000)
            {
                throw new Exception("Минимальная сумма кредита 50 000 рублей");
            }
            if (creditSum > 100000000)
            {
                throw new Exception("Максимальная сумма кредита 100 000 000 рублей");
            }
        }



        //Метод для проверки корректности ввода срока платежа
        public static void CheckedValidTerm(int term)
        {
            if (term < 6)
            {
                throw new Exception("Минимальный срок платежа - 6 месяцев");

            }
            if (term > 360)
            {
                throw new Exception("Максимальный срок платежа - 360 месяцев");
            }
        }


    }
}
